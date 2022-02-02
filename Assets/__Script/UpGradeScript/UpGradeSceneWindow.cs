using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeSceneWindow : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject upGradeButton;
    public GameObject supply;
    public Text monsterLevel;
    public Text monsterName;

    [Header("State")]
    public Transform stateWindow;
    public Transform needSouceWindow;

    [Header("Set in VisualStudio")]
    public JsonManger jsonManger;
    public PlayerInfo playerInfo;
    public UpGradeInputManger upGradeInputManger;
    public int needUpGradeMilk;
    public int needUpGradeSugar;
    public int needUpGradeFlour;
    public Transform monster;
    public GameObject[] MonsterObj;
    public SaveMgr saveMgr;

    

    void Start()
    {
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));

        MonsterObj = new GameObject[loadMonster.Length];
                for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }
    }

    public void UpGradeCheck(Transform obj)
    {
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        MakeSoldier nextMonster = GetComponent<ArmyUpgrade>().UpGradeFinder(obj.GetComponent<MakeSoldier>().Code);
        NeedUpGradeSouce(obj);

        monsterLevel.text = obj.GetComponent<MakeSoldier>().Level.ToString();
        monsterName.text = obj.GetComponent<MakeSoldier>().Name;

        stateWindow.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().HelthPoint.ToString();
        stateWindow.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().BaseAttack.ToString();
        stateWindow.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Defensive.ToString();
        stateWindow.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Critical.ToString()+ "%";

        if (obj.GetComponent<MakeSoldier>().Level == 5)
        {
            stateWindow.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.HelthPoint.ToString();
            stateWindow.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.BaseAttack.ToString();
            stateWindow.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.Defensive.ToString();
            stateWindow.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.Critical.ToString()+"%";
        }
        else
        {
            stateWindow.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().HelthPoint + obj.GetComponent<MakeSoldier>().RiseHelth * obj.GetComponent<MakeSoldier>().Level).ToString();
            stateWindow.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().BaseAttack + obj.GetComponent<MakeSoldier>().RiseAttack* obj.GetComponent<MakeSoldier>().Level).ToString();
            stateWindow.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().Defensive + obj.GetComponent<MakeSoldier>().RiseDefensive * obj.GetComponent<MakeSoldier>().Level).ToString();
            stateWindow.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().Critical + obj.GetComponent<MakeSoldier>().RiseCritical * obj.GetComponent<MakeSoldier>().Level).ToString()+"%";
        }


        if (saveMgr.playerSave.milk >= needUpGradeMilk
            && saveMgr.playerSave.sugar >= needUpGradeSugar
            && saveMgr.playerSave.flour >= needUpGradeFlour)
        {
            upGradeButton.GetComponent<Button>().interactable = true;
            needSouceWindow.GetChild(0).GetChild(1).GetComponent<Text>().text = needUpGradeMilk.ToString();
            needSouceWindow.GetChild(1).GetChild(1).GetComponent<Text>().text = needUpGradeSugar.ToString();
            needSouceWindow.GetChild(2).GetChild(1).GetComponent<Text>().text = needUpGradeFlour.ToString();

            if (obj.GetComponent<MakeSoldier>().Level == 5
                && obj.GetComponent<MakeSoldier>().Grade != 3)
            {
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "Ω¬±ﬁ";
            }
            else
            {
                if(obj.GetComponent<MakeSoldier>().Level == 10)
                {
                    upGradeButton.GetComponent<Button>().interactable = false;
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "∏∏∑æ";
                }
                else
                {
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "¡¯»≠";
                }
            }
                
        }
        else
        {
            needSouceWindow.GetChild(0).GetChild(1).GetComponent<Text>().text = needUpGradeMilk.ToString();
            needSouceWindow.GetChild(1).GetChild(1).GetComponent<Text>().text = needUpGradeSugar.ToString();
            needSouceWindow.GetChild(2).GetChild(1).GetComponent<Text>().text = needUpGradeFlour.ToString();
            upGradeButton.GetComponent<Button>().interactable = false;

            if (obj.GetComponent<MakeSoldier>().Level == 10)
            {
                
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "∏∏∑æ";
            }
            else
            {
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "¡¯»≠";
            }
                
        }
        monster = obj;
    }

    public void NeedUpGradeSouce(Transform monster)
    {
        jsonManger = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();

        for (int i = 0; i < jsonManger.information.unitUpgrade.Length; i++)
        {
            if(monster.GetComponent<MakeSoldier>().Level == jsonManger.information.unitUpgrade[i].NowLevel
                && monster.GetComponent<MakeSoldier>().Code == jsonManger.information.unitUpgrade[i].Code)
            {
                needUpGradeMilk = jsonManger.information.unitUpgrade[i].UpgradeMilk;
                needUpGradeSugar = jsonManger.information.unitUpgrade[i].UpgradeSugar;
                needUpGradeFlour = jsonManger.information.unitUpgrade[i].UpgradeFlour;
            }
        }
    }

    public void LevelUpButton()
    {
        upGradeInputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<UpGradeInputManger>();

        if (monster.GetComponent<MakeSoldier>().Level == 5 
            && monster.GetComponent<MakeSoldier>().Grade != 3)
        {
            UpGradeMonster();
        }
        else
        {
            monster.GetComponent<MakeSoldier>().Level++;
            monster.GetComponent<MakeSoldier>().BaseAttack += monster.GetComponent<MakeSoldier>().RiseAttack;
            monster.GetComponent<MakeSoldier>().Critical += monster.GetComponent<MakeSoldier>().RiseCritical;
            monster.GetComponent<MakeSoldier>().Defensive += monster.GetComponent<MakeSoldier>().RiseDefensive;

            monsterLevel.text = monster.GetComponent<MakeSoldier>().Level.ToString();
        }
        
        saveMgr.playerSave.milk-= needUpGradeMilk;
        saveMgr.playerSave.sugar -= needUpGradeSugar;
        saveMgr.playerSave.flour -= needUpGradeFlour;
        //¿˙¿Â «œ≥™?
        SaveLevelAndRank(monster);
        
        supply.GetComponent<MySupplyList>().UpdateSupply();
        upGradeInputManger.mouseCheck = true;
        UpGradeCheck(monster);
    }

    public void UpGradeMonster()
    {
        Transform monsterParent = monster.parent;
        string nextCode;
        Destroy(monster.GetChild(1).gameObject);
        nextCode = GetComponent<ArmyUpgrade>().UpGradeFinder(monster.GetComponent<MakeSoldier>().Code).Code;

        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (MonsterObj[i].name == nextCode)
            {
                GameObject monsterPicture = Instantiate(MonsterObj[i], monster);
                monsterPicture.transform.position = new Vector3(monsterPicture.transform.position.x, monsterPicture.transform.position.y - 0.3f);
                monsterPicture.transform.localScale = new Vector3(0.8f, 0.8f);
            }
        }
        monster.GetComponent<MakeSoldier>().SuperMagic(nextCode);
    }

    public void SaveLevelAndRank(Transform monster)
    {
        switch (monster.GetComponent<MakeSoldier>().Name)
        {
            case "æÁ√ ∏”«…":
                saveMgr.playerSave.SaveCherryGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveCherryLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "¡¯¿˙ƒÌ≈∞":
                saveMgr.playerSave.SaveCandyGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveCandyLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "Ω∫≈∞∆≤¡Óƒ…¿Ã≈©":
                saveMgr.playerSave.SaveSkittlesGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveSkittlesLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "µµ≥”√˜":
                saveMgr.playerSave.SaveDonutsGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveDonutsLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "Ω¥¥œπﬂ∑ª":
                saveMgr.playerSave.SaveSchneeballenGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveSchneeballenLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "√ ƒ⁄ƒ®ƒÌ≈∞":
                saveMgr.playerSave.SaveChocoGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.SaveChocoLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            default:
                break;
        }

        saveMgr.JustSave();
    }
}
