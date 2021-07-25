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
    public TileManger tileManger;
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
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
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
            GameObject prefebSoldier = Instantiate(soldierPrefeb,new Vector3(land.position.x, land.position.y +25f), Quaternion.identity);
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
        tileManger.CheckTile();
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
                        monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x+60, monsterUi[0].transform.parent.position.y-70);
                    }

                    if (json.information.monster[i].Code == "Mon 4")
                    {
                        monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[1].transform.name = json.information.monster[i].Name;
                        monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 160, monsterUi[0].transform.parent.position.y - 70);
                    }

                    if (json.information.monster[i].Code == "Mon 7")
                    {
                        monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[2].transform.name = json.information.monster[i].Name;
                        monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 260, monsterUi[0].transform.parent.position.y - 70);
                    }

                    if (json.information.monster[i].Code == "Mon 10")
                    {
                        monsterUi[3].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[3].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[3].transform.name = json.information.monster[i].Name;
                        monsterUi[3].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[3].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 360, monsterUi[0].transform.parent.position.y - 70);
                    }

                    if (json.information.monster[i].Code == "Mon 13")
                    {
                        monsterUi[4].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[4].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[4].transform.name = json.information.monster[i].Name;
                        monsterUi[4].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[4].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 460, monsterUi[0].transform.parent.position.y - 70);
                    }

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        monsterUi[5].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monsterUi[5].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monsterUi[5].transform.name = json.information.monster[i].Name;
                        monsterUi[5].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi[5].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 560, monsterUi[0].transform.parent.position.y - 70);
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
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 60 , monster.transform.parent.position.y -70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 4")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 160, monster.transform.parent.position.y - 70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon 7")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 260, monster.transform.parent.position.y - 70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 10")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 360, monster.transform.parent.position.y - 70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon 13")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 460, monster.transform.parent.position.y - 70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                        monster.transform.name = json.information.monster[i].Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 560, monster.transform.parent.position.y - 70);
                        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        monsterUi.Add(monster);
                    }
                }
            }
        }

        myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(420 + (monsterUi.Count - 3) * 230, myContent.GetComponent<RectTransform>().sizeDelta.y);

    }
    #endregion
}
