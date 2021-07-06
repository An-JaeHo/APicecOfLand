using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    public PlayerInfo playerInfo;
    int killingPoint;
    int turnPoint;
    public Text text;
    public GameObject supply;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        CheckPoint();
        CheckRank();
        ResulttGame();
    }

    public void CheckRank()
    {
        int sumPoint = killingPoint + turnPoint;
        text = GameObject.Find("Rank").transform.GetChild(0).GetComponent<Text>();


        if (sumPoint < 3)
        {
            text.text= "Fail";
        }
        else if (sumPoint <= 4)
        {
            text.text = "F";
        }
        else if (sumPoint <= 5)
        {
            text.text = "E";
        }
        else if (sumPoint <= 7)
        {
            text.text = "D";
        }
        else if (sumPoint <= 9)
        {
            text.text = "C";
        }
        else if (sumPoint <= 11)
        {
            text.text = "B";
        }
        else if (sumPoint <= 15)
        {
            text.text = "A";
        }
        else if (sumPoint <= 17)
        {
            text.text = "A+";
        }
        else if (sumPoint > 17)
        {
            text.text = "S";
        }
        else if (sumPoint >= 27)
        {
            text.text = "SS";
        }
    }

    public void CheckPoint()
    {
        int playerkillPoint = playerInfo.killingPoint;
        int playerturnPoit = playerInfo.turnPoint;
        //ео
        if (playerturnPoit < 30)
        {
            turnPoint = 0;
        }
        else if(playerturnPoit <= 50)
        {
            turnPoint = 1;
        }
        else if (playerturnPoit <= 80)
        {
            turnPoint = 2;
        }
        else if (playerturnPoit <= 110)
        {
            turnPoint = 3;
        }
        else if (playerturnPoit <= 130)
        {
            turnPoint = 4;
        }
        else if (playerturnPoit <= 150)
        {
            turnPoint = 5;
        }
        else if (playerturnPoit <= 170)
        {
            turnPoint = 6;
        }
        else if (playerturnPoit <= 180)
        {
            turnPoint = 7;
        }
        else if (playerturnPoit <= 190)
        {
            turnPoint = 8;
        }
        else if (playerturnPoit <= 200)
        {
            turnPoint = 10;
        }

        //еЁ
        if (playerkillPoint < 10)
        {
            killingPoint = 0;
        }
        else if (playerkillPoint <= 30)
        {
            killingPoint = 1;
        }
        else if (playerkillPoint <= 50)
        {
            killingPoint = 2;
        }
        else if (playerkillPoint <= 80)
        {
            killingPoint = 3;
        }
        else if (playerkillPoint <= 110)
        {
            killingPoint = 4;
        }
        else if (playerkillPoint <= 130)
        {
            killingPoint = 5;
        }
        else if (playerkillPoint <= 150)
        {
            killingPoint = 6;
        }
        else if (playerkillPoint <= 170)
        {
            killingPoint = 7;
        }
        else if (playerkillPoint <= 190)
        {
            killingPoint = 8;
        }
        else if (playerkillPoint <= 210)
        {
            killingPoint = 9;
        }
        else if (playerkillPoint <= 250)
        {
            killingPoint = 10;
        }
        else if (playerkillPoint > 250)
        {
            killingPoint = 17;
        }
    }

    public void ResulttGame()
    {
        supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
        supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
    }

    public void ResetGame()
    {
        playerInfo.ResetGame();
    }
}
