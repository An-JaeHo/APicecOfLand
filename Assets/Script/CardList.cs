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
                Card1(SoldierPrefeb, CardCode);
                break;
            case "Card 2":
                Card2(SoldierPrefeb, CardCode);
                break;
            case "Card 3":
                Card3(SoldierPrefeb, CardCode);
                break;
            case "Card 4":
                Card4(SoldierPrefeb, CardCode);
                break;
            case "Card 5":
                Card5(SoldierPrefeb, CardCode);
                break;
            case "Card 6":
                Card6(SoldierPrefeb, CardCode);
                break;
            case "Card 7":
                Card7(SoldierPrefeb, CardCode);
                break;
            case "Card 8":
                Card8(SoldierPrefeb, CardCode);
                break;
            case "Card 9":
                Card9(SoldierPrefeb, CardCode);
                break;
            case "Card 10":
                Card10(SoldierPrefeb, CardCode);
                break;
            case "Card 11":
                Card11(SoldierPrefeb, CardCode);
                break;
            case "Card 12":
                Card12(SoldierPrefeb, CardCode);
                break;
            case "Card 13":
                Card13(SoldierPrefeb, CardCode);
                break;
            case "Card 14":
                Card14(SoldierPrefeb, CardCode);
                break;
            case "Card 15":
                Card15(SoldierPrefeb, CardCode);
                break;
            case "Card 16":
                Card16(SoldierPrefeb, CardCode);
                break;
            case "Card 17":
                Card17(SoldierPrefeb, CardCode);
                break;
            case "Card 18":
                Card18(SoldierPrefeb, CardCode);
                break;
            case "Card 19":
                Card19(SoldierPrefeb, CardCode);
                break;
            case "Card 20":
                Card20(SoldierPrefeb, CardCode);
                break;
            case "Card 21":
                Card21(SoldierPrefeb, CardCode);
                break;
            case "Card 22":
                Card22(SoldierPrefeb, CardCode);
                break;
            case "Card 23":
                Card23(SoldierPrefeb, CardCode);
                break;
            case "Card 24":
                Card24(EnemyPrefeb, CardCode);
                break;
            case "Card 25":
                Card25(EnemyPrefeb, CardCode);
                break;
            case "Card 26":
                Card26(EnemyPrefeb, CardCode);
                break;
            case "Card 27":
                Card27(EnemyPrefeb, CardCode);
                break;
            case "Card 28":
                Card28(EnemyPrefeb, CardCode);
                break;
            case "Card 29":
                Card29(EnemyPrefeb, CardCode);
                break;
            case "Card 30":
                Card30(EnemyPrefeb, CardCode);
                break;
            case "Card 31":
                Card31(EnemyPrefeb, CardCode);
                break;
            case "Card 32":
                Card32(EnemyPrefeb, CardCode);
                break;
            case "Card 33":
                Card33(EnemyPrefeb, CardCode);
                break;
            case "Card 34":
                Card34(EnemyPrefeb, CardCode);
                break;
            case "Card 35":
                Card35(AreaPrefeb, CardCode);
                break;
            case "Card 36":
                Card36(AreaPrefeb, CardCode);
                break;
            case "Card 37":
                Card37(AreaPrefeb, CardCode);
                break;
            case "Card 38":
                Card38(AreaPrefeb, CardCode);
                break;
            case "Card 39":
                Card39(AreaPrefeb, CardCode);
                break;
            case "Card 40":
                Card40(AreaPrefeb, CardCode);
                break;
            case "Card 41":
                Card41(AreaPrefeb, CardCode);
                break;
            case "Card 42":
                Card42(AreaPrefeb, CardCode);
                break;
            case "Card 43":
                Card43(AreaPrefeb, CardCode);
                break;
            case "Card 44":
                Card44(AreaPrefeb, CardCode);
                break;
            case "Card 45":
                Card45(AreaPrefeb, CardCode);
                break;
            case "Card 46":
                Card46(AreaPrefeb, CardCode);
                break;
            case "Card 47":
                Card47(AreaPrefeb, CardCode);
                break;
            case "Card 48":
                Card48(AreaPrefeb, CardCode);
                break;
            case "Card 49":
                Card49(AreaPrefeb, CardCode);
                break;
            case "Card 50":
                Card50(AreaPrefeb, CardCode);
                break;
            case "Card 51":
                Card51(AreaPrefeb, CardCode);
                break;
            case "Card 52":
                Card52(AreaPrefeb, CardCode);
                break;
            case "Card 53":
                Card53(AreaPrefeb, CardCode);
                break;
            case "Card 54":
                Card54(AreaPrefeb, CardCode);
                break;
            case "Card 55":
                Card55(AreaPrefeb, CardCode);
                break;
            case "Card 56":
                Card56(AreaPrefeb, CardCode);
                break;
            case "Card 57":
                Card57(AreaPrefeb, CardCode);
                break;
            case "Card 58":
                Card58(AreaPrefeb, CardCode);
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
        enemy.GetComponent<MakeEnemy>().BaseDefensive -= 3;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card25(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseDefensive -= 5;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card26(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseDefensive -= 7;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card27(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseDefensive -= 10;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card28(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 500;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card29(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 1000;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card30(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 1500;
        enemy.GetComponent<EnemyController>().MakeBuffIcon(code);
    }

    private void Card31(GameObject enemy, string code)
    {
        enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= 2000;
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
