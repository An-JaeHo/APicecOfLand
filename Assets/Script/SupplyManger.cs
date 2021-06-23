using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyManger : MonoBehaviour
{
    public PlayerInfo playerInfo;

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
        updateFood = playerInfo.updateFood;
        updateWood = playerInfo.updateWood;
        updateIron = playerInfo.updateIron;
        updatePeople = playerInfo.updatePeople;

        if (updatePeople > 0)
        {
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.people.ToString() + " +" + updatePeople.ToString();
        }
        else if (updatePeople == 0)
        {
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.people.ToString();
        }
        else
        {
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.people.ToString() + " " + updatePeople.ToString();
        }

        if (updateFood > 0)
        {
            transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.food.ToString() + " +" + updateFood.ToString();
        }
        else if (updateFood == 0)
        {
            transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.food.ToString();
        }
        else
        {
            transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.food.ToString() + " " + updateFood.ToString();
        }

        if (updateWood > 0)
        {
            transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.wood.ToString() + " +" + updateWood.ToString();
        }
        else if (updateWood <= 0)
        {
            transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.wood.ToString();
        }
        else
        {
            transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.wood.ToString() + " " + updateWood.ToString();
        }

        if (updateIron > 0)
        {
            transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.iron.ToString() + " +" + updateIron.ToString();
        }
        else if (updateIron == 0)
        {
            transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.iron.ToString();
        }
        else
        {
            transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.iron.ToString() + " " + updateIron.ToString();
        }
    }
}
