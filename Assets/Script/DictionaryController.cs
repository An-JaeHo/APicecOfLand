using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryController : MonoBehaviour
{
    public JsonManger json;
    public List<Monster> armies;
    public List<Area> areas;

    public int armyCount;

    public bool sword;
    public bool spear;
    public bool bow;
    public bool cavalry;
    public string objTag;
    // Start is called before the first frame update
    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        armyCount = 0;
        sword = false;
        spear = false;
        bow = false;
        cavalry = false;

        for (int i =0; i< json.information.monster.Length; i++)
        {
            armies.Add(json.information.monster[i]);
        }

        for (int i = 0; i < json.information.area.Length; i++)
        {
            areas.Add(json.information.area[i]);
        }

        objTag = "Army";
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[armyCount].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].BaseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[armyCount].Defensive.ToString();
        transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseDefensive.ToString();
    }

    public void DictionaryFinder(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Army":
                transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = obj.GetComponent<MakeSoldier>().Picture;
                transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().name;
                transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().pureAttack.ToString();
                transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().RiseAttack.ToString();
                transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().pureDefensive.ToString();
                transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().RiseDefensive.ToString();

                for(int i = 0; i< armies.Count; i++)
                {
                    if(armies[i].Code == obj.GetComponent<MakeSoldier>().Code)
                    {
                        armyCount = i;
                        objTag = "Army";
                    }
                }

                break;
            case "Area":
                transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = obj.GetComponent<MakeArea>().Picture;
                transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeArea>().name;
                transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeArea>().Output.ToString();
                transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeArea>().UpgradeIron.ToString();
                transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeArea>().UpgradeWood.ToString();

                for (int i = 0; i < areas.Count; i++)
                {
                    if (areas[i].Code == obj.GetComponent<MakeArea>().Code)
                    {
                        armyCount = i;
                        objTag = "Area";
                    }
                }

                break;
            case "Enemy":
                
                break;
            default:
                break;
        }
    }

    #region 위 초기 버튼
    public void ChoiceSword()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[0].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[0].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[0].BaseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[0].RiseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[0].Defensive.ToString();
        transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[0].RiseDefensive.ToString();
        armyCount = 0;
        objTag = "Army";
    }

    public void ChoiceSpear()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[1].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[1].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[1].BaseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[1].RiseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[1].Defensive.ToString();
        transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[1].RiseDefensive.ToString();
        armyCount = 1;
        objTag = "Army";
    }

    public void ChoiceBow()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[2].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[2].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[2].BaseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[2].RiseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[2].Defensive.ToString();
        transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[2].RiseDefensive.ToString();
        armyCount = 2;
        objTag = "Army";
    }

    public void ChoiceCavalry()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[3].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[3].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[3].BaseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[3].RiseAttack.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[3].Defensive.ToString();
        transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[3].RiseDefensive.ToString();
        armyCount = 3;
        objTag = "Army";
    }

    public void ChoiceArea()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = areas[0].Picture;
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[0].Name;
        transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[0].Output.ToString();
        transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = areas[0].UpgradeIron.ToString();
        transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = areas[0].UpgradeWood.ToString();
        //transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = areas[0]..ToString();
        armyCount = 0;
        objTag = "Area";
    }
    #endregion

    //+4 하면 종류가 바뀜 16이상부터는 아님
    public void NextObj()
    {
        if(objTag == "Area" )
        {
            armyCount++;

            if (armyCount >= areas.Count)
            {
                armyCount = 0;
            }

            transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = areas[armyCount].Picture;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[armyCount].Name;
            transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[armyCount].Output.ToString();
            transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = areas[armyCount].UpgradeIron.ToString();
            transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = areas[armyCount].UpgradeWood.ToString();
        }
        else
        {
            switch (armyCount)
            {
                case 0:
                    armyCount = 4;
                    break;
                case 1:
                    armyCount = 5;
                    break;
                case 2:
                    armyCount = 6;
                    break;
                case 3:
                    armyCount = 7;
                    break;
                case 4:
                    armyCount = 8;
                    break;
                case 5:
                    armyCount = 9;
                    break;
                case 6:
                    armyCount = 10;
                    break;
                case 7:
                    armyCount = 11;
                    break;
                case 8:
                    armyCount = 12;
                    break;
                case 9:
                    armyCount = 13;
                    break;
                case 10:
                    armyCount = 14;
                    break;
                case 11:
                    armyCount = 15;
                    break;
                case 12:
                    armyCount = 0;
                    break;
                case 13:
                    armyCount = 1;
                    break;
                case 14:
                    armyCount = 2;
                    break;
                case 15:
                    armyCount = 3;
                    break;
            }

            transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[armyCount].Picture;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].Name;
            transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].BaseAttack.ToString();
            transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseAttack.ToString();
            transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[armyCount].Defensive.ToString();
            transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseDefensive.ToString();
        }

        
    }

    public void BeforeObj()
    {
        if (objTag == "Area")
        {
            armyCount--;

            if(armyCount <0)
            {
                armyCount = areas.Count;
            }

            transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = areas[armyCount].Picture;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[armyCount].Name;
            transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = areas[armyCount].Output.ToString();
            transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = areas[armyCount].UpgradeIron.ToString();
            transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = areas[armyCount].UpgradeWood.ToString();
        }
        else
        {
            switch (armyCount)
            {
                case 0:
                    armyCount = 12;
                    break;
                case 1:
                    armyCount = 13;
                    break;
                case 2:
                    armyCount = 14;
                    break;
                case 3:
                    armyCount = 15;
                    break;
                case 4:
                    armyCount = 0;
                    break;
                case 5:
                    armyCount = 1;
                    break;
                case 6:
                    armyCount = 2;
                    break;
                case 7:
                    armyCount = 3;
                    break;
                case 8:
                    armyCount = 4;
                    break;
                case 9:
                    armyCount = 5;
                    break;
                case 10:
                    armyCount = 6;
                    break;
                case 11:
                    armyCount = 7;
                    break;
                case 12:
                    armyCount = 8;
                    break;
                case 13:
                    armyCount = 9;
                    break;
                case 14:
                    armyCount = 10;
                    break;
                case 15:
                    armyCount = 11;
                    break;
            }

            transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = armies[armyCount].Picture;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].Name;
            transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = armies[armyCount].BaseAttack.ToString();
            transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseAttack.ToString();
            transform.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = armies[armyCount].Defensive.ToString();
            transform.GetChild(2).GetChild(1).GetChild(3).GetChild(0).GetComponent<Text>().text = armies[armyCount].RiseDefensive.ToString();
        }
    }

   

    //private void NextObj(string tag)
    //{
    //    switch(tag)
    //    {
    //        case "Sword":

    //            break;
    //        case "Spear":
    //            break;
    //        case "Bow":
    //            break;
    //        case "Cavalry":
    //            break;
    //        case "Area":
    //            break;
    //        default:
    //            break;
    //    }
    //}

}
