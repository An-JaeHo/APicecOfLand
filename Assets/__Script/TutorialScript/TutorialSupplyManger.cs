using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSupplyManger : MonoBehaviour
{
    [Header("Set in Inspector")]
    public TutorialBarrackController barrackController;

    [Header("Supply Ui")]
    public GameObject milkUi;
    public GameObject flourUi;
    public GameObject sugarUi;
    public GameObject peopleUi;

    [Header("Set in VisualStuido")]
    public PlayerInfo playerInfo;
    public int updateFood;
    public int updateWood;
    public int updateIron;
    public int updatePeople;

    void Awake()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
    }

    public void UpdateSupply()
    {
        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;

        peopleUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (playerInfo.updateMilk > 0)
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + playerInfo.updateMilk.ToString();
        }
        else if (playerInfo.updateMilk == 0)
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + playerInfo.updateMilk.ToString();
        }

        if (playerInfo.updateFlour > 0)
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + playerInfo.updateFlour.ToString();
        }
        else if (playerInfo.updateFlour <= 0)
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + playerInfo.updateFlour.ToString();
        }

        if (playerInfo.updateSugar > 0)
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + playerInfo.updateSugar.ToString();
        }
        else if (playerInfo.updateSugar == 0)
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + playerInfo.updateSugar.ToString();
        }
    }

    public void JustUpdateSupply()
    {
        peopleUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (playerInfo.updateMilk > 0)
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + playerInfo.updateMilk.ToString();
        }
        else if (playerInfo.updateMilk == 0)
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            milkUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + playerInfo.updateMilk.ToString();
        }

        if (playerInfo.updateFlour > 0)
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + playerInfo.updateFlour.ToString();
        }
        else if (playerInfo.updateFlour <= 0)
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            flourUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + playerInfo.updateFlour.ToString();
        }

        if (playerInfo.updateSugar > 0)
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + playerInfo.updateSugar.ToString();
        }
        else if (playerInfo.updateSugar == 0)
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            sugarUi.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + playerInfo.updateSugar.ToString();
        }
    }
}