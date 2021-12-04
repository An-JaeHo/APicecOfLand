using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    //public Transform hitTransform;
    public Sprite carInfo;
    public GameObject SoldierPrefeb;
    public GameObject EnemyPrefeb;
    public GameObject AreaPrefeb;

    public void FindCard(string CardCode)
    {

        switch (CardCode)
        {
            case "Card 1":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack += 3;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 2":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack += 5;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 3":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack += 7;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 4":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack += 10;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 5":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive += 3;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 6":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive += 5;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 7":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive += 7;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 8":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive += 10;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 9":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 10":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 11":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 12":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint*0.15f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }

                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                break;
            case "Card 13":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint * 0.30f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }
                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 14":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint * 0.50f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }
                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 15":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 16":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 2;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 17":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 3;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 18":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0.2f;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 19":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0.4f;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 20":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0.6f;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 21":
                SoldierPrefeb.GetComponent<SoldierManger>().cardMovePoint = true;
                break;
            case "Card 22":
                SoldierPrefeb.GetComponent<SoldierManger>().cardMovePoint = true;
                break;
            case "Card 23":
                SoldierPrefeb.GetComponent<SoldierManger>().cardMovePoint = true;
                break;
            case "Card 24":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive -= 3;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive -= 3;
                }
                break;
            case "Card 25":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive -= 5;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive -= 5;
                }
                break;
            case "Card 26":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive -= 7;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive -= 7;
                }
                break;
            case "Card 27":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive -= 10;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive -= 10;
                }
                break;
            case "Card 28":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint*0.15f);
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().HelthPoint -= (int)(EnemyPrefeb.GetComponent<GDController>().HelthPoint * 0.15f);
                }
                EnemyPrefeb.GetComponent<EnemyController>().HpBarScale();
                break;
            case "Card 29":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint * 0.20f);
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().HelthPoint -= (int)(EnemyPrefeb.GetComponent<GDController>().HelthPoint * 0.20f);
                }
                EnemyPrefeb.GetComponent<EnemyController>().HpBarScale();
                break;
            case "Card 30":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint * 0.30f);
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().HelthPoint -= (int)(EnemyPrefeb.GetComponent<GDController>().HelthPoint * 0.30f);
                }
                EnemyPrefeb.GetComponent<EnemyController>().HpBarScale();
                break;
            case "Card 31":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(EnemyPrefeb.GetComponent<MakeEnemy>().BaseHelthPoint * 0.50f);
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().HelthPoint -= (int)(EnemyPrefeb.GetComponent<GDController>().HelthPoint * 0.50f);
                }
                EnemyPrefeb.GetComponent<EnemyController>().HpBarScale();
                break;
            case "Card 32":
                EnemyPrefeb.GetComponent<EnemyController>().movePoint = false;
                break;
            case "Card 33":
                EnemyPrefeb.GetComponent<EnemyController>().movePoint = false;
                break;
            case "Card 34":
                EnemyPrefeb.GetComponent<EnemyController>().movePoint = false;
                break;
            case "Card 35":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += 50;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 36":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += 100;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 37":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += 200;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 38":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += 50;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 39":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += 100;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 40":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += 200;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 41":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += 50;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 42":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += 100;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 43":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += 200;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 44":
                AreaPrefeb.GetComponent<AreaManger>().player.people += 1;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 45":
                AreaPrefeb.GetComponent<AreaManger>().player.people += 2;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 46":
                AreaPrefeb.GetComponent<AreaManger>().player.people += 3;
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 47":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += (int)(AreaPrefeb.GetComponent<AreaManger>().player.milk * 0.1f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 48":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += (int)(AreaPrefeb.GetComponent<AreaManger>().player.milk * 0.2f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 49":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += (int)(AreaPrefeb.GetComponent<AreaManger>().player.milk * 0.3f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 50":
                AreaPrefeb.GetComponent<AreaManger>().player.milk += (int)(AreaPrefeb.GetComponent<AreaManger>().player.milk * 0.5f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 51":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += (int)(AreaPrefeb.GetComponent<AreaManger>().player.flour * 0.1f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 52":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += (int)(AreaPrefeb.GetComponent<AreaManger>().player.flour * 0.2f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 53":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += (int)(AreaPrefeb.GetComponent<AreaManger>().player.flour * 0.3f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 54":
                AreaPrefeb.GetComponent<AreaManger>().player.flour += (int)(AreaPrefeb.GetComponent<AreaManger>().player.flour * 0.5f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 55":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += (int)(AreaPrefeb.GetComponent<AreaManger>().player.sugar * 0.1f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 56":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += (int)(AreaPrefeb.GetComponent<AreaManger>().player.sugar * 0.2f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 57":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += (int)(AreaPrefeb.GetComponent<AreaManger>().player.sugar * 0.3f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 58":
                AreaPrefeb.GetComponent<AreaManger>().player.sugar += (int)(AreaPrefeb.GetComponent<AreaManger>().player.sugar * 0.5f);
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
        }
    }

    private void Card1(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card2(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 5;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card3(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 7;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card4(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 10;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card5(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Defensive += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card6(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Defensive += 5;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card7(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Defensive += 7;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card8(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Defensive += 10;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card9(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Movement += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card10(GameObject soldier, string code)
    {
        Debug.Log(soldier.name);
        soldier.GetComponent<MakeSoldier>().Movement += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card11(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Movement += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card12(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().HelthPoint += 500;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<MakeSoldier>().HelthPoint)
        {
            soldier.GetComponent<MakeSoldier>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card13(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().HelthPoint += 1000;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<MakeSoldier>().HelthPoint)
        {
            soldier.GetComponent<MakeSoldier>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card14(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().HelthPoint += 2000;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<MakeSoldier>().HelthPoint)
        {
            soldier.GetComponent<MakeSoldier>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card15(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Movement += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card16(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Movement += 2;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card17(GameObject soldier, string code)
    {
        soldier.GetComponent<MakeSoldier>().Movement += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card18(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().countAttack = 0.2f;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card19(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().countAttack = 0.4f;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card20(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().countAttack = 0.6f;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card21(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().cardMovePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card22(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().cardMovePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card23(GameObject soldier, string code)
    {
        soldier.GetComponent<SoldierManger>().cardMovePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(code);
    }

    private void Card24(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseDefensive -= 3;
        }
        else
        {
            enemy.GetComponent<GDController>().Defensive -= 3;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card25(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseDefensive -= 5;
        }
        else
        {
            enemy.GetComponent<GDController>().Defensive -= 5;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card26(GameObject enemy, string code)
    {
        if(enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseDefensive -= 7;
        }
        else
        {
            enemy.GetComponent<GDController>().Defensive -= 7;
        }
        
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card27(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseDefensive -= 10;
        }
        else
        {
            enemy.GetComponent<GDController>().Defensive -= 10;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card28(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 500;
        }
        else
        {
            enemy.GetComponent<GDController>().HelthPoint -= 500;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card29(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 1000;
        }
        else
        {
            enemy.GetComponent<GDController>().HelthPoint -= 1000;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card30(GameObject enemy, string code)
    {
         if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 1500;
        }
        else
        {
            enemy.GetComponent<GDController>().HelthPoint -= 1500;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card31(GameObject enemy, string code)
    {
        if (enemy.tag == "Enemy")
        {
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 2000;
        }
        else
        {
            enemy.GetComponent<GDController>().HelthPoint -= 2000;
        }
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card32(GameObject enemy, string code)
    {
        enemy.GetComponent<EnemyController>().movePoint = false;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card33(GameObject enemy, string code)
    {
        enemy.GetComponent<EnemyController>().movePoint = false;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card34(GameObject enemy, string code)
    {
        enemy.GetComponent<EnemyController>().movePoint = false;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card35(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += 50;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card36(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += 100;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card37(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += 200;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card38(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += 50;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card39(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += 100;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card40(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += 200;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card41(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += 50;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card42(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar +=100;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card43(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += 200;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card44(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.people += 1;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card45(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.people += 2;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card46(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.people += 3;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card47(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += (int)(area.GetComponent<AreaManger>().player.milk * 0.1f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card48(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += (int)(area.GetComponent<AreaManger>().player.milk * 0.2f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card49(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += (int)(area.GetComponent<AreaManger>().player.milk * 0.3f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card50(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.milk += (int)(area.GetComponent<AreaManger>().player.milk * 0.5f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card51(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += (int)(area.GetComponent<AreaManger>().player.flour * 0.1f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card52(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += (int)(area.GetComponent<AreaManger>().player.flour * 0.2f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card53(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += (int)(area.GetComponent<AreaManger>().player.flour * 0.3f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card54(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.flour += (int)(area.GetComponent<AreaManger>().player.flour * 0.5f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card55(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += (int)(area.GetComponent<AreaManger>().player.sugar * 0.1f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card56(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += (int)(area.GetComponent<AreaManger>().player.sugar * 0.2f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card57(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += (int)(area.GetComponent<AreaManger>().player.sugar * 0.3f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card58(GameObject area, string code)
    {
        area.GetComponent<AreaManger>().player.sugar += (int)(area.GetComponent<AreaManger>().player.sugar * 0.5f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }
}
