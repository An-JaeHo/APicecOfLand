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

    public void ManySupply()
    {
        playerInfo.milk = 3000;
        playerInfo.flour = 3000;
        playerInfo.sugar = 3000;
        playerInfo.people = 99;
    }


    public void UpdateSupply()
    {
        if (playerInfo.updateMilk >= 1000)
        {
            playerInfo.updateMilk = 1000;
        }

        if (playerInfo.updateFlour >= 1000)
        {
            playerInfo.updateFlour = 1000;
        }

        if (playerInfo.updateSugar >= 1000)
        {
            playerInfo.updateSugar = 1000;
        }

        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;

        if (playerInfo.milk < 0 
            || playerInfo.flour < 0
            || playerInfo.sugar < 0)
        {
            SystemMessgeController.SystemMessge("supply");
        }

        if (playerInfo.milk < -150 
            || playerInfo.flour < -150
            || playerInfo.sugar < -150)
        {
            SceneMgr.GoGameEndScene();
        }

        if (playerInfo.milk >= 3000)
        {
            playerInfo.milk = 3000;
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.green;
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.white;
        }

        if (playerInfo.flour >= 3000)
        {
            playerInfo.flour = 3000;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.green;
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.white;
        }

        if (playerInfo.sugar >= 3000)
        {
            playerInfo.sugar = 3000;
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.green;
        }
        else
        {
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().color = Color.white;
        }

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
        if (playerInfo.updateMilk >= 1000)
        {
            playerInfo.updateMilk = 1000;
        }

        if (playerInfo.updateFlour >= 1000)
        {
            playerInfo.updateFlour = 1000;
        }

        if (playerInfo.updateSugar >= 1000)
        {
            playerInfo.updateSugar = 1000;
        }

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
