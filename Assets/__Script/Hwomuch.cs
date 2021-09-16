using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hwomuch : MonoBehaviour
{
    public MakeSoldier makeSoldier;
    public GameObject need;
    public GameObject barrack;
    public BarrackController barrackController;

    public void HowMuchProduce()
    {
        makeSoldier = GetComponent<MakeSoldier>();
        need = GameObject.Find("ArmyNeed");
        barrackController = GameObject.FindGameObjectWithTag("Barrack").GetComponent<BarrackController>();
        barrack = GameObject.FindGameObjectWithTag("Barrack");

        need.transform.GetChild(0).GetComponent<Text>().text = "식량 : "+makeSoldier.ProductionExpense.ToString();
        barrackController.barrackMonsterSprite.gameObject.SetActive(true);
        barrackController.barrackMonsterSprite.GetComponent<Image>().sprite = makeSoldier.Picture;

        int canUsePeople = barrackController.playerInfo.people - barrackController.usingPeople;

        if (barrackController.playerInfo.milk > makeSoldier.ProductionExpense && canUsePeople >0)
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = false;
        }
    }
}
