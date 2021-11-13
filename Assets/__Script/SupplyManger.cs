using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyManger : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public BarrackController barrackController;

    void Awake()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        JustUpdateSupply();
    }

    public void UpdateSupply()
    {
        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;

        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (playerInfo.updateMilk > 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + playerInfo.updateMilk.ToString();
        }
        else if (playerInfo.updateMilk == 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + playerInfo.updateMilk.ToString();
        }

        if (playerInfo.updateFlour > 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + playerInfo.updateFlour.ToString();
        }
        else if (playerInfo.updateFlour <= 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + playerInfo.updateFlour.ToString();
        }

        if (playerInfo.updateSugar > 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + playerInfo.updateSugar.ToString();
        }
        else if (playerInfo.updateSugar == 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + playerInfo.updateSugar.ToString();
        }
    }

    public void JustUpdateSupply()
    {
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (playerInfo.updateMilk > 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + playerInfo.updateMilk.ToString();
        }
        else if (playerInfo.updateMilk == 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + playerInfo.updateMilk.ToString();
        }

        if (playerInfo.updateFlour > 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + playerInfo.updateFlour.ToString();
        }
        else if (playerInfo.updateFlour <= 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + playerInfo.updateFlour.ToString();
        }

        if (playerInfo.updateSugar > 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + playerInfo.updateSugar.ToString();
        }
        else if (playerInfo.updateSugar == 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + playerInfo.updateSugar.ToString();
        }
    }

    public void TutorialSupply()
    {
        playerInfo.StartGame();

        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (playerInfo.updateMilk > 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + playerInfo.updateMilk.ToString();
        }
        else if (playerInfo.updateMilk == 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + playerInfo.updateMilk.ToString();
        }

        if (playerInfo.updateFlour > 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + playerInfo.updateFlour.ToString();
        }
        else if (playerInfo.updateFlour <= 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + playerInfo.updateFlour.ToString();
        }

        if (playerInfo.updateSugar > 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + playerInfo.updateSugar.ToString();
        }
        else if (playerInfo.updateSugar == 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + playerInfo.updateSugar.ToString();
        }
    }
}
