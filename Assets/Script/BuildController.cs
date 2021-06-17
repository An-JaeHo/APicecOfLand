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
            if (land.GetComponent<AreaManger>().pureTag== "Grass")
            {
                content.transform.GetChild(0).name = "농지1";
                content.transform.GetChild(1).name = "병영1";
                content.transform.GetChild(2).name = "민가1";

                lands.Add(content.transform.GetChild(0).gameObject);
                lands.Add(content.transform.GetChild(1).gameObject);
                lands.Add(content.transform.GetChild(2).gameObject);
            }
            else if (land.GetComponent<AreaManger>().pureTag == "Stone")
            {
                content.transform.GetChild(0).name = "채석장 1";
                content.transform.GetChild(1).name = "병영1";
                content.transform.GetChild(2).name = "민가1";

                lands.Add(content.transform.GetChild(0).gameObject);
                lands.Add(content.transform.GetChild(1).gameObject);
                lands.Add(content.transform.GetChild(2).gameObject);
            }
            else if (land.GetComponent<AreaManger>().pureTag == "Wood")
            {
                content.transform.GetChild(0).name = "벌목장 1";
                content.transform.GetChild(1).name = "병영1";
                content.transform.GetChild(2).name = "민가1";

                lands.Add(content.transform.GetChild(0).gameObject);
                lands.Add(content.transform.GetChild(1).gameObject);
                lands.Add(content.transform.GetChild(2).gameObject);
            }
        }
        else
        {
            if (land.GetComponent<AreaManger>().pureTag == "Grass")
            {
                GameObject testinfo = Instantiate(info, content.transform);
                testinfo.transform.name = "농지1";

                GameObject ftestinfo = Instantiate(info, content.transform);
                ftestinfo.transform.name = "병영1";

                GameObject htestinfo = Instantiate(info, content.transform);
                htestinfo.transform.name = "민가1";

                lands.Add(testinfo);
                lands.Add(ftestinfo);
                lands.Add(htestinfo);
            }
            else if (land.GetComponent<AreaManger>().pureTag == "Stone")
            {
                GameObject testinfo = Instantiate(info, content.transform);
                testinfo.transform.name = "채석장 1";

                GameObject ftestinfo = Instantiate(info, content.transform);
                ftestinfo.transform.name = "병영1";

                GameObject htestinfo = Instantiate(info, content.transform);
                htestinfo.transform.name = "민가1";

                lands.Add(testinfo);
                lands.Add(ftestinfo);
                lands.Add(htestinfo);

            }
            else if (land.GetComponent<AreaManger>().pureTag == "Wood")
            {
                GameObject testinfo = Instantiate(info, content.transform);
                testinfo.transform.name = "벌목장 1";

                GameObject ftestinfo = Instantiate(info, content.transform);
                ftestinfo.transform.name = "병영1";

                GameObject htestinfo = Instantiate(info, content.transform);
                htestinfo.transform.name = "민가1";

                lands.Add(testinfo);
                lands.Add(ftestinfo);
                lands.Add(htestinfo);
            }
        }

        for(int i =0;i<lands.Count;i++)
        {
            for(int j=0;j< json.information.area.Length;j++)
            {
                if(json.information.area[j].Name == lands[i].transform.name)
                {
                    lands[i].GetComponent<PanelController>().picture= json.information.area[j].Picture;
                    lands[i].GetComponent<PanelController>().name = json.information.area[j].Name;
                    lands[i].GetComponent<PanelController>().code = json.information.area[j].Code;
                    lands[i].GetComponent<PanelController>().effect = json.information.area[j].Effect;
                    lands[i].GetComponent<PanelController>().baseLand = land;
                    lands[i].GetComponent<PanelController>().parentUi = gameObject;
                    lands[i].GetComponent<PanelController>().upgradeWood = json.information.area[j].UpgradeWood;
                    lands[i].GetComponent<PanelController>().upgradeIron = json.information.area[j].UpgradeIron;
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
                transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
                transform.GetChild(3).GetChild(2).GetComponent<Text>().text =  "나무 : " + json.information.area[i].UpgradeWood;
                transform.GetChild(3).GetChild(3).GetComponent<Text>().text = "철 : " + json.information.area[i].UpgradeIron;
            }

            if(land.GetComponent<AreaManger>().FindNextGrade(land.GetComponent<MakeArea>().Code) == json.information.area[i].Code)
            {
                transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = json.information.area[i].Picture;
            }
        }

        if (makeArea.Repair)
        {
            transform.GetChild(5).GetComponent<Button>().interactable = true;
        }
        else
        {
            transform.GetChild(5).GetComponent<Button>().interactable = false;
        }
        transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = nowPoint.ToString();
        transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = (nowPoint+5).ToString();

        gameObject.SetActive(true);

        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = land.GetComponent<SpriteRenderer>().sprite;
        buttonManger.UpgradeLand = land;
        //buttonManger.buildUi = gameObject;
    }
}
