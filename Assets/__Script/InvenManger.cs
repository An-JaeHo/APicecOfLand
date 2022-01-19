﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManger : MonoBehaviour
{
    private Card[] cardInfo;
    public List<Card> oneGradeCard;
    public List<Card> twoGradeCard;
    public List<Card> threeGradeCard;
    public List<Card> fourGradeCard;
    public List<Card> fiveGradeCard;

    public string cardName;
    public GameObject iconPrefeb;
    public GameObject slot;

    public int cardCount;

    private void Start()
    {
        cardInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>().information.card;

        foreach (var card in cardInfo)
        {
            if (card.Grade == 1)
            {
                oneGradeCard.Add(card);
            }
            else if (card.Grade == 2)
            {
                twoGradeCard.Add(card);
            }
            else if (card.Grade == 3)
            {
                threeGradeCard.Add(card);
            }
            else if (card.Grade == 4)
            {
                fourGradeCard.Add(card);
            }
            else if (card.Grade == 5)
            {
                fiveGradeCard.Add(card);
            }
        }
    }

    public void InputCard(int grade)
    {
        int rand = new int();
        string code = null;

        if (grade == 1)
        {
            rand = Random.Range(0, oneGradeCard.Count - 1);

            code = oneGradeCard[rand].Code;
        }
        else if (grade == 2)
        {
            rand = Random.Range(0, twoGradeCard.Count - 1);
            code = twoGradeCard[rand].Code;
        }
        else if (grade == 3)
        {
            rand = Random.Range(0, threeGradeCard.Count - 1);
            code = threeGradeCard[rand].Code;
        }
        else if (grade == 4)
        {
            rand = Random.Range(0, fourGradeCard.Count - 1);
            code = fourGradeCard[rand].Code;
        }

        for (int j = 0; j < slot.transform.childCount; j++)
        {
            if (slot.transform.GetChild(j).childCount != 0)
            {
                if (slot.transform.GetChild(j).GetChild(0).name == "Card 1")
                {
                    if (slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack == 3)
                    {
                        slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().MakeCard(slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().nextCode);
                        slot.transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Picture;

                        SameCardCheck(j);
                    }
                    else
                    {
                        slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack++;
                    }

                    slot.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().text =
                            slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack.ToString();

                    if (slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack == 1)
                    {
                        slot.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.green;
                    }
                    else if (slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack == 2)
                    {
                        slot.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().color =
                            new Color(255f / 255f, 127f / 255f, 0f / 255f);
                    }
                    else if (slot.transform.GetChild(j).GetChild(0).GetComponent<InputSkill>().Stack == 3)
                    {
                        slot.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.red;
                    }
                    break;
                }
                else
                {
                    if (slot.transform.childCount - 1 == j)
                    {
                        SystemMessgeController.SystemMessge("inven");
                    }
                }
            }
            else
            {
                GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                cardInfo.GetComponent<InputSkill>().MakeCard("Card 1");
                cardInfo.name = cardInfo.GetComponent<InputSkill>().Code;
                cardInfo.GetComponent<Image>().sprite = cardInfo.GetComponent<InputSkill>().Picture;
                cardCount++;
                break;
            }
        }
    }

    public void SameCardCheck(int slotNum)
    {
        for (int i = 0; i < slot.transform.childCount; i++)
        {
            if (slot.transform.GetChild(i).childCount != 0)
            {
                if(i != slotNum)
                {
                    if (slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().Code == slot.transform.GetChild(slotNum).GetChild(0).GetComponent<InputSkill>().Code)
                    {
                        if (slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().Stack == 3)
                        {
                            slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().MakeCard(slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().nextCode);
                            slot.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().Picture;
                            SameCardCheck(i);
                        }
                        else
                        {
                            slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().Stack++;
                        }

                        Destroy(slot.transform.GetChild(slotNum).GetChild(0).gameObject);

                        slot.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text =
                            slot.transform.GetChild(i).GetChild(0).GetComponent<InputSkill>().Stack.ToString();
                    }
                }
            }
        }

        
    }
}
