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
            if(card.Grade ==1)
            {
                oneGradeCard.Add(card);
            }
            else if(card.Grade == 2)
            {
                twoGradeCard.Add(card);
            }
            else if(card.Grade == 3)
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

        if (grade == 1)
        {
            rand = Random.Range(0, oneGradeCard.Count - 1);

            for (int j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j).childCount == 0)
                {
                    GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                    cardInfo.GetComponent<InputSkill>().MakeCard("Skill 1");
                    cardInfo.name = cardInfo.GetComponent<InputSkill>().Code;
                    cardCount++;
                    break;
                }
            }
        }
        else if (grade == 2)
        {
            rand = Random.Range(0, twoGradeCard.Count - 1);

            for (int j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j).childCount == 0)
                {
                    GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                    cardInfo.GetComponent<InputSkill>().MakeCard(twoGradeCard[rand].Code);
                    cardCount++;
                    break;
                }
            }
        }
        else if (grade == 3)
        {
            rand = Random.Range(0, threeGradeCard.Count - 1);

            for (int j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j).childCount == 0)
                {
                    GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                    cardInfo.GetComponent<InputSkill>().MakeCard(threeGradeCard[rand].Code);
                    cardCount++;
                    break;
                }
            }
        }
        else if (grade == 4)
        {
            rand = Random.Range(0, fourGradeCard.Count - 1);

            for (int j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j).childCount == 0)
                {
                    GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                    cardInfo.GetComponent<InputSkill>().MakeCard(fourGradeCard[rand].Code);
                    cardCount++;
                    break;
                }
            }
        }
        else if (grade == 5)
        {
            rand = Random.Range(0, fiveGradeCard.Count - 1);

            for (int j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j).childCount == 0)
                {
                    GameObject cardInfo = Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
                    cardInfo.GetComponent<InputSkill>().MakeCard(fiveGradeCard[rand].Code);
                    cardCount++;
                    break;
                }
            }
        }




        ////iconPrefeb에 빈 카드 컴포넌트를 넣고 정이 것에 적혀잇는 내용을 넣는다
        //for (int j = 0; j < slot.transform.childCount; j++)
        //{
        //    if (slot.transform.GetChild(j).childCount == 0)
        //    {
        //        Instantiate(iconPrefeb, slot.transform.GetChild(j).transform);
        //        cardCount++;
        //        break;
        //    }
        //}

        if(cardCount == 15)
        {
            Debug.Log("더 이상 카드를 넣을수 없습니다");
        }
    }
}