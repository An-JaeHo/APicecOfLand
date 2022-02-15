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
    public TutorialInputManger inputManger ;
    public bool talkCheck;

    public Sprite picture;
    public string name;
    public string code;
    public string effect;
    public int upgradeWood;
    public int upgradeIron;

    public Sprite flourUI;
    public Sprite sugarUI;
    public Sprite milkUI;
    public Sprite peopleUI;
    public Sprite mosterUI;

    private void Start()
    {
        talkCheck = true;
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
    }

    public void Change()
    {
        GameObject checkButton = GameObject.Find("BulidButton");
        GameObject checkUpgradeMaterial = GameObject.Find("Need");
        GameObject checkOutPut = GameObject.Find("OutPut");
        //BuildImage
        GameObject buildImgae = GameObject.Find("BuildImage");

        checkUpgradeMaterial.transform.GetChild(0).GetComponent<Text>().text = "필요 밀가루 : " + upgradeWood;
        checkUpgradeMaterial.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = flourUI;
        checkUpgradeMaterial.transform.GetChild(1).GetComponent<Text>().text = "필요 설탕 : " + upgradeIron;
        checkUpgradeMaterial.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = sugarUI;

        checkOutPut.transform.GetChild(0).GetComponent<Text>().text = effect.ToString();
        checkOutPut.transform.GetChild(1).GetComponent<Image>().sprite = CheckEffetToName();
        buildImgae.transform.GetChild(0).GetComponent<Image>().sprite = picture;

        
        if (talkCheck && inputManger.talkManger.buildCheck)
        {
            inputManger.talkManger.stopTalkNum = 4;
            inputManger.talkManger.talkCheck = true;
            inputManger.talkManger.NextScriptButton();
            inputManger.talkManger.areaUi.transform.SetSiblingIndex(3);
            inputManger.talkManger.outPutUi.transform.SetAsLastSibling();
            talkCheck = false;
        }




        buttonManger.CreateAreaPrefab = gameObject;
    }

    private Sprite CheckEffetToName()
    {
        if (name == "우유")
        {
            return milkUI;
        }
        else if (name == "밀가루")
        {
            return flourUI;
        }
        else if (name == "설탕")
        {
            return sugarUI;
        }
        else if (name == "병영")
        {
            return mosterUI;
        }
        else if (name == "집")
        {
            return peopleUI;
        }
        else if (name == "치료소")
        {
            return mosterUI;
        }
        else
        {
            return null;
        }

    }
}
