using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBuildController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public TutorialTalkManger talkManger;
    public GameObject content;
    public GameObject info;

    [Header("Set in ViusalStudio")]
    public JsonManger json;
    public List<GameObject> lands;
    public ButtonManger buttonManger;
    public Transform land;
    public GameObject dimmedCover;
    public Vector3 position;
    public MakeArea makeArea;
    public int nowPoint;
    public int futurePoint;
    public Transform upgradeLand;


    void Start()
    {
        lands = new List<GameObject>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
    }

    public void CreateWindow()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        content.transform.localPosition = new Vector3(-0f, -220f);

        if (content.transform.childCount >= 1)
        {
            if (talkManger.buildCheck)
            {
                if (land.GetComponent<AreaManger>().pureTag == "Grass")
                {
                    GameObject barrackInfo = Instantiate(info, content.transform);
                    barrackInfo.transform.name = "우유";
                    //HighLightObjController.HighLight(barrackInfo);
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<HighLightObjController>().StartHighLightObj();
                    lands.Add(barrackInfo);
                }
            }
            else
            {
                if (land.GetComponent<AreaManger>().pureTag == "Grass")
                {
                    GameObject barrackInfo = Instantiate(info, content.transform);
                    barrackInfo.transform.name = "병영";
                    //HighLightObjController.HighLight(barrackInfo);
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<HighLightObjController>().StartHighLightObj();
                    lands.Add(barrackInfo);
                }
            }
        }
        else
        {
            if(talkManger.buildCheck)
            {
                if (land.GetComponent<AreaManger>().pureTag == "Grass")
                {
                    GameObject barrackInfo = Instantiate(info, content.transform);
                    barrackInfo.transform.name = "우유";
                    //HighLightObjController.HighLight(barrackInfo);
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<HighLightObjController>().StartHighLightObj();
                    lands.Add(barrackInfo);
                }
            }
            else
            {
                if (land.GetComponent<AreaManger>().pureTag == "Grass")
                {
                    GameObject barrackInfo = Instantiate(info, content.transform);
                    barrackInfo.transform.name = "병영";
                    //HighLightObjController.HighLight(barrackInfo);
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<HighLightObjController>().StartHighLightObj();
                    lands.Add(barrackInfo);
                }
            }
        }

        for (int i = 0; i < lands.Count; i++)
        {
            for (int j = 0; j < json.information.area.Length; j++)
            {
                if (json.information.area[j].Name == lands[i].transform.name && json.information.area[j].Grade == 1)
                {
                    lands[i].GetComponent<TutorialPanalController>().picture = json.information.area[j].Picture;
                    lands[i].GetComponent<TutorialPanalController>().name = json.information.area[j].Name;
                    lands[i].GetComponent<TutorialPanalController>().code = json.information.area[j].Code;
                    lands[i].GetComponent<TutorialPanalController>().effect = json.information.area[j].Effect;
                    lands[i].GetComponent<TutorialPanalController>().baseLand = land;
                    lands[i].GetComponent<TutorialPanalController>().parentUi = gameObject;
                    lands[i].GetComponent<TutorialPanalController>().upgradeWood = json.information.area[j].UpgradeFlour;
                    lands[i].GetComponent<TutorialPanalController>().upgradeIron = json.information.area[j].UpgradeSugar;
                    lands[i].transform.GetChild(0).GetComponent<Image>().sprite = json.information.area[j].Picture;

                    lands[i].transform.localPosition = new Vector3(100 + (i * 170), 100);
                    //400 150
                    content.GetComponent<RectTransform>().sizeDelta = new Vector2(450 + (lands.Count - 3) * 190, content.GetComponent<RectTransform>().sizeDelta.y + 20);
                }
            }
        }

        talkManger.outPutUi.transform.GetChild(0).GetComponent<Text>().text = "생산량";
        talkManger.consumeUi.transform.GetChild(0).GetComponent<Text>().text = "필요한 밀가루";
        talkManger.consumeUi.transform.GetChild(1).GetComponent<Text>().text = "필요한 밀가루";
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        lands.Clear();
        gameObject.SetActive(true);
    }

    public void ReadAreaInfo()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        makeArea = land.GetComponent<MakeArea>();

        for (int i = 0; i < json.information.area.Length; i++)
        {
            if (land.GetComponent<MakeArea>().Code == json.information.area[i].Code)
            {
                upgradeLand.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
                upgradeLand.GetChild(3).GetChild(0).GetComponent<Text>().text = "밀가루 : " + json.information.area[i].UpgradeFlour;
                upgradeLand.GetChild(3).GetChild(1).GetComponent<Text>().text = "설탕 : " + json.information.area[i].UpgradeSugar;
            }

            if (land.GetComponent<AreaManger>().FindNextGrade(land.GetComponent<MakeArea>().Code) == json.information.area[i].Code)
            {
                upgradeLand.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
            }
        }

        if (makeArea.Repair)
        {
            upgradeLand.GetChild(5).GetComponent<Button>().interactable = true;
        }
        else
        {
            upgradeLand.GetChild(5).GetComponent<Button>().interactable = false;
        }

        upgradeLand.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = (land.GetComponent<MakeArea>().Grade * 5).ToString();
        upgradeLand.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = ((land.GetComponent<MakeArea>().Grade + 1) * 5).ToString();

        gameObject.SetActive(true);

        upgradeLand.GetChild(1).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        buttonManger.UpgradeLand = land;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<HighLightObjController>().StopHighLightObj();
    }
}
