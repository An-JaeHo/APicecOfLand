using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    [Header("Save")]
    public PlayerInfo playerInfo;
    public GameObject supply;
    public List<Sprite> rankSprites;
    public GameObject rankImage;
    public SaveMgr saveMgr;

    [Header("Bonus Obj")]
    public GameObject[] bonuses;
    int sumPoint;
    int killingPoint;
    int turnPoint;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        CheckPoint();
        CheckRank();
        ResulttGame();
        //BonusCheck();
    }

    public void CheckRank()
    {
        //sumPoint = killingPoint + turnPoint;

        if (sumPoint <= 3)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[0];
        }
        else if (3 < sumPoint
            && sumPoint <= 4)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[1];
        }
        else if (4 < sumPoint
            && sumPoint <= 6)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[2];
        }
        else if (6 < sumPoint
            && sumPoint <= 8)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[3];
        }
        else if (8 < sumPoint
            && sumPoint <= 12)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[4];
        }
        else if (12 < sumPoint
            && sumPoint <= 14)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[5];
        }
        else if (14 < sumPoint
            && sumPoint <= 16)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[6];
        }
        else if (16 < sumPoint
            && sumPoint <= 18)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[7];
        }
        else if (18 < sumPoint
            && sumPoint <= 20)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[8];
        }
    }

    private void CheckPoint()
    {
        int playerkillPoint = playerInfo.killingPoint;
        int playerturnPoit = playerInfo.turnPoint;
        //턴
        if (playerturnPoit <= 15)
        {
            turnPoint = 0;
        }
        else if (15 < playerturnPoit
           && playerturnPoit <= 30)
        {
            turnPoint = 1;
        }
        else if (30 < playerturnPoit
           && playerturnPoit <= 80)
        {
            turnPoint = 2;
        }
        else if (80 < playerturnPoit
           && playerturnPoit <= 110)
        {
            turnPoint = 3;
        }
        else if (110 < playerturnPoit
           && playerturnPoit <= 130)
        {
            turnPoint = 4;
        }
        else if (130 < playerturnPoit
           && playerturnPoit <= 150)
        {
            turnPoint = 5;
        }
        else if (150 < playerturnPoit
           && playerturnPoit <= 170)
        {
            turnPoint = 6;
        }
        else if (170 < playerturnPoit
           && playerturnPoit <= 180)
        {
            turnPoint = 7;
        }
        else if (180 < playerturnPoit
           && playerturnPoit <= 190)
        {
            turnPoint = 8;
        }
        else if (190 < playerturnPoit
           && playerturnPoit <= 200)
        {
            turnPoint = 10;
        }

        //킬
        if (playerkillPoint <= 10)
        {
            killingPoint = 0;
        }
        else if (10 < playerkillPoint
            && playerkillPoint <= 20)
        {
            killingPoint = 1;
        }
        else if (20 < playerkillPoint
            && playerkillPoint <= 30)
        {
            killingPoint = 2;
        }
        else if (30 < playerkillPoint
            && playerkillPoint <= 40)
        {
            killingPoint = 3;
        }
        else if (40 < playerkillPoint
            && playerkillPoint <= 60)
        {
            killingPoint = 4;
        }
        else if (60 < playerkillPoint
            && playerkillPoint <= 80)
        {
            killingPoint = 5;
        }
        else if (80 < playerkillPoint
            && playerkillPoint <= 100)
        {
            killingPoint = 6;
        }
        else if (100 < playerkillPoint
            && playerkillPoint <= 130)
        {
            killingPoint = 7;
        }
        else if (130 < playerkillPoint
            && playerkillPoint <= 200)
        {
            killingPoint = 8;
        }
        else if (200 < playerkillPoint)
        {
            //s랭크? ss랭크?
            //killingPoint = 9;
        }
    }

    private void ResulttGame()
    {
        float percentage = new float();

        switch (rankImage.GetComponent<Image>().sprite.name)
        {
            case "FAIL":
                percentage = 0f;
                break;
            case "F":
                percentage = 0.01f;
                break;
            case "E":
                percentage = 0.03f;
                break;
            case "D":
                percentage = 0.05f;
                break;
            case "C":
                percentage = 0.1f;
                break;
            case "B":
                percentage = 0.15f;
                break;
            case "A":
                percentage = 0.2f;
                break;
            case "A+":
                percentage = 0.3f;
                break;
            case "S":
                percentage = 0.4f;
                break;
            case "SS":
                percentage = 0.5f;
                break;
            default:
                break;
        }

        if (playerInfo.milk > 0)
        {
            saveMgr.playerSave.milk += (int)(playerInfo.milk * percentage);
        }

        if (playerInfo.sugar > 0)
        {
            saveMgr.playerSave.sugar += (int)(playerInfo.sugar * percentage);
        }

        if (playerInfo.flour > 0)
        {
            saveMgr.playerSave.flour += (int)(playerInfo.flour * percentage);
        }

        supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.milk.ToString();
        supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.sugar.ToString();
        supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.flour.ToString();
    }

    private void ResetGame()
    {
        saveMgr.Save();
        playerInfo.ResetGame();
    }

    private void TestButton()
    {
        int rand = Random.Range(5, 21);
        sumPoint = rand;

        CheckRank();
        ResulttGame();
        BonusCheck();
    }

    private void BonusCheck()
    {
        for (int i = 0; i < bonuses.Length; i++)
        {
            if (sumPoint >= 12)
            {
                bonuses[i].SetActive(true);
                bonuses[i].GetComponent<BonusCardController>().RandomSupply();
            }
            else
            {
                //나중에 OTL나오면 적용할 예정
                bonuses[i].SetActive(false);
            }
        }

    }
}