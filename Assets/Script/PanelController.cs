﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public JsonManger json;
    public Transform baseLand;
    public GameObject parentUi;
    public ButtonManger buttonManger;
    

    public Sprite picture;
    public string name;
    public string code;
    public string effect;
    public int upgradeWood;
    public int upgradeIron;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
    }

    public void Change()
    {
        GameObject checkButton = GameObject.Find("BulidButton");
        GameObject checkUpgradeMaterial = GameObject.Find("Need");
        GameObject checkOutPut = GameObject.Find("OutPut");
        //BuildImage
        GameObject buildImgae = GameObject.Find("BuildImage");

        checkUpgradeMaterial.transform.GetChild(2).GetComponent<Text>().text = "목재 : " + upgradeWood;
        checkUpgradeMaterial.transform.GetChild(3).GetComponent<Text>().text = "석재 : " + upgradeIron;
        checkOutPut.transform.GetChild(1).GetComponent<Text>().text = effect.ToString();
        buildImgae.transform.GetChild(0).GetComponent<Image>().sprite = picture;

        if (playerInfo.wood > upgradeWood && playerInfo.iron > upgradeIron)
        {
            checkButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            checkButton.GetComponent<Button>().interactable = false;
        }

        buttonManger.CreateAreaPrefab = gameObject;
    }
}