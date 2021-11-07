using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanalController : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public JsonManger json;
    public Transform baseLand;
    public GameObject parentUi;
    public TutorialButtonManger buttonManger;


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
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
    }

    public void Change()
    {
        GameObject checkButton = GameObject.Find("BulidButton");
        GameObject checkUpgradeMaterial = GameObject.Find("Need");
        GameObject checkOutPut = GameObject.Find("OutPut");
        //BuildImage
        GameObject buildImgae = GameObject.Find("BuildImage");

        checkUpgradeMaterial.transform.GetChild(0).GetComponent<Text>().text = "π–∞°∑Á : " + upgradeWood;
        checkUpgradeMaterial.transform.GetChild(1).GetComponent<Text>().text = "º≥≈¡ : " + upgradeIron;
        checkOutPut.transform.GetChild(0).GetComponent<Text>().text = effect.ToString();
        buildImgae.transform.GetChild(0).GetComponent<Image>().sprite = picture;

        if (playerInfo.flour >= upgradeWood && playerInfo.sugar >= upgradeIron)
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
