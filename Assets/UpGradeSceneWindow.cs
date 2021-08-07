using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeSceneWindow : MonoBehaviour
{
    public int needUpGradeMilk;
    public int needUpGradeSugar;
    public int needUpGradeFlour;

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
    }


    public void NeedUpGradeSouce(Transform monster)
    {
        switch (monster.GetComponent<MakeSoldier>().Code)
        {
            case "Mons 1":
                if(monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 50;
                    needUpGradeSugar = 30;
                    needUpGradeFlour = 20;
                }
                else if(monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 65;
                    needUpGradeSugar = 70;
                    needUpGradeFlour = 40;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 80;
                    needUpGradeSugar = 150;
                    needUpGradeFlour = 100;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if(monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                    break;
            case "Mons 2":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 3":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 4":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 5":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 6":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 7":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 8":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 9":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 10":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 11":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 12":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 13":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 14":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 15":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 16":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 17":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            case "Mons 18":
                if (monster.GetComponent<MakeSoldier>().Level == 1)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 2)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 3)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 4)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                else if (monster.GetComponent<MakeSoldier>().Level == 5)
                {
                    needUpGradeMilk = 1;
                    needUpGradeSugar = 2;
                    needUpGradeFlour = 3;
                }
                break;
            default:
                break;
        }
    }
}
