using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeSceneWindow : MonoBehaviour
{
    public JsonManger jsonManger;
    public PlayerInfo playerInfo;
    public GameObject upGradeButton;
    public GameObject supply;
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
        MakeSoldier nextMonster = GetComponent<ArmyUpgrade>().UpGradeFinder(obj.GetComponent<MakeSoldier>().Code);

        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = obj.GetComponent<MakeSoldier>().Picture;
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Level.ToString();
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Name;

        transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().HelthPoint.ToString();
        transform.GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().BaseAttack.ToString();
        transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Defensive.ToString();
        transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Critical.ToString();

        if (obj.GetComponent<MakeSoldier>().Level == 5)
        {
            transform.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.HelthPoint.ToString();
            transform.GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.BaseAttack.ToString();
            transform.GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.Defensive.ToString();
            transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = nextMonster.Critical.ToString();
        }
        else
        {
            transform.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().HelthPoint.ToString();
            transform.GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().BaseAttack + obj.GetComponent<MakeSoldier>().RiseAttack).ToString();
            transform.GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().Defensive + obj.GetComponent<MakeSoldier>().RiseDefensive).ToString();
            transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = (obj.GetComponent<MakeSoldier>().Critical + obj.GetComponent<MakeSoldier>().RiseCritical).ToString();
        }

        NeedUpGradeSouce(obj);

        if (playerInfo.playerMilk >= needUpGradeMilk
            && playerInfo.playerSugar >= needUpGradeSugar
            && playerInfo.playerFlour >= needUpGradeFlour)
        {
            upGradeButton.GetComponent<Button>().interactable = true;

            if (obj.GetComponent<MakeSoldier>().Level == 5
                && obj.GetComponent<MakeSoldier>().Grade != 3)
            {
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "다음 단계로 승급이 가능합니다.";
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "승급";
            }
            else
            {
                if(obj.GetComponent<MakeSoldier>().Level == 10)
                {
                    transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "최대레벨 입니다.";
                    upGradeButton.GetComponent<Button>().interactable = false;
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "만렙";
                }
                else
                {
                    transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "레벨" + (obj.GetComponent<MakeSoldier>().Level + 1) + "로 진화가 가능합니다.";
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "진화";
                }
            }
                
        }
        else
        {
            if (obj.GetComponent<MakeSoldier>().Level == 10)
            {
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "최대레벨 입니다.";
                upGradeButton.GetComponent<Button>().interactable = false;
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "만렙";
            }
            else
            {
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "진화";
                upGradeButton.GetComponent<Button>().interactable = false;
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "자원이 부족합니다.";
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

            monster.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = monster.GetComponent<MakeSoldier>().Level.ToString(); ;
        }

        playerInfo.playerMilk -= needUpGradeMilk;
        playerInfo.playerSugar -= needUpGradeSugar;
        playerInfo.playerFlour -= needUpGradeFlour;

        supply.GetComponent<MySupplyList>().UpdateSupply();
        SaveLevelAndRank(monster);
        gameObject.SetActive(false);
        upGradeInputManger.mouseCheck = true;
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
                monsterPicture.transform.localScale = new Vector2(0.35f, 0.35f);
                monsterPicture.transform.position = new Vector3(monsterPicture.transform.position.x+0.1f, monsterPicture.transform.position.y - 0.4f);
            }
        }

        monster.GetComponent<MakeSoldier>().SuperMagic(nextCode);
        monster.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = monster.GetComponent<MakeSoldier>().Level.ToString();
    }

    public void SaveLevelAndRank(Transform monster)
    {
        switch (monster.GetComponent<MakeSoldier>().Name)
        {
            case "체리머핀":
                playerInfo.GameCherryGrade= monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameCherryLevel= monster.GetComponent<MakeSoldier>().Level;
                break;
            case "사탕막대":
                playerInfo.GameCandyGrade = monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameCandyLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "스키틀즈케이크":
                playerInfo.GameSkittlesGrade= monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameSkittlesLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "도넛츠":
                playerInfo.GameDonutsGrade = monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameDonutsLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "슈니발렌":
                playerInfo.GameSchneeballenGrade= monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameSchneeballenLevel= monster.GetComponent<MakeSoldier>().Level;
                break;
            case "초코칩쿠키":
                playerInfo.GameChocoGrade = monster.GetComponent<MakeSoldier>().Grade;
                playerInfo.GameChocoLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            default:
                break;
        }

        //saveMgr
    }
}
