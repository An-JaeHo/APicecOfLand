using System.Collections;
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
    public BuildController buildController;
    

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
        buildController = GameObject.Find("BuildUI").GetComponent<BuildController>();
    }

    public void Change()
    {
        GameObject checkButton = GameObject.Find("BulidButton");
        GameObject checkUpgradeMaterial = GameObject.Find("Need");
        GameObject checkOutPut = GameObject.Find("OutPut");
        GameObject buildImgae = GameObject.Find("BuildImage");

        checkUpgradeMaterial.transform.GetChild(0).GetComponent<Text>().text = "필요 밀가루 : " + upgradeWood;
        checkUpgradeMaterial.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = buildController.flourUI;
        checkUpgradeMaterial.transform.GetChild(1).GetComponent<Text>().text = "필요 설탕 : " + upgradeIron;
        checkUpgradeMaterial.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buildController.sugarUI;

        checkOutPut.transform.GetChild(0).GetComponent<Text>().text = effect.ToString();
        checkOutPut.transform.GetChild(1).GetComponent<Image>().sprite = CheckEffetToName();
        buildImgae.transform.GetChild(0).GetComponent<Image>().sprite = picture;

        if (playerInfo.flour >= upgradeWood && playerInfo.sugar>= upgradeIron)
        {
            checkButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            checkButton.GetComponent<Button>().interactable = false;
        }

        buttonManger.CreateAreaPrefab = gameObject;
    }

    private Sprite CheckEffetToName()
    {
        if (name == "우유")
        {
            return buildController.milkUI;
        }
        else if (name == "밀가루")
        {
            return buildController.flourUI;
        }
        else if (name == "설탕")
        {
            return buildController.sugarUI;
        }
        else if (name == "병영")
        {
            return buildController.mosterUI;
        }
        else if (name == "집")
        {
            return buildController.peopleUI;
        }
        else if (name == "치료소")
        {
            return buildController.mosterUI;
        }
        else
        {
            return null;
        }

    }
}
