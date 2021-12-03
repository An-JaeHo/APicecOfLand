using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHowmuch : MonoBehaviour
{
    public MakeSoldier makeSoldier;
    public GameObject need;
    public GameObject barrack;
    public TutorialBarrackController barrackController;
    public bool talkCheck;
    public TutorialInputManger inputManger;

    void Start()
    {
        talkCheck = true;
    }

    public void HowMuchProduce()
    {
        makeSoldier = GetComponent<MakeSoldier>();
        need = GameObject.Find("ArmyNeed");
        barrackController = GameObject.FindGameObjectWithTag("Barrack").GetComponent<TutorialBarrackController>();
        barrackController.dimmedCover.SetActive(false);
        barrack = GameObject.FindGameObjectWithTag("Barrack");
        inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();

        need.transform.GetChild(0).GetComponent<Text>().text = "½Ä·® : " + makeSoldier.ProductionExpense.ToString();
        barrackController.barrackMonsterSprite.gameObject.SetActive(true);
        barrackController.barrackMonsterSprite.GetComponent<Image>().sprite = makeSoldier.Picture;
        barrackController.soldierInfo = makeSoldier;

        int canUsePeople = barrackController.playerInfo.people - barrackController.usingPeople;

        if (talkCheck)
        {
            inputManger.talkManger.NextScriptButton();
            inputManger.talkManger.talkCheck = true;
            inputManger.talkManger.stopTalkNum = 3;
            talkCheck = false;
        }
    }
}
