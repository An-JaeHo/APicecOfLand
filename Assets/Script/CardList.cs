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
                Card1(SoldierPrefeb);
                break;
            case "Card 2":
                Card2(SoldierPrefeb);
                break;
            case "Card 3":
                Card3(SoldierPrefeb);
                break;
            case "Card 4":
                Card4(SoldierPrefeb);
                break;
            case "Card 5":
                Card5(SoldierPrefeb);
                break;
            case "Card 6":
                Card6(SoldierPrefeb);
                break;
            case "Card 7":
                Card7(SoldierPrefeb);
                break;
            case "Card 8":
                Card8(SoldierPrefeb);
                break;
            case "Card 9":
                Card9(SoldierPrefeb);
                break;
            case "Card 10":
                Card10(SoldierPrefeb);
                break;
            case "Card 11":
                Card11(SoldierPrefeb);
                break;
            case "Card 12":
                Card12(SoldierPrefeb);
                break;
            case "Card 13":
                Card13(SoldierPrefeb);
                break;
            case "Card 14":
                Card14(SoldierPrefeb);
                break;
            case "Card 15":
                Card15(SoldierPrefeb);
                break;
            case "Card 16":
                Card16(SoldierPrefeb);
                break;
            case "Card 17":
                Card17(SoldierPrefeb);
                break;
            case "Card 18":
                Card18(SoldierPrefeb);
                break;
            case "Card 19":
                Card19(SoldierPrefeb);
                break;
            case "Card 20":
                Card20(SoldierPrefeb);
                break;
            case "Card 21":
                Card21(SoldierPrefeb);
                break;
            case "Card 22":
                Card22(SoldierPrefeb);
                break;
            case "Card 23":
                Card23(SoldierPrefeb);
                break;
            case "Card 24":
                Card24(EnemyPrefeb);
                break;
            case "Card 25":
                Card25(EnemyPrefeb);
                break;
            case "Card 26":
                Card26(EnemyPrefeb);
                break;
            case "Card 27":
                Card27(EnemyPrefeb);
                break;
            case "Card 28":
                Card28(AreaPrefeb);
                break;
            case "Card 29":
                Card29(AreaPrefeb);
                break;
            case "Card 30":
                Card30(AreaPrefeb);
                break;
            case "Card 31":
                Card31(AreaPrefeb);
                break;
            case "Card 32":
                Card32(AreaPrefeb);
                break;
            case "Card 33":
                Card33(AreaPrefeb);
                break;
            case "Card 34":
                Card34(AreaPrefeb);
                break;
            case "Card 35":
                Card35(AreaPrefeb);
                break;
            case "Card 36":
                Card36(AreaPrefeb);
                break;
            case "Card 37":
                Card37(AreaPrefeb);
                break;
            case "Card 38":
                Card38(AreaPrefeb);
                break;
            case "Card 39":
                Card39(AreaPrefeb);
                break;
            case "Card 40":
                Card40(AreaPrefeb);
                break;
            case "Card 41":
                Card41(AreaPrefeb);
                break;
            case "Card 42":
                Card42(AreaPrefeb);
                break;
            case "Card 43":
                Card43(AreaPrefeb);
                break;
            case "Card 44":
                Card44(AreaPrefeb);
                break;
            case "Card 45":
                Card45(AreaPrefeb);
                break;
            case "Card 46":
                Card46(AreaPrefeb);
                break;
            case "Card 47":
                Card47(AreaPrefeb);
                break;
            case "Card 48":
                Card48(AreaPrefeb);
                break;
            case "Card 49":
                Card49(AreaPrefeb);
                break;
            case "Card 50":
                Card50(AreaPrefeb);
                break;
            case "Card 51":
                Card51(AreaPrefeb);
                break;
            case "Card 52":
                Card52(AreaPrefeb);
                break;
            case "Card 53":
                Card53(AreaPrefeb);
                break;
            case "Card 54":
                Card54(AreaPrefeb);
                break;
            case "Card 55":
                Card55(AreaPrefeb);
                break;
            case "Card 56":
                Card56(AreaPrefeb);
                break;
            case "Card 57":
                Card57(AreaPrefeb);
                break;
            case "Card 58":
                Card58(AreaPrefeb);
                break;
        }
    }

    private void Card1(GameObject soldier)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card2(GameObject soldier)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 5;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card3(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().BaseAttack += 7;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card4(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().BaseAttack += 10;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card5(GameObject soldier)
    {
        //soldier.GetComponent<SoldierInfo>().BaseAttack += 10;
        //soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card6(GameObject soldier)
    {
        //soldier.GetComponent<SoldierInfo>().Defensive += 2;
        //soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card7(GameObject soldier)
    {
        //soldier.GetComponent<SoldierInfo>().Defensive += 3;
        //soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card8(GameObject soldier)
    {
        //soldier.GetComponent<SoldierInfo>().Defensive += 5;
        //soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card9(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card10(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card11(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card12(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().HelthPoint += 500;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<SoldierInfo>().HelthPoint)
        {
            soldier.GetComponent<SoldierInfo>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card13(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().HelthPoint += 1000;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<SoldierInfo>().HelthPoint)
        {
            soldier.GetComponent<SoldierInfo>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card14(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().HelthPoint += 2000;

        if (soldier.GetComponent<SoldierManger>().totalHp < soldier.GetComponent<SoldierInfo>().HelthPoint)
        {
            soldier.GetComponent<SoldierInfo>().HelthPoint = (int)soldier.GetComponent<SoldierManger>().totalHp;
        }
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card15(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().Movement += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card16(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().Movement += 2;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card17(GameObject soldier)
    {
        soldier.GetComponent<SoldierInfo>().Movement += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card18(GameObject soldier)
    {
        soldier.GetComponent<SoldierManger>().movePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card19(GameObject soldier)
    {
        soldier.GetComponent<SoldierManger>().movePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card20(GameObject soldier)
    {
        soldier.GetComponent<SoldierManger>().movePoint = true;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon(carInfo);
    }

    private void Card21(GameObject soldier)
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -10 합니다.
    }

    private void Card22(GameObject soldier)
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -2 합니다.
    }

    private void Card23(GameObject soldier)
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -3 합니다.
    }

    private void Card24(GameObject enemy)
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -5 합니다.
    }

    private void Card25(GameObject enemy)
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -7 합니다.
    }

    private void Card26(GameObject enemy)
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -10 합니다.
    }

    private void Card27(GameObject enemy)
    {
        //해당 유닛을 가장 가까운 요새 또는 수도로 귀환 시킵니다.
    }

    private void Card28(GameObject area)
    {
        //훈련 검병을 1기 소환합니다.
    }

    private void Card29(GameObject area)
    {
        //훈련 창병을 1기 소환합니다.
    }

    private void Card30(GameObject area)
    {
        //훈련 궁병을 1기 소환합니다.
    }

    private void Card31(GameObject area)
    {
        //훈련 기병을 1기 소환합니다.
    }

    private void Card32(GameObject area)
    {
        //숙련 검병을 1기 소환합니다.
    }

    private void Card33(GameObject area)
    {
        //숙련 창병을 1기 소환합니다.
        
    }

    private void Card34(GameObject area)
    {
        //숙련 궁병을 1기 소환합니다.
    }

    private void Card35(GameObject area)
    {
        area.GetComponent<AreaManger>().player.milk += 50;
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card36(GameObject area)
    {
        //정예 검병을 1기 소환합니다.
    }

    private void Card37(GameObject area)
    {
        //정예 창병을 1기 소환합니다.
    }

    private void Card38(GameObject area)
    {
    }

    private void Card39(GameObject area)
    {
    }

    private void Card40(GameObject area)
    {
        //적의 검병을 1기 소환합니다.
    }

    private void Card41(GameObject area)
    {
        //청의 창병을 1기 소환합니다.
    }

    private void Card42(GameObject area)
    {
        //녹의 궁병을 1기 소환합니다.
    }

    private void Card43(GameObject area)
    {
        //백의 기병을 1기 소환합니다.
    }

    private void Card44(GameObject area)
    {
        //수도를 이전 할 수있습니다.
    }

    private void Card45(GameObject area)
    {
    }

    private void Card46(GameObject area)
    {
        //아군 1부대에 부대 인원 + 500을 추가합니다.
    }

    private void Card47(GameObject area)
    {
        area.GetComponent<AreaManger>().player.milk += (int)(area.GetComponent<AreaManger>().player.milk *0.1f);
        GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
    }

    private void Card48(GameObject area)
    {
        //아군 2부대에 부대 인원 + 1000을 추가합니다.
    }

    private void Card49(GameObject area)
    {
        //아군 1부대에 부대 인원 + 2000을 추가합니다.
    }

    private void Card50(GameObject area)
    {
        //아군 2부대에 부대 인원 + 2000을 추가합니다.
    }

    private void Card51(GameObject area)
    {
        //적군 1부대에 부대 인원 - 500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Card52(GameObject area)
    {
        //적군 1부대에 부대 인원 -1000을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Card53(GameObject area)
    {
        //적군 1부대에 부대 인원 -1500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Card54(GameObject area)
    {
        //적군 1부대에 부대 인원 -2000을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Card55(GameObject area)
    {
        //적군 1부대에 부대 인원 -2500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Card56(GameObject area)
    {
        //1칸을 건너 띌 수 있게 해줍니다.
    }

    private void Card57(GameObject area)
    {

    }

    private void Card58(GameObject area)
    {

    }
}
