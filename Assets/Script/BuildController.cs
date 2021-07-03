using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    //공용
    public JsonManger json;
    public List<GameObject> lands;
    public ButtonManger buttonManger;
    public Transform land;

    //처음 만드는 창
    public GameObject content;
    public GameObject info;
    public Vector3 position;

    //업그레이드를 위한 창
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
        position = content.transform.position;

        if (content.transform.childCount >= 3)
        {
            if (land.GetComponent<AreaManger>().pureTag == "Grass")
            {
                content.transform.GetChild(0).name = "우유";
                content.transform.GetChild(1).name = "밀가루";
                content.transform.GetChild(2).name = "설탕";
                content.transform.GetChild(3).name = "병영";
                content.transform.GetChild(4).name = "집";

                lands.Add(content.transform.GetChild(0).gameObject);
                lands.Add(content.transform.GetChild(1).gameObject);
                lands.Add(content.transform.GetChild(2).gameObject);
                lands.Add(content.transform.GetChild(3).gameObject);
                lands.Add(content.transform.GetChild(4).gameObject);
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
            }
        }

        for (int i =0;i<lands.Count;i++)
        {
            for(int j=0;j< json.information.area.Length;j++)
            {
                if(json.information.area[j].Name == lands[i].transform.name && json.information.area[j].Grade == 1)
                {
                    lands[i].GetComponent<PanelController>().picture= json.information.area[j].Picture;
                    lands[i].GetComponent<PanelController>().name = json.information.area[j].Name;
                    lands[i].GetComponent<PanelController>().code = json.information.area[j].Code;
                    lands[i].GetComponent<PanelController>().effect = json.information.area[j].Effect;
                    lands[i].GetComponent<PanelController>().baseLand = land;
                    lands[i].GetComponent<PanelController>().parentUi = gameObject;
                    lands[i].GetComponent<PanelController>().upgradeWood = json.information.area[j].UpgradeFlour;
                    lands[i].GetComponent<PanelController>().upgradeIron = json.information.area[j].UpgradeSugar;
                    lands[i].transform.GetChild(0).GetComponent<Image>().sprite = json.information.area[j].Picture;

                    lands[i].transform.position = new Vector3(content.transform.parent.position.x + 35 + (i*70), content.transform.parent.position.y - 35);
                    //400 150
                    content.GetComponent<RectTransform>().sizeDelta = new Vector2(350 + (lands.Count-3)*150, content.GetComponent<RectTransform>().sizeDelta.y+ 20);
                }
            }
        }

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
            if(land.GetComponent<MakeArea>().Code == json.information.area[i].Code)
            {
                upgradeLand.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
                upgradeLand.GetChild(3).GetChild(0).GetComponent<Text>().text =  "밀가루 : " + json.information.area[i].UpgradeFlour;
                upgradeLand.GetChild(3).GetChild(1).GetComponent<Text>().text = "설탕 : " + json.information.area[i].UpgradeSugar;
            }

            if(land.GetComponent<AreaManger>().FindNextGrade(land.GetComponent<MakeArea>().Code) == json.information.area[i].Code)
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
        upgradeLand.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = ((land.GetComponent<MakeArea>().Grade+1)*5).ToString();

        gameObject.SetActive(true);

        upgradeLand.GetChild(1).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        buttonManger.UpgradeLand = land;
    }
}
