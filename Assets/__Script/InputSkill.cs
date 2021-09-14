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
    public InvenManger test;

    public void MakeCard(string code)
    {
        test = GameObject.FindGameObjectWithTag("GameController").GetComponent<InvenManger>();
        skillList = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        card = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardList>();
        image = GetComponent<Image>();
        transform.name = test.cardName;

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
            }  
        }      
    }          
}
