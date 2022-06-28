using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    [Header("Common Build Obj")]
    public JsonManger json;
    public List<GameObject> lands;
    public ButtonManger buttonManger;
    public Transform land;
    public GameObject content;
    public GameObject info;


    [Header("UpGradeBuild Obj")]
    public MakeArea makeArea;
    public int nowPoint;
    public int futurePoint;
    public Transform upgradeLand;
    public Button upGradeButton;
    public GameObject nextProduction;
    public GameObject upGradeResouce;

    [Header("Build Icon")]
    public Sprite milkUI;
    public Sprite flourUI;
    public Sprite sugarUI;
    public Sprite mosterUI;
    public Sprite peopleUI;


    void Start()
    {
        lands = new List<GameObject>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
    }

    public void CreateWindow()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        content.transform.localPosition = new Vector3(-0f, -220f);

        if (content.transform.childCount !=0)
        {
            if (land.GetComponent<AreaManger>().pureTag == "Grass")
            {
                content.transform.GetChild(0).name = "우유";
                content.transform.GetChild(1).name = "밀가루";
                content.transform.GetChild(2).name = "설탕";
                content.transform.GetChild(3).name = "병영";
                content.transform.GetChild(4).name = "집";
                content.transform.GetChild(5).name = "치료소";

                lands.Add(content.transform.GetChild(0).gameObject);
                lands.Add(content.transform.GetChild(1).gameObject);
                lands.Add(content.transform.GetChild(2).gameObject);
                lands.Add(content.transform.GetChild(3).gameObject);
                lands.Add(content.transform.GetChild(4).gameObject);
                lands.Add(content.transform.GetChild(5).gameObject);
            }
        }
        else
        {
            if (land.GetComponent<AreaManger>().pureTag == "Grass")
            {
                GameObject foodInfo = Instantiate(info, content.transform);
                foodInfo.transform.name = "우유";
                lands.Add(foodInfo);

                GameObject ironInfo = Instantiate(info, content.transform);
                ironInfo.transform.name = "밀가루";
                lands.Add(ironInfo);

                GameObject woodInfo = Instantiate(info, content.transform);
                woodInfo.transform.name = "설탕";
                lands.Add(woodInfo);

                GameObject barrackInfo = Instantiate(info, content.transform);
                barrackInfo.transform.name = "병영";
                lands.Add(barrackInfo);

                GameObject houseInfo = Instantiate(info, content.transform);
                houseInfo.transform.name = "집";
                lands.Add(houseInfo);

                GameObject clinicInfo = Instantiate(info, content.transform);
                clinicInfo.transform.name = "치료소";
                lands.Add(clinicInfo);
            }
        }

        for (int i =0;i<lands.Count;i++)
        {
            for (int j=0;j< json.information.area.Length;j++)
            {
                if (json.information.area[j].Name == lands[i].transform.name && json.information.area[j].Grade == 1)
                {
                    lands[i].GetComponent<PanelController>().picture= json.information.area[j].Picture;
                    lands[i].GetComponent<PanelController>().name = json.information.area[j].Name;
                    lands[i].GetComponent<PanelController>().code = json.information.area[j].Code;
                    lands[i].GetComponent<PanelController>().effect = json.information.area[j].Effect;
                    lands[i].GetComponent<PanelController>().baseLand = land;
                    
                    lands[i].GetComponent<PanelController>().parentUi = gameObject;
                    lands[i].GetComponent<PanelController>().upgradeWood = json.information.area[j].BaseFlour;
                    lands[i].GetComponent<PanelController>().upgradeIron = json.information.area[j].BaseSugar;
                    lands[i].transform.GetChild(0).GetComponent<Image>().sprite = json.information.area[j].Picture;

                    lands[i].transform.localPosition = new Vector3(100 + (i*170), 100);
                    //400 150
                    content.GetComponent<RectTransform>().sizeDelta = new Vector2(450 + (lands.Count-3)*200, content.GetComponent<RectTransform>().sizeDelta.y);
                }
            }
        }

        lands.Clear();
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Text>().text = "필요한 밀가루";
        transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<Text>().text = "필요한 설탕";
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
                upGradeResouce.transform.GetChild(0).GetComponent<Text>().text = " 필요 밀가루 : "+json.information.area[i].UpgradeFlour.ToString();
                upGradeResouce.transform.GetChild(1).GetComponent<Text>().text = " 필요 설탕 : " + json.information.area[i].UpgradeSugar.ToString();

                upGradeResouce.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = CheckEffetToName("밀가루");
                upGradeResouce.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = CheckEffetToName("설탕");

            }

            if (land.GetComponent<AreaManger>().FindNextGrade(land.GetComponent<MakeArea>().Code) == json.information.area[i].Code)
            {
                upgradeLand.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
                nextProduction.transform.GetChild(0).GetComponent<Text>().text = json.information.area[i].Effect;
                nextProduction.transform.GetChild(1).GetComponent<Image>().sprite = CheckEffetToName(json.information.area[i].Name);
            }
        }

        gameObject.SetActive(true);

        if (buttonManger.playerInfo.flour >= buttonManger.UpgradeLand.GetComponent<MakeArea>().UpgradeFlour && buttonManger.playerInfo.sugar >= buttonManger.UpgradeLand.GetComponent<MakeArea>().UpgradeSugar &&
            buttonManger.UpgradeLand.GetComponent<MakeArea>().Grade != buttonManger.UpgradeLand.GetComponent<MakeArea>().maxGrade)
        {
            upGradeButton.interactable = true;
        }
        else
        {
            upGradeButton.interactable = false;
        }

        upgradeLand.GetChild(1).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        buttonManger.UpgradeLand = land;
    }

    private Sprite CheckEffetToName(string name)
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
