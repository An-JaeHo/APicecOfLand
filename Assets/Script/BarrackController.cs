﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackController : MonoBehaviour
{
    public JsonManger json;
    public GameObject kindofmonster;
    public GameObject parent;
    public List<GameObject> monsterUi;
    public List<GameObject> monsters;
    public MakeSoldier soldierInfo;
    public PlayerInfo playerInfo;
    public GameObject soldierMakeButton;
    public SupplyManger supplyManger;
    public ButtonManger buttonManger;


    //land
    public Transform land;

    //Prefebs
    public GameObject soldierPrefeb;
    public GameObject monsterStateUi;

    //StateUi
    public GameObject uiParentContent;
    public GameObject myContent;
    public int i;

    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        i = 0;
    }

    public void MakeSoldierInPlace()
    {
        if (playerInfo.food > soldierInfo.ProductionExpense)
        {
            GameObject prefebSoldier = Instantiate(soldierPrefeb,land);

            prefebSoldier.GetComponent<MakeSoldier>().SuperMagic(soldierInfo.Code);
            prefebSoldier.name = prefebSoldier.GetComponent<MakeSoldier>().Name;
            prefebSoldier.GetComponent<SpriteRenderer>().sprite = prefebSoldier.GetComponent<MakeSoldier>().Picture;
            playerInfo.updateFood -= prefebSoldier.GetComponent<MakeSoldier>().ConsumeFood;

            monsters.Add(prefebSoldier);
            buttonManger.amrys.Add(prefebSoldier);
            Checkmonster(prefebSoldier.transform);
            supplyManger.UpdateSupply();
            gameObject.SetActive(false);
        }
        else
        {
            //checkButton.GetComponent<Button>().interactable = false;
        }


    }

    public void Checkmonster(Transform name)
    {
        GameObject obj = Instantiate(monsterStateUi, uiParentContent.transform);
        obj.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = name.GetComponent<MakeSoldier>().Picture;
        obj.transform.GetChild(2).GetChild(0).GetComponent<Text>().text= name.GetComponent<MakeSoldier>().Level.ToString();
        obj.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = name.GetComponent<MakeSoldier>().Name.ToString();
        obj.transform.GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = name.GetComponent<MakeSoldier>().HelthPoint*0.01f;
        obj.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = name.GetComponent<MakeSoldier>().ExperiencePoint.ToString();

        obj.transform.position = new Vector3(obj.transform.position.x, (obj.transform.position.y -(i * 80)));

        uiParentContent.GetComponent<RectTransform>().sizeDelta = new Vector2(uiParentContent.GetComponent<RectTransform>().sizeDelta.x, (monsters.Count) * 137);

        i++;
    }

    #region 검사나오는 버튼
    public void SwordButton()
    {
        // 1 5 9 13
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if(json.information.monster[i].Specialities == "Attack")
            {
                if (monsterUi.Count >= 5)
                {
                    if (json.information.monster[i].Code == "Mon1")
                    {
                        monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[0].transform.name = json.information.monster[i].Name;
                        monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x+30, monsterUi[0].transform.parent.position.y-55);
                    }

                    if (json.information.monster[i].Code == "Mon2")
                    {
                        monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[1].transform.name = json.information.monster[i].Name;
                        monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 100, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon3")
                    {
                        monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[2].transform.name = json.information.monster[i].Name;
                        monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 170, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon4")
                    {
                        monsterUi[3].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[3].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[3].transform.name = json.information.monster[i].Name;
                        monsterUi[3].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[3].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 240, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon6")
                    {
                        monsterUi[4].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[4].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[4].transform.name = json.information.monster[i].Name;
                        monsterUi[4].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[4].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 310, monsterUi[0].transform.parent.position.y - 55);
                    }
                }
                else
                {
                    if (json.information.monster[i].Code == "Mon1")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 30 , monster.transform.parent.position.y -55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon2")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 100, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon3")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 170, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon4")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 240, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon6")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 310, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }
                }
            }
        }

        myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(350 + (monsterUi.Count - 3) * 150, myContent.GetComponent<RectTransform>().sizeDelta.y);

    }
    #endregion

    #region 창사 나오는버튼
    public void SpireButton()
    {
        // 2 6 10 14
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if (monsterUi.Count >= 3)
            {
                if (json.information.monster[i].Code == "Troop 2")
                {
                    monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[0].transform.name = json.information.monster[i].Name;
                    monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 40, monsterUi[0].transform.parent.position.y - 55);
                }

                if (json.information.monster[i].Code == "Troop 6")
                {
                    monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[1].transform.name = json.information.monster[i].Name;
                    monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 110, monsterUi[0].transform.parent.position.y - 55);
                }

                if (json.information.monster[i].Code == "Troop 10")
                {
                    monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[2].transform.name = json.information.monster[i].Name;
                    monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 180, monsterUi[0].transform.parent.position.y - 55);
                }
            }
            else
            {
                if (json.information.monster[i].Code == "Troop 2")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 40, monster.transform.parent.position.y - 55);

                    monsterUi.Add(monster);
                }

                if (json.information.monster[i].Code == "Troop 6")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 110, monster.transform.parent.position.y - 55);
                    monsterUi.Add(monster);
                }


                if (json.information.monster[i].Code == "Troop 10")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 180, monster.transform.parent.position.y - 55);
                    monsterUi.Add(monster);
                }
            }
        }

    }
    #endregion

    #region 활쟁이나오는 버튼
    public void BowButton()
    {
        // 3 7 11 15
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if (monsterUi.Count >= 3)
            {
                if (json.information.monster[i].Code == "Troop 3")
                {
                    monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[0].transform.name = json.information.monster[i].Name;
                    monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 40, monsterUi[0].transform.parent.position.y - 55);
                }

                if (json.information.monster[i].Code == "Troop 7")
                {
                    monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[1].transform.name = json.information.monster[i].Name;
                    monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 110, monsterUi[0].transform.parent.position.y - 55);
                }

                if (json.information.monster[i].Code == "Troop 11")
                {
                    monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monsterUi[2].transform.name = json.information.monster[i].Name;
                    monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 180, monsterUi[0].transform.parent.position.y - 55);
                }
            }
            else
            {
                if (json.information.monster[i].Code == "Troop 3")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 40, monster.transform.parent.position.y - 55);

                    monsterUi.Add(monster);
                }

                if (json.information.monster[i].Code == "Troop 7")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 110, monster.transform.parent.position.y - 55);
                    monsterUi.Add(monster);
                }


                if (json.information.monster[i].Code == "Troop 11")
                {
                    GameObject monster = Instantiate(kindofmonster, parent.transform);
                    monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    monster.transform.name = json.information.monster[i].Name;
                    monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    monster.transform.position = new Vector3(monster.transform.parent.position.x + 180, monster.transform.parent.position.y - 55);
                    monsterUi.Add(monster);
                }
            }
        }

    }
    #endregion

    #region 말쟁이 나오는버튼
    public void CavalierButton()
    {
        // +70
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if (json.information.monster[i].Specialities == "Defend")
            {
                if (monsterUi.Count >= 1)
                {
                    if (json.information.monster[i].Code == "Mon5")
                    {
                        monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[0].transform.name = json.information.monster[i].Name;
                        monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 30, monsterUi[0].transform.parent.position.y - 55);
                    }

                    
                }
                else
                {
                    if (json.information.monster[i].Code == "Mon5")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 30, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }
                }
            }
        }

        myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(350 + (monsterUi.Count - 3) * 150, myContent.GetComponent<RectTransform>().sizeDelta.y);

    }
    #endregion
}