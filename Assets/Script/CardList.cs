using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public Transform hitTransform;
    public Sprite carInfo;
    public GameObject SoldierPrefeb;
    public GameObject AreaPrefeb;

    public void FindSkill(string skillCode)
    {

        switch (skillCode)
        {
            case "Skill 1":
                Skill1(hitTransform);
                break;
            case "Skill 2":
                Skill2(hitTransform);
                break;
            case "Skill 3":
                Skill3(hitTransform);
                break;
            case "Skill 4":
                Skill4(hitTransform);
                break;
            case "Skill 5":
                Skill5(hitTransform);
                break;
            case "Skill 6":
                Skill6(hitTransform);
                break;
            case "Skill 7":
                Skill7(hitTransform);
                break;
            case "Skill 8":
                Skill8(hitTransform);
                break;
            case "Skill 9":
                Skill9(hitTransform);
                break;
            case "Skill 10":
                Skill10(hitTransform);
                break;
            case "Skill 11":
                Skill11(hitTransform);
                break;
            case "Skill 12":
                Skill12(hitTransform);
                break;
            case "Skill 13":
                Skill13(hitTransform);
                break;
            case "Skill 14":
                Skill14();
                break;
            case "Skill 15":
                Skill15();
                break;
            case "Skill 16":
                Skill16();
                break;
            case "Skill 17":
                Skill17();
                break;
            case "Skill 18":
                Skill18();
                break;
            case "Skill 19":
                Skill19();
                break;
            case "Skill 20":
                Skill20();
                break;
            case "Skill 21":
                Skill21();
                break;
            case "Skill 22":
                Skill22();
                break;
            case "Skill 23":
                Skill23();
                break;
            case "Skill 24":
                Skill24();
                break;
            case "Skill 25":
                Skill25();
                break;
            case "Skill 26":
                Skill26();
                break;
            case "Skill 27":
                Skill27();
                break;
            case "Skill 28":
                Skill28(hitTransform);
                break;
            case "Skill 29":
                Skill29(hitTransform);
                break;
            case "Skill 30":
                Skill30(hitTransform);
                break;
            case "Skill 31":
                Skill31(hitTransform);
                break;
            case "Skill 32":
                Skill32(hitTransform);
                break;
            case "Skill 33":
                Skill33(hitTransform);
                break;
            case "Skill 34":
                Skill34(hitTransform);
                break;
            case "Skill 35":
                Skill35(hitTransform);
                break;
            case "Skill 36":
                Skill36(hitTransform);
                break;
            case "Skill 37":
                Skill37(hitTransform);
                break;
            case "Skill 38":
                Skill38(hitTransform);
                break;
            case "Skill 39":
                Skill39(hitTransform);
                break;
            case "Skill 40":
                Skill40(hitTransform);
                break;
            case "Skill 41":
                Skill41(hitTransform);
                break;
            case "Skill 42":
                Skill42(hitTransform);
                break;
            case "Skill 43":
                Skill43(hitTransform);
                break;
            case "Skill 44":
                Skill44();
                break;
            case "Skill 45":
                Skill45(hitTransform);
                break;
            case "Skill 46":
                Skill46();
                break;
            case "Skill 47":
                Skill47();
                break;
            case "Skill 48":
                Skill48();
                break;
            case "Skill 49":
                Skill49();
                break;
            case "Skill 50":
                Skill50();
                break;
            case "Skill 51":
                Skill51();
                break;
            case "Skill 52":
                Skill52();
                break;
            case "Skill 53":
                Skill53();
                break;
            case "Skill 54":
                Skill54();
                break;
            case "Skill 55":
                Skill55();
                break;
            case "Skill 56":
                Skill56();
                break;
            case "Skill 57":
                Skill57();
                break;
            case "Skill 58":
                Skill58();
                break;
            case "Skill 59":
                Skill59();
                break;
            case "Skill 60":
                Skill60();
                break;
            case "Skill 61":
                Skill61();
                break;
            case "Skill 62":
                Skill62();
                break;
            case "Skill 63":
                Skill63();
                break;
        }
    }

    private void Skill1(Transform soldier)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 2;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill2(Transform soldier)
    {
        soldier.GetComponent<MakeSoldier>().BaseAttack += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill3(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().BaseAttack += 5;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill4(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().BaseAttack += 7;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill5(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().BaseAttack += 10;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill6(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().Defensive += 2;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill7(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().Defensive += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill8(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().Defensive += 5;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill9(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().Defensive += 7;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill10(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().Defensive += 10;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill11(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 1;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill12(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 2;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill13(Transform soldier)
    {
        soldier.GetComponent<SoldierInfo>().AttackRange += 3;
        soldier.GetComponent<SoldierManger>().MakeBuffIcon();
    }

    private void Skill14()
    {
        //1~2등급 적을 한턴간 공격하지 못하게 합니다.
    }

    private void Skill15()
    {
        //3등급 적을 한 턴간 공격하지 못하게 합니다.
    }

    private void Skill16()
    {
        //4등급 적을 한 턴간 공격하지 못하게 합니다.
    }

    private void Skill17()
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -2 합니다.
    }

    private void Skill18()
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -3 합니다.
    }

    private void Skill19()
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -5 합니다.
    }

    private void Skill20()
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -7 합니다.
    }

    private void Skill21()
    {
        //스킬을 사용한 유닛을 공격 할 때 공격 유닛의 공격력을 -10 합니다.
    }

    private void Skill22()
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -2 합니다.
    }

    private void Skill23()
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -3 합니다.
    }

    private void Skill24()
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -5 합니다.
    }

    private void Skill25()
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -7 합니다.
    }

    private void Skill26()
    {
        //스킬을 사용한 유닛이 적을 공격 할 때 방어 유닛의 방어력을 -10 합니다.
    }

    private void Skill27()
    {
        //해당 유닛을 가장 가까운 요새 또는 수도로 귀환 시킵니다.
    }

    private void Skill28(Transform soldier)
    {
        //훈련 검병을 1기 소환합니다.
    }

    private void Skill29(Transform soldier)
    {
        //훈련 창병을 1기 소환합니다.
    }

    private void Skill30(Transform soldier)
    {
        //훈련 궁병을 1기 소환합니다.
    }

    private void Skill31(Transform soldier)
    {
        //훈련 기병을 1기 소환합니다.
    }

    private void Skill32(Transform soldier)
    {
        //숙련 검병을 1기 소환합니다.
    }

    private void Skill33(Transform soldier)
    {
        //숙련 창병을 1기 소환합니다.
        
    }

    private void Skill34(Transform soldier)
    {
        //숙련 궁병을 1기 소환합니다.
    }

    private void Skill35(Transform soldier)
    {
        //숙련 기병을 1기 소환합니다.
    }

    private void Skill36(Transform soldier)
    {
        //정예 검병을 1기 소환합니다.
    }

    private void Skill37(Transform soldier)
    {
        //정예 창병을 1기 소환합니다.
    }

    private void Skill38(Transform soldier)
    {
    }

    private void Skill39(Transform soldier)
    {
    }

    private void Skill40(Transform soldier)
    {
        //적의 검병을 1기 소환합니다.
    }

    private void Skill41(Transform soldier)
    {
        //청의 창병을 1기 소환합니다.
    }

    private void Skill42(Transform soldier)
    {
        //녹의 궁병을 1기 소환합니다.
    }

    private void Skill43(Transform soldier)
    {
        //백의 기병을 1기 소환합니다.
    }

    private void Skill44()
    {
        //수도를 이전 할 수있습니다.
    }

    private void Skill45(Transform soldier)
    {
        //수도 건설을 할 수 있습니다.
        AreaPrefeb.GetComponent<MakeArea>().findCode = "Area 1";
        Instantiate(AreaPrefeb, soldier);
    }

    private void Skill46()
    {
        //아군 1부대에 부대 인원 + 500을 추가합니다.
    }

    private void Skill47()
    {
        //아군 1부대에 부대 인원 + 1000을 추가합니다.
    }

    private void Skill48()
    {
        //아군 2부대에 부대 인원 + 1000을 추가합니다.
    }

    private void Skill49()
    {
        //아군 1부대에 부대 인원 + 2000을 추가합니다.
    }

    private void Skill50()
    {
        //아군 2부대에 부대 인원 + 2000을 추가합니다.
    }

    private void Skill51()
    {
        //적군 1부대에 부대 인원 - 500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Skill52()
    {
        //적군 1부대에 부대 인원 -1000을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Skill53()
    {
        //적군 1부대에 부대 인원 -1500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Skill54()
    {
        //적군 1부대에 부대 인원 -2000을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Skill55()
    {
        //적군 1부대에 부대 인원 -2500을 합니다. 1등급 100%적용. 2등급 60% 적용,3등급 40% 적용, 4등급 20% 적용
    }

    private void Skill56()
    {
        //1칸을 건너 띌 수 있게 해줍니다.
    }

    private void Skill57()
    {

    }

    private void Skill58()
    {

    }

    private void Skill59()
    {

    }

    private void Skill60()
    {

    }

    private void Skill61()
    {

    }

    private void Skill62()
    {

    }

    private void Skill63()
    {

    }
}
