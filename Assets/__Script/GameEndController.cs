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
    public GameObject addButton;
    public int sumPoint;
    public int killingPoint;
    public int turnPoint;
    private bool supplyCheck;
    private int pureMilkSupply;
    private int pureFlourSupply;
    private int pureSugarSupply;
    private int sumMilkSupply;
    private int sumFlourSupply;
    private int sumSugarSupply;
    private float times;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        supplyCheck = false;
        CheckPoint();
        CheckRank();
        ResulttGame();
        BonusCheck();
    }

    private void Update()
    {
        if (supplyCheck)
        {
            times += Time.deltaTime;

            supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ((int)Mathf.Lerp(pureMilkSupply, sumMilkSupply, times / 3)).ToString();
            supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ((int)Mathf.Lerp(pureSugarSupply, sumSugarSupply, times / 3)).ToString();
            supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = ((int)Mathf.Lerp(pureFlourSupply, sumFlourSupply, times / 3)).ToString();

            for (int i = 0; i < bonuses.Length; i++)
            {
                bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().enabled = false;
                bonuses[i].transform.GetChild(1).GetComponent<Button>().enabled = false;
            }

            if (times / 3 >= 1)
            {
                if(sumPoint >= 12)
                {
                    for (int i = 0; i < bonuses.Length; i++)
                    {
                        bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().enabled = true;
                        bonuses[i].transform.GetChild(1).GetComponent<Button>().enabled = true;
                    }
                }

                supplyCheck = false;
                saveMgr.playerSave.milk = sumMilkSupply;
                saveMgr.playerSave.sugar = sumFlourSupply;
                saveMgr.playerSave.flour = sumSugarSupply;
            }
        }
        else
        {
            times = 0;
        }
    }

    public void CheckRank()
    {
        sumPoint = killingPoint + turnPoint;

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
        else if (20 < sumPoint)
        {
            rankImage.GetComponent<Image>().sprite = rankSprites[9];
        }


    }

    private void CheckPoint()
    {
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        //ео
        if (playerInfo.turnPoint <= 15)
        {
            turnPoint = 0;
        }
        else if (15 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 30)
        {
            turnPoint = 1;

        }
        else if (30 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 50)
        {
            turnPoint = 2;
        }
        else if (50 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 80)
        {
            turnPoint = 3;
        }
        else if (80 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 110)
        {
            turnPoint = 5;
        }
        else if (110 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 130)
        {
            turnPoint = 6;
        }
        else if (130 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 150)
        {
            turnPoint = 8;
        }
        else if (150 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 170)
        {
            turnPoint = 8;
        }
        else if (170 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 180)
        {
            turnPoint = 10;
        }
        else if (180 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 190)
        {
            turnPoint = 11;
        }
        else if (190 < playerInfo.turnPoint
           && playerInfo.turnPoint <= 200)
        {
            turnPoint = 12;
        }
        else if (200 < playerInfo.turnPoint)
        {
            turnPoint = 22;
        }

        //еЁ
        if (playerInfo.killingPoint <= 10)
        {
            killingPoint = 0;
        }
        else if (10 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 20)
        {
            killingPoint = 1;
        }
        else if (20 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 30)
        {
            killingPoint = 2;
        }
        else if (30 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 40)
        {
            killingPoint = 3;
        }
        else if (40 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 60)
        {
            killingPoint = 4;
        }
        else if (60 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 80)
        {
            killingPoint = 5;
        }
        else if (80 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 100)
        {
            killingPoint = 6;
        }
        else if (100 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 130)
        {
            killingPoint = 7;
        }
        else if (130 < playerInfo.killingPoint
            && playerInfo.killingPoint <= 200)
        {
            killingPoint = 8;
        }
        else if (200 == playerInfo.killingPoint)
        {
            killingPoint = 22;
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

        pureMilkSupply = saveMgr.playerSave.milk;
        pureSugarSupply = saveMgr.playerSave.sugar;
        pureFlourSupply = saveMgr.playerSave.flour;

        sumMilkSupply = saveMgr.playerSave.milk + (int)(playerInfo.milk * percentage);
        sumSugarSupply = saveMgr.playerSave.sugar + (int)(playerInfo.sugar * percentage);
        sumFlourSupply = saveMgr.playerSave.flour + (int)(playerInfo.flour * percentage);
        supplyCheck = true;
    }

    private void TestButton()
    {
        int rand = Random.Range(5, 21);
        sumPoint = rand;

        //CheckPoint();
        CheckRank();
        ResulttGame();
        BonusCheck();
    }

    private void ResetGame()
    {
        saveMgr.Save();
        playerInfo.ResetGame();
    }

    private void BonusCheck()
    {
        for (int i = 0; i < bonuses.Length; i++)
        {
            if (sumPoint >= 12)
            {
                bonuses[i].SetActive(true);
                bonuses[i].GetComponent<BonusCardController>().RandomSupply();
                bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Image>().sprite = bonuses[i].GetComponent<BonusCardController>().BonusImage;
                bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().enabled = true;
                bonuses[i].transform.GetChild(1).GetComponent<Button>().enabled = true;
                addButton.GetComponent<Button>().enabled = true;
                addButton.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            }
            else
            {
                bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Image>().sprite = bonuses[i].GetComponent<BonusCardController>().noBonusImage;
                addButton.GetComponent<Button>().enabled = false;
                addButton.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 155f / 255f);
                bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().enabled = false;
                bonuses[i].transform.GetChild(1).GetComponent<Button>().enabled = false;
            }
        }
    }
}