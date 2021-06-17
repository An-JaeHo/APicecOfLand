using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hwomuch : MonoBehaviour
{
    public MakeSoldier makeSoldier;
    public GameObject need;
    public BarrackController barrackController;

    public void HowMuchProduce()
    {
        makeSoldier = GetComponent<MakeSoldier>();
        need = GameObject.Find("ArmyNeed");
        barrackController = GameObject.FindGameObjectWithTag("Barrack").GetComponent<BarrackController>();

        need.transform.GetChild(0).GetComponent<Text>().text = "식량 : "+makeSoldier.ProductionExpense.ToString();
        barrackController.soldierInfo = makeSoldier;

        if (barrackController.playerInfo.food > barrackController.soldierInfo.ProductionExpense)
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            barrackController.soldierMakeButton.GetComponent<Button>().interactable = false;
        }
    }
}
