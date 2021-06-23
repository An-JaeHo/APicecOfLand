using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaManger : MonoBehaviour
{
    public RangeManger rangeManger;
    public PlayerInfo player;
    public MakeArea area;
    string Code;
    public string pureCode;
    public Sprite pureSprite;
    public string pureTag;
    public Color pureColor;
    public int buildTurn;

    bool turnArea;

    void Awake()
    {
        rangeManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<RangeManger>();
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        area = GetComponent<MakeArea>();
        buildTurn = 0;
        turnArea = false;

        pureColor = transform.GetComponent<SpriteRenderer>().color;
    }

    private void Start()
    {
        if (transform.tag == "Buliding")
        {
            switch (area.Code)
            {
                case "Area 14":
                    rangeManger.BulidingRange(transform);
                    break;
                case "Area 15":
                    break;
                case "Area 16":
                    break;
                case "Area 17":
                    break;
                case "Area 18":
                    break;
                case "Area 19":
                    break;
                case "Area 20":
                    break;
                case "Area 24":
                    break;
                case "Area 25":
                    break;
            }
        }

    }

    public void CheckUpdateMaterial()
    {
        if (transform.tag == "Area")
        {
            switch (area.Code)
            {
                case "Area 1":
                    player.updateFood += area.Output;
                    break;
                case "Area 2":
                    player.updateFood += 1;
                    break;
                case "Area 3":
                    player.updateFood += 1;
                    break;
                case "Area 4":
                    player.updateFood += 1;
                    break;
                case "Area 5":
                    player.updateWood += area.Output;
                    break;
                case "Area 6":
                    player.updateWood += 1;
                    break;
                case "Area 7":
                    player.updateWood += 1;
                    break;
                case "Area 8":
                    player.updateWood += 1;
                    break;
                case "Area 9":
                    player.updateIron += area.Output;
                    break;
                case "Area 10":
                    player.updateIron += 1;
                    break;
                case "Area 11":
                    player.updateIron += 1;
                    break;
                case "Area 12":
                    player.updateIron += 1;
                    break;
            }
        }
    }

    public void BuffArea()
    {
        if (transform.tag == "Capital" && transform.childCount != 0)
        {
            if (transform.GetChild(0).GetComponent<SoldierManger>().capitalPoint && transform.GetChild(0).tag == "Army")
            {
                transform.GetChild(0).GetComponent<MakeSoldier>().BaseAttack += transform.GetChild(0).GetComponent<MakeSoldier>().BaseAttack * 0.5f;
                transform.GetChild(0).GetComponent<MakeSoldier>().Defensive += transform.GetChild(0).GetComponent<MakeSoldier>().Defensive * 0.5f;
            }
        }

    }

    public string FindNextGrade(string code)
    {
        switch (code)
        {
            case "Area 1":
                Code = "Area 2";
                break;
            case "Area 2":
                Code = "Area 3";
                break;
            case "Area 3":
                Code = "Area 4";
                break;
            case "Area 5":
                Code = "Area 6";
                break;
            case "Area 6":
                Code = "Area 7";
                break;
            case "Area 7":
                Code = "Area 8";
                break;
            case "Area 9":
                Code = "Area 10";
                break;
            case "Area 10":
                Code = "Area 11";
                break;
            case "Area 11":
                Code = "Area 12";
                break;
            case "Area 13":
                Code = "Area 14";
                break;
            case "Area 14":
                Code = "Area 15";
                break;
            case "Area 15":
                Code = "Area 16";
                break;
            case "Area 17":
                Code = "Area 18";
                break;
            case "Area 18":
                Code = "Area 19";
                break;
            case "Area 20":
                Code = "Area 21";
                break;
            case "Area 21":
                Code = "Area 22";
                break;
            case "Area 22":
                Code = "Area 23";
                break;
            case "Area 24":
                Code = "Area 25";
                break;
            case "Area 26":
                Code = "Area 27";
                break;
        }

        return Code;
    }

    public void TurnArea()
    {
        if (transform.tag != "Capital" || transform.tag != "Enemy Base")
        {
            transform.GetComponent<MakeArea>().Code = pureCode;
            transform.GetComponent<MakeArea>().areaInfoImage.sprite = pureSprite;
            transform.GetComponent<MakeArea>().Type = null;
            transform.GetComponent<MakeArea>().Grade = 0;
            transform.GetComponent<MakeArea>().UpgradeWood = 0;
            transform.GetComponent<MakeArea>().UpgradeIron = 0;
            transform.GetComponent<MakeArea>().Health = 0;
            transform.GetComponent<MakeArea>().Output = 0;
            transform.GetComponent<MakeArea>().Movement = false;
            transform.GetComponent<MakeArea>().Destroy = true;
            transform.GetComponent<MakeArea>().Repair = false;
            transform.GetComponent<MakeArea>().Effect = null;
            transform.GetComponent<SpriteRenderer>().sprite = pureSprite;
            transform.tag = tag;
        }
    }
}
