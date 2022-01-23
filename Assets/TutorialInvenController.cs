using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInvenController : MonoBehaviour
{
    [Header("Supply Icon GameObject")]
    public Image monsterTurnImage;

    [Header("Make Card Obj")]
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

        for (int j = 0; j < slot.transform.childCount; j++)
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
