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
    private Transform monster;
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
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "���� �ܰ�� �±��� �����մϴ�.";
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "�±�";
            }
            else
            {
                if(obj.GetComponent<MakeSoldier>().Level == 10)
                {
                    transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "�ִ뷹�� �Դϴ�.";
                    upGradeButton.GetComponent<Button>().interactable = false;
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "����";
                }
                else
                {
                    transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "����" + (obj.GetComponent<MakeSoldier>().Level + 1) + "�� ��ȭ�� �����մϴ�.";
                    upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "��ȭ";
                }
            }
                
        }
        else
        {
            if (obj.GetComponent<MakeSoldier>().Level == 10)
            {
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "�ִ뷹�� �Դϴ�.";
                upGradeButton.GetComponent<Button>().interactable = false;
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "����";
            }
            else
            {
                upGradeButton.transform.GetChild(0).GetComponent<Text>().text = "��ȭ";
                upGradeButton.GetComponent<Button>().interactable = false;
                transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "�ڿ��� �����մϴ�.";
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

            monster.parent.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = monster.GetComponent<MakeSoldier>().Level.ToString(); ;
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
        Destroy(monster.gameObject);
        nextCode = GetComponent<ArmyUpgrade>().UpGradeFinder(monster.GetComponent<MakeSoldier>().Code).Code;

        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (MonsterObj[i].name == nextCode)
            {
                GameObject monsterPicture = Instantiate(MonsterObj[i], new Vector3(monsterParent.position.x, monsterParent.position.y-0.4f), Quaternion.identity);
                monsterPicture.transform.localScale = new Vector2(0.55f, 0.55f);
                monsterPicture.transform.SetParent(monsterParent);
                monster = monsterPicture.transform;
            }
        }

        monster.gameObject.AddComponent<MakeSoldier>().SuperMagic(nextCode);
        monster.parent.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = monster.GetComponent<MakeSoldier>().Level.ToString();
        monster.gameObject.AddComponent<BoxCollider2D>().size = new Vector2(2,2);
        monster.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 1.4f);
        monster.tag = "Army";
    }

    public void SaveLevelAndRank(Transform monster)
    {
        switch (monster.GetComponent<MakeSoldier>().Name)
        {
            case "ü������":
                saveMgr.playerSave.cherryGrade= monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.cherryLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "��������":
                saveMgr.playerSave.candyGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.candyLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "��ŰƲ������ũ":
                saveMgr.playerSave.skittlesGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.skittlesLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "������":
                saveMgr.playerSave.donutsGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.donutsLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "���Ϲ߷�":
                saveMgr.playerSave.schneeballenGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.schneeballenLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            case "����Ĩ��Ű":
                saveMgr.playerSave.chocoGrade = monster.GetComponent<MakeSoldier>().Grade;
                saveMgr.playerSave.chocoLevel = monster.GetComponent<MakeSoldier>().Level;
                break;
            default:
                break;
        }

        //saveMgr
    }
}