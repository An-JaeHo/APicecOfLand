using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyUpgrade : MonoBehaviour
{
    public MakeSoldier armyinfo;
    public Transform army;
    public MakeSoldier upgradeArmy;
    public GameObject button;
    public PlayerInfo playerInfo;
    public int upgradeMilk;

    private void Start()
    {
        upgradeMilk = new int();
    }

    public void UpdateArmyInfo(Transform info)
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        army = info;
        armyinfo = info.GetComponent<MakeSoldier>();
        upgradeArmy = new MakeSoldier();
        upgradeArmy = UpGradeFinder(armyinfo.Code);

        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armyinfo.Picture;
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = armyinfo.Level.ToString();
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = armyinfo.Name;
        
        

        if (armyinfo.Grade != 3)
        {
            //변경하기 전
            transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Grade.ToString();
            transform.GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.HelthPoint.ToString();
            transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.BaseAttack.ToString();
            transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Defensive.ToString();
            transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Critical.ToString();

            

            //변경 후
            transform.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.Grade.ToString();
            transform.GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.HelthPoint.ToString();
            transform.GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.BaseAttack.ToString();
            transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.Defensive.ToString();
            transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.Critical.ToString();

            transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "우유 : " + upgradeMilk;
        }
        else
        {
            transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Grade.ToString();
            transform.GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.HelthPoint.ToString();
            transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.BaseAttack.ToString();
            transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Defensive.ToString();
            transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.Critical.ToString();

            transform.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "MAX";
            transform.GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = "MAX";
            transform.GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "MAX";
            transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = "MAX";
            transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = "MAX";

            upgradeMilk = 0;
        }

        if (upgradeMilk > playerInfo.milk)
        {
            button.GetComponent<Button>().interactable = false;
            transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "우유가 " + (upgradeMilk - playerInfo.milk) + "만 큼 부족합니다.";
            transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "최대 등급의 유닛입니다.";
        }
        else
        {
            button.GetComponent<Button>().interactable = true;
        }
    }


    public MakeSoldier UpGradeFinder(string armyCode)
    {
        MakeSoldier nextArmy = new MakeSoldier();


        switch (armyCode)
        {
            case "Mon 1":
                nextArmy.SuperMagic("Mon 2");
                upgradeMilk = 20;
                break;

            case "Mon 2":
                nextArmy.SuperMagic("Mon 3");
                upgradeMilk = 30;
                break;

            case "Mon 4":
                nextArmy.SuperMagic("Mon 5");
                upgradeMilk = 20;
                break;

            case "Mon 5":
                nextArmy.SuperMagic("Mon 6");
                upgradeMilk = 30;
                break;

            case "Mon 7":
                nextArmy.SuperMagic("Mon 8");
                upgradeMilk = 20;
                break;

            case "Mon 8":
                nextArmy.SuperMagic("Mon 9");
                upgradeMilk = 30;
                break;

            case "Mon 10":
                nextArmy.SuperMagic("Mon 11");
                upgradeMilk = 20;
                break;

            case "Mon 11":
                nextArmy.SuperMagic("Mon 12");
                upgradeMilk = 30;
                break;

            case "Mon 13":
                nextArmy.SuperMagic("Mon 14");
                upgradeMilk = 20;
                break;

            case "Mon 14":
                nextArmy.SuperMagic("Mon 15");
                upgradeMilk = 30;
                break;

            case "Mon 16":
                nextArmy.SuperMagic("Mon 17");
                upgradeMilk = 20;
                break;

            case "Mon 17":
                nextArmy.SuperMagic("Mon 18");
                break;

            default:
                break;
        }

        return nextArmy;
    }
}
