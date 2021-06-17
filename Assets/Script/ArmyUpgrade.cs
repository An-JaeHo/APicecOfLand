using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyUpgrade : MonoBehaviour
{
    public MakeSoldier armyinfo;
    public Transform army;
    public MakeSoldier upgradeArmy;

    public void UpdateArmyInfo(Transform info)
    {
        army = info;
        armyinfo = info.GetComponent<MakeSoldier>();
        upgradeArmy = new MakeSoldier();

        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armyinfo.Picture;

        //변경하기 전
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.name;
        transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.HelthPoint.ToString();
        transform.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.BaseAttack.ToString();
        transform.GetChild(3).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armyinfo.BaseAttack.ToString();

        transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "식량 : " + armyinfo.ProductionExpense.ToString();

        upgradeArmy = UpGradeFinder(armyinfo.Code);

        //변경 후
        transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.Name;
        transform.GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.HelthPoint.ToString();
        transform.GetChild(3).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.BaseAttack.ToString();
        transform.GetChild(3).GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = upgradeArmy.BaseAttack.ToString();
    }


    public MakeSoldier UpGradeFinder(string armyCode)
    {
        MakeSoldier nextArmy = new MakeSoldier();
        //string armyName;
        //string troop;
        //string attack;
        //string defensive;

        switch (armyCode)
        {
            case "Troop 1":
                nextArmy.SuperMagic("Troop 5");
                break;

            case "Troop 2":
                nextArmy.SuperMagic("Troop 6");
                break;

            case "Troop 3":
                nextArmy.SuperMagic("Troop 7");
                break;

            case "Troop 4":
                nextArmy.SuperMagic("Troop 8");
                break;

            case "Troop 5":
                nextArmy.SuperMagic("Troop 9");
                break;

            case "Troop 6":
                nextArmy.SuperMagic("Troop 10");
                break;

            case "Troop 7":
                nextArmy.SuperMagic("Troop 11");
                break;

            case "Troop 8":
                nextArmy.SuperMagic("Troop 12");
                break;

            case "Troop 9":
                nextArmy.SuperMagic("Troop 13");
                break;

            case "Troop 10":
                nextArmy.SuperMagic("Troop 14");
                break;

            case "Troop 11":
                nextArmy.SuperMagic("Troop 15");
                break;

            case "Troop 12":
                nextArmy.SuperMagic("Troop 16");
                //armyName = nextArmy.Name;
                //troop = nextArmy.BaseTroop.ToString();
                //attack = nextArmy.BaseAttack.ToString();
                //defensive = nextArmy.Defensive.ToString();
                break;

            default:
                break;
        }

        return nextArmy;
    }
}
