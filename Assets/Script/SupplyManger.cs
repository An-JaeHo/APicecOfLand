using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyManger : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public BarrackController barrackController;

    public int updateFood;
    public int updateWood;
    public int updateIron;
    public int updatePeople;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        UpdateSupply();
    }

    public void UpdateSupply()
    {
        updateFood = playerInfo.updateMilk;
        updateWood = playerInfo.updateFlour;
        updateIron = playerInfo.updateSugar;

        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (updateFood > 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + updateFood.ToString();
        }
        else if (updateFood == 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + updateFood.ToString();
        }

        if (updateWood > 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + updateWood.ToString();
        }
        else if (updateWood <= 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + updateWood.ToString();
        }

        if (updateIron > 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + updateIron.ToString();
        }
        else if (updateIron == 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + updateIron.ToString();
        }
    }

    public void JustUpdateSupply()
    {
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = barrackController.usingPeople.ToString() + " / " + playerInfo.people.ToString();

        if (updateFood > 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " +" + updateFood.ToString();
        }
        else if (updateFood == 0)
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString() + " " + updateFood.ToString();
        }

        if (updateWood > 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " +" + updateWood.ToString();
        }
        else if (updateWood <= 0)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString() + " " + updateWood.ToString();
        }

        if (updateIron > 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " +" + updateIron.ToString();
        }
        else if (updateIron == 0)
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString() + " " + updateIron.ToString();
        }
    }
}
