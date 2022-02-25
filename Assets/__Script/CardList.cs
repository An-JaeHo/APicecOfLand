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
    public bool tutorialCheck;

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
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 10":
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 11":
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange += 1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 12":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<SoldierManger>().totalHp * 0.15f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }

                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                break;
            case "Card 13":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<SoldierManger>().totalHp * 0.30f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }
                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                break;
            case "Card 14":
                SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint += (int)(SoldierPrefeb.GetComponent<SoldierManger>().totalHp * 0.50f);

                if (SoldierPrefeb.GetComponent<SoldierManger>().totalHp < SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint)
                {
                    SoldierPrefeb.GetComponent<MakeSoldier>().HelthPoint = (int)SoldierPrefeb.GetComponent<SoldierManger>().totalHp;
                }
                SoldierPrefeb.GetComponent<SoldierManger>().HpBarScale();
                break;
            case "Card 15":
                SoldierPrefeb.GetComponent<MakeSoldier>().MovementNumber++;

                if(tutorialCheck)
                {
                    SoldierPrefeb.GetComponent<TutorialSoldierManger>().MakeBuffIcon(CardCode);
                }
                else
                {
                    SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                }
                
                break;
            case "Card 16":
                SoldierPrefeb.GetComponent<MakeSoldier>().MovementNumber++;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 17":
                SoldierPrefeb.GetComponent<MakeSoldier>().MovementNumber++;
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
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount++;
                SoldierPrefeb.GetComponent<SoldierManger>().AttachCountNumCheck();
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 22":
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount++;
                SoldierPrefeb.GetComponent<SoldierManger>().AttachCountNumCheck();
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
            case "Card 23":
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount++;
                SoldierPrefeb.GetComponent<SoldierManger>().AttachCountNumCheck();
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
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
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
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
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
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
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
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
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
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
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
                break;
            case "Card 33":
                EnemyPrefeb.GetComponent<EnemyController>().movePoint = false;
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
                break;
            case "Card 34":
                EnemyPrefeb.GetComponent<EnemyController>().movePoint = false;
                EnemyPrefeb.GetComponent<EnemyController>().MakeBuffIcon(CardCode);
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
                if(AreaPrefeb.GetComponent<AreaManger>().player.people<=99)
                {
                    AreaPrefeb.GetComponent<AreaManger>().player.people += 1;
                }
                    
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 45":
                if (AreaPrefeb.GetComponent<AreaManger>().player.people <= 99)
                {
                    AreaPrefeb.GetComponent<AreaManger>().player.people += 2;
                }
                GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>().JustUpdateSupply();
                break;
            case "Card 46":
                if (AreaPrefeb.GetComponent<AreaManger>().player.people <= 99)
                {
                    AreaPrefeb.GetComponent<AreaManger>().player.people += 3;
                }
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

            case "Card 59":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement +=1;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;

            case "Card 60":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 2;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;

            case "Card 61":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement += 3;
                SoldierPrefeb.GetComponent<SoldierManger>().MakeBuffIcon(CardCode);
                break;
        }
    }

    public void RemoveCardEffect(string CardCode)
    {
        switch (CardCode)
        {
            case "Card 1":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack -= 3;
                break;
            case "Card 2":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack -= 5;
                break;
            case "Card 3":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack -= 7;
                break;
            case "Card 4":
                SoldierPrefeb.GetComponent<MakeSoldier>().BaseAttack -= 10;
                break;
            case "Card 5":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive -= 3;
                break;
            case "Card 6":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive -= 5;
                break;
            case "Card 7":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive -= 7;
                break;
            case "Card 8":
                SoldierPrefeb.GetComponent<MakeSoldier>().Defensive -= 10;
                break;
            case "Card 9":
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange -= 1;
                break;
            case "Card 10":
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange -= 1;
                break;
            case "Card 11":
                SoldierPrefeb.GetComponent<MakeSoldier>().AttackRange -= 1;
                break;
            case "Card 15":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement -= 1;
                break;
            case "Card 16":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement -= 2;
                break;
            case "Card 17":
                SoldierPrefeb.GetComponent<MakeSoldier>().Movement -= 3;
                break;
            case "Card 18":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0;
                break;
            case "Card 19":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0;
                break;
            case "Card 20":
                SoldierPrefeb.GetComponent<SoldierManger>().countAttack = 0;
                break;
            case "Card 21":
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount -= 1;
                break;
            case "Card 22":
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount -= 1;
                break;
            case "Card 23":
                SoldierPrefeb.GetComponent<MakeSoldier>().attackCount -= 1;
                break;
            case "Card 24":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive += 3;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive += 3;
                }
                break;
            case "Card 25":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive += 5;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive += 5;
                }
                break;
            case "Card 26":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive += 7;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive += 7;
                }
                break;
            case "Card 27":
                if (EnemyPrefeb.tag == "Enemy")
                {
                    EnemyPrefeb.GetComponent<MakeEnemy>().BaseDefensive += 10;
                }
                else
                {
                    EnemyPrefeb.GetComponent<GDController>().Defensive += 10;
                }
                break;
        }
    }

}
