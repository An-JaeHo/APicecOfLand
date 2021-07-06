using System.Collections;
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
    public InputManger inputManger;

    public GameObject[] MonsterObj;

    public int usingPeople;

    //land
    public Transform land;

    //Prefebs
    public GameObject soldierPrefeb;

    //StateUi
    public GameObject myContent;
    public int i;

    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManger>();
        i = 0;
        usingPeople = 0;
        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];
        for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }
    }

    public void MakeSoldierInPlace()
    {
        if (playerInfo.milk > soldierInfo.ProductionExpense)
        {
            GameObject prefebSoldier = Instantiate(soldierPrefeb,new Vector3(land.position.x +10f, land.position.y +25f), Quaternion.identity);
            prefebSoldier.transform.SetParent(land);

            prefebSoldier.GetComponent<MakeSoldier>().SuperMagic(soldierInfo.Code);
            playerInfo.updateMilk -= prefebSoldier.GetComponent<MakeSoldier>().ConsumeFood;

            for (int i = 0; i < MonsterObj.Length; i++)
            {
                if (MonsterObj[i].name == prefebSoldier.GetComponent<MakeSoldier>().Code)
                {
                    GameObject monsterPicture = Instantiate(MonsterObj[i], new Vector3(prefebSoldier.transform.position.x, prefebSoldier.transform.position.y - 55), Quaternion.identity);
                    monsterPicture.transform.SetParent(prefebSoldier.transform);
                }
            }

            monsters.Add(prefebSoldier);
            buttonManger.amrys.Add(prefebSoldier);
            usingPeople++;
            supplyManger.UpdateSupply();
            gameObject.SetActive(false);
        }

        inputManger.mouseCheck = true;
    }

    #region 검사나오는 버튼
    public void SwordButton()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        // 1 5 9 13
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if(json.information.monster[i].Specialities == "Unit")
            {
                if (monsterUi.Count >= 6)
                {
                    if (json.information.monster[i].Code == "Mon 1")
                    {
                        monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[0].transform.name = json.information.monster[i].Name;
                        monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x+40, monsterUi[0].transform.parent.position.y-55);
                    }

                    if (json.information.monster[i].Code == "Mon 4")
                    {
                        monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[1].transform.name = json.information.monster[i].Name;
                        monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 120, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon 7")
                    {
                        monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[2].transform.name = json.information.monster[i].Name;
                        monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 200, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon 10")
                    {
                        monsterUi[3].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[3].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[3].transform.name = json.information.monster[i].Name;
                        monsterUi[3].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[3].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 280, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon 13")
                    {
                        monsterUi[4].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[4].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[4].transform.name = json.information.monster[i].Name;
                        monsterUi[4].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[4].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 360, monsterUi[0].transform.parent.position.y - 55);
                    }

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        monsterUi[5].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[5].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[5].transform.name = json.information.monster[i].Name;
                        monsterUi[5].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[5].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 440, monsterUi[0].transform.parent.position.y - 55);
                    }
                }
                else
                {
                    if (json.information.monster[i].Code == "Mon 1")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 40 , monster.transform.parent.position.y -55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 4")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 120, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon 7")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 200, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 10")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 280, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon 13")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 360, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 440, monster.transform.parent.position.y - 55);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }
                }
            }
        }

        myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(420 + (monsterUi.Count - 3) * 150, myContent.GetComponent<RectTransform>().sizeDelta.y);

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
