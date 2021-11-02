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

    public void HowMuchProduce()
    {
        makeSoldier = GetComponent<MakeSoldier>();
        need = GameObject.Find("ArmyNeed");
        barrackController = GameObject.FindGameObjectWithTag("Barrack").GetComponent<TutorialBarrackController>();
        barrack = GameObject.FindGameObjectWithTag("Barrack");

        need.transform.GetChild(0).GetComponent<Text>().text = "½Ä·® : " + makeSoldier.ProductionExpense.ToString();
        barrackController.barrackMonsterSprite.gameObject.SetActive(true);
        barrackController.barrackMonsterSprite.GetComponent<Image>().sprite = makeSoldier.Picture;
        barrackController.soldierInfo = makeSoldier;

        int canUsePeople = barrackController.playerInfo.people - barrackController.usingPeople;

        if (barrackController.playerInfo.milk > makeSoldier.ProductionExpense && canUsePeople > 0)
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = false;
        }
    }
}
