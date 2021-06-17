using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                image.sprite = Picture;
                Name = skillList.information.card[i].Name;
                Grade = skillList.information.card[i].Grade;
                Kind = skillList.information.card[i].Kind;
                Acquisition = skillList.information.card[i].Acquisition;
                Effect = skillList.information.card[i].Effect;
                Superposition = skillList.information.card[i].Superposition;
                MaxStack = skillList.information.card[i].MaxStack;
            }
        }
    }
}
