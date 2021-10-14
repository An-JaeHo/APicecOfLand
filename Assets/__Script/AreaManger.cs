﻿using System.Collections;
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
    public Sprite readyBuild;
    public TileManger tileManger;

    bool turnArea;

    void Awake()
    {
        rangeManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<RangeManger>();
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        //tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        area = GetComponent<MakeArea>();
        buildTurn = 0;
        turnArea = false;

        pureColor = transform.GetComponent<SpriteRenderer>().color;
    }

    public void CheckUpdateMaterial()
    {
        if (transform.tag == "Area")
        {
            switch (area.Code)
            {
                case "Area 1":
                    player.updateMilk += area.MilkOutput;
                    break;
                case "Area 2":
                    player.updateMilk += (area.MilkOutput-5);
                    break;
                case "Area 3":
                    player.updateMilk += (area.MilkOutput-10);
                    break;
                case "Area 4":
                    player.updateMilk += (area.MilkOutput - 15);
                    break;
                case "Area 5":
                    player.updateFlour += area.FlourOutput;
                    break;
                case "Area 6":
                    player.updateFlour += area.FlourOutput-5;
                    break;
                case "Area 7":
                    player.updateFlour += area.FlourOutput - 10;
                    break;
                case "Area 8":
                    player.updateFlour += area.FlourOutput - 15;
                    break;
                case "Area 9":
                    player.updateSugar += area.SugarOutput;
                    break;
                case "Area 10":
                    player.updateSugar += area.SugarOutput-5;
                    break;
                case "Area 11":
                    player.updateSugar += area.SugarOutput-10;
                    break;
                case "Area 12":
                    player.updateSugar += area.SugarOutput-15;
                    break;
                case "Area 20":
                    player.people += area.Population;
                    break;
                case "Area 21":
                    player.people += 1;
                    break;
                case "Area 22":
                    player.people += 1;
                    break;
                case "Area 23":
                    player.people += 1;
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
            case "Area 25":
                Code = "Area 26";
                break;
            case "Area 27":
                Code = "Area 28";
                break;
            case "Area 28":
                Code = "Area 29";
                break;
            case "Area 30":
                Code = "Area 31";
                break;
            case "Area 31":
                Code = "Area 32";
                break;
        }

        return Code;
    }

    public void BuilderDead()
    {
        transform.GetComponent<MakeArea>().Code = pureCode;
        transform.GetComponent<MakeArea>().Type = "Grass";
        transform.GetComponent<MakeArea>().Picture = pureSprite;
        transform.GetComponent<MakeArea>().Grade = 0;
        transform.GetComponent<MakeArea>().UpgradeFlour = 0;
        transform.GetComponent<MakeArea>().UpgradeSugar = 0;
        transform.GetComponent<MakeArea>().MilkOutput = 0;
        transform.GetComponent<MakeArea>().FlourOutput = 0;
        transform.GetComponent<MakeArea>().SugarOutput = 0;
        transform.GetComponent<MakeArea>().Movement = true;
        transform.GetComponent<MakeArea>().Destroy = true;
        transform.GetComponent<MakeArea>().Repair = false;
        transform.GetComponent<MakeArea>().Effect = null;
        transform.GetComponent<SpriteRenderer>().color = Color.white;
        transform.GetComponent<SpriteRenderer>().sprite = pureSprite;
        pureColor = Color.white;
        transform.tag = "Grass";
    }

    public void TurnArea()
    {
        if (transform.tag != "Enemy Base")
        {
            if(transform.tag != "Capital" )
            {
                ReturnUpdateSouce();
                transform.GetComponent<MakeArea>().Code = pureCode;
                transform.GetComponent<MakeArea>().Name = null;
                transform.GetComponent<MakeArea>().Type = "Grass";
                transform.GetComponent<MakeArea>().Picture = pureSprite;
                transform.GetComponent<MakeArea>().Grade = 0;
                transform.GetComponent<MakeArea>().UpgradeFlour = 0;
                transform.GetComponent<MakeArea>().UpgradeSugar = 0;
                transform.GetComponent<MakeArea>().MilkOutput = 0;
                transform.GetComponent<MakeArea>().FlourOutput = 0;
                transform.GetComponent<MakeArea>().SugarOutput = 0;
                transform.GetComponent<MakeArea>().Movement = true;
                transform.GetComponent<MakeArea>().Destroy = true;
                transform.GetComponent<MakeArea>().Repair = false;
                transform.GetComponent<MakeArea>().Effect = null;
                transform.GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetComponent<SpriteRenderer>().sprite = pureSprite;
                pureColor = Color.white;
                transform.tag = "Grass";
            }
        }
        
        if(area.Name == "우주선")
        {
            transform.GetComponent<MakeArea>().Code = pureCode;
            transform.GetComponent<MakeArea>().Name = null;
            transform.GetComponent<MakeArea>().Type = "Grass";
            transform.GetComponent<MakeArea>().Picture = pureSprite;
            transform.GetComponent<MakeArea>().Grade = 0;
            transform.GetComponent<MakeArea>().UpgradeFlour = 0;
            transform.GetComponent<MakeArea>().UpgradeSugar = 0;
            transform.GetComponent<MakeArea>().MilkOutput = 0;
            transform.GetComponent<MakeArea>().FlourOutput = 0;
            transform.GetComponent<MakeArea>().SugarOutput = 0;
            transform.GetComponent<MakeArea>().Movement = true;
            transform.GetComponent<MakeArea>().Destroy = false;
            transform.GetComponent<MakeArea>().Repair = false;
            transform.GetComponent<MakeArea>().Effect = null;
            transform.GetComponent<SpriteRenderer>().color = Color.white;
            transform.GetComponent<SpriteRenderer>().sprite = pureSprite;
            pureColor = Color.white;
            transform.tag = "Grass";
        }
    }

    public void ReturnUpdateSouce()
    {
        if (transform.tag == "Area")
        {
            switch (area.Code)
            {
                case "Area 1":
                    player.updateMilk -= area.MilkOutput;
                    break;
                case "Area 2":
                    player.updateMilk -= area.MilkOutput;
                    break;
                case "Area 3":
                    player.updateMilk -= area.MilkOutput;
                    break;
                case "Area 4":
                    player.updateMilk -= area.MilkOutput;
                    break;
                case "Area 5":
                    player.updateFlour -= area.FlourOutput;
                    break;
                case "Area 6":
                    player.updateFlour -= area.FlourOutput;
                    break;
                case "Area 7":
                    player.updateFlour -= area.FlourOutput;
                    break;
                case "Area 8":
                    player.updateFlour -= area.FlourOutput;
                    break;
                case "Area 9":
                    player.updateSugar -= area.SugarOutput;
                    break;
                case "Area 10":
                    player.updateSugar -= area.SugarOutput;
                    break;
                case "Area 11":
                    player.updateSugar -= area.SugarOutput;
                    break;
                case "Area 12":
                    player.updateSugar -= area.SugarOutput;
                    break;
                case "Area 20":
                    player.people -= area.Population;
                    break;
                case "Area 21":
                    player.people -= area.Population;
                    break;
                case "Area 22":
                    player.people -= area.Population;
                    break;
                case "Area 23":
                    player.people -= area.Population;
                    break;
            }
        }
    }
}