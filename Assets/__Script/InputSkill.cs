using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public string Code;
    public Sprite Picture;
    public string Type;
    public string Name;
    public int Grade;
    public int Turn;
    public int AllAttack;
    public int AttackRange;
    public int AttackNumber;
    public int HelthPoint;
    public int Movement;
    public int Milk;
    public int Milk2;
    public int Flour;
    public int Flour2;
    public int Sugar;
    public int Sugar2;
    public int Population;
    public int CountAttack;
    public int Stack;
}

public class InputSkill : CardInfo
{
    public JsonManger skillList;
    public CardList card;
    public Image image;
    public string nextCode;
    public int maxGrade ;

    private void Start()
    {
        maxGrade = 0;
    }

    public void MakeCard(string code)
    {
        skillList = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        card = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardList>();
        image = GetComponent<Image>();

        for (int i = 0; i < skillList.information.card.Length; i++)
        {
            if (skillList.information.card[i].Code == code)
            {
                Code = skillList.information.card[i].Code;
                Picture = skillList.information.card[i].Picture;
                Type = skillList.information.card[i].Type;
                Name = skillList.information.card[i].Name;
                Grade = skillList.information.card[i].Grade;
                Turn = skillList.information.card[i].Turn;
                AllAttack = skillList.information.card[i].AllAttack;
                AttackRange = skillList.information.card[i].AttackRange;
                AttackNumber = skillList.information.card[i].AttackNumber;
                HelthPoint = skillList.information.card[i].HelthPoint;
                Movement = skillList.information.card[i].Movement;
                Milk = skillList.information.card[i].Milk;
                Milk2 = skillList.information.card[i].Milk2;
                Flour = skillList.information.card[i].Flour;
                Flour2 = skillList.information.card[i].Flour2;
                Sugar = skillList.information.card[i].Sugar;
                Sugar2 = skillList.information.card[i].Sugar2;
                Population = skillList.information.card[i].Population;
                CountAttack = skillList.information.card[i].CountAttack;
                Stack = skillList.information.card[i].Stack;

                if (Grade != maxGrade)
                {
                    nextCode = FindNextCode(Code);
                }
            }
        }
    }

    public string FindNextCode(string code)
    {
        switch (code)
        {
            case "Card 1":
                maxGrade = 4;
                return "Card 2";
            case "Card 2":
                maxGrade = 4;
                return "Card 3";
            case "Card 3":
                maxGrade = 4;
                return "Card 4";
            case "Card 5":
                maxGrade = 4;
                return "Card 6";
            case "Card 6":
                maxGrade = 4;
                return "Card 7";
            case "Card 7":
                maxGrade = 4;
                return "Card 8";
            case "Card 9":
                maxGrade = 3;
                return "Card 10";
            case "Card 10":
                maxGrade = 3;
                return "Card 11";
            case "Card 12":
                maxGrade = 3;
                return "Card 13";
            case "Card 13":
                maxGrade = 3;
                return "Card 14";
            case "Card 15":
                maxGrade = 3;
                return "Card 16";
            case "Card 16":
                maxGrade = 3;
                return "Card 17";
            case "Card 18":
                maxGrade = 3;
                return "Card 19";
            case "Card 19":
                maxGrade = 3;
                return "Card 20";
            case "Card 21":
                maxGrade = 3;
                return "Card 22";
            case "Card 22":
                maxGrade = 3;
                return "Card 23";
            case "Card 24":
                maxGrade = 4;
                return "Card 25";
            case "Card 25":
                maxGrade = 4;
                return "Card 26";
            case "Card 26":
                maxGrade = 4;
                return "Card 27";
            case "Card 28":
                maxGrade = 4;
                return "Card 29";
            case "Card 29":
                maxGrade = 4;
                return "Card 30";
            case "Card 30":
                maxGrade = 4;
                return "Card 31";
            case "Card 32":
                maxGrade = 3;
                return "Card 33";
            case "Card 33":
                maxGrade = 3;
                return "Card 34";
            case "Card 35":
                maxGrade = 3;
                return "Card 36";
            case "Card 36":
                maxGrade = 3;
                return "Card 37";
            case "Card 38":
                maxGrade = 3;
                return "Card 39";
            case "Card 39":
                maxGrade = 3;
                return "Card 40";
            case "Card 41":
                maxGrade = 3;
                return "Card 42";
            case "Card 42":
                maxGrade = 3;
                return "Card 43";
            case "Card 44":
                maxGrade = 3;
                return "Card 45";
            case "Card 45":
                maxGrade = 3;
                return "Card 46";
            case "Card 47":
                maxGrade = 4;
                return "Card 47";
            case "Card 48":
                maxGrade = 4;
                return "Card 48";
            case "Card 49":
                maxGrade = 4;
                return "Card 49";
            case "Card 50":
                maxGrade = 4;
                return "Card 50";
            case "Card 51":
                maxGrade = 4;
                return "Card 51";
            case "Card 52":
                maxGrade = 4;
                return "Card 52";
            case "Card 53":
                maxGrade = 4;
                return "Card 53";
            case "Card 54":
                maxGrade = 4;
                return "Card 54";
            case "Card 55":
                maxGrade = 4;
                return "Card 55";
            case "Card 56":
                maxGrade = 4;
                return "Card 56";
            case "Card 57":
                maxGrade = 4;
                return "Card 57";
            case "Card 58":
                maxGrade = 4;
                return "Card 58";
        }

        return "null";
    }
}

        


