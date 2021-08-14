using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public SaveMgr saveMgr;

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
            LevelCheck(prefebSoldier);
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
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();

        // 1 5 9 13
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if (json.information.monster[i].Specialities == "Unit")
            {
                if (monsterUi.Count >= 6)
                {
                    //if (json.information.monster[i].Code == "Mon 1")
                    //{
                    //    monsterUi[0].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[0].transform.name = json.information.monster[i].Name;
                    //    monsterUi[0].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[0].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 60, monsterUi[0].transform.parent.position.y - 70);
                    //}

                    //if (json.information.monster[i].Code == "Mon 4")
                    //{
                    //    monsterUi[1].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[1].transform.name = json.information.monster[i].Name;
                    //    monsterUi[1].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[1].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 150, monsterUi[0].transform.parent.position.y - 70);
                    //}

                    //if (json.information.monster[i].Code == "Mon 7")
                    //{
                    //    monsterUi[2].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[2].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[2].transform.name = json.information.monster[i].Name;
                    //    monsterUi[2].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[2].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 240, monsterUi[0].transform.parent.position.y - 70);
                    //}

                    //if (json.information.monster[i].Code == "Mon 10")
                    //{
                    //    monsterUi[3].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[3].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[3].transform.name = json.information.monster[i].Name;
                    //    monsterUi[3].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[3].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 330, monsterUi[0].transform.parent.position.y - 70);
                    //}

                    //if (json.information.monster[i].Code == "Mon 13")
                    //{
                    //    monsterUi[4].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[4].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[4].transform.name = json.information.monster[i].Name;
                    //    monsterUi[4].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[4].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 420, monsterUi[0].transform.parent.position.y - 70);
                    //}

                    //if (json.information.monster[i].Code == "Mon 16")
                    //{
                    //    monsterUi[5].transform.GetChild(0).GetComponent<Image>().sprite = json.information.monster[i].Picture;
                    //    monsterUi[5].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.monster[i].Name;
                    //    monsterUi[5].transform.name = json.information.monster[i].Name;
                    //    monsterUi[5].GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    monsterUi[5].transform.position = new Vector3(monsterUi[0].transform.parent.position.x + 510, monsterUi[0].transform.parent.position.y - 70);
                    //}
                }
                else
                {
                    if (json.information.monster[i].Code == "Mon 1")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.cherryGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.cherryGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 2");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 3");
                        }

                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 60, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 4")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.candyGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.candyGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 5");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 6");
                        }
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 150, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 7")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.skittlesGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.skittlesGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 8");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 9");
                        }
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 240, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 10")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.donutsGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.donutsGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 11");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 12");
                        }
                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 330, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }


                    if (json.information.monster[i].Code == "Mon 13")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.schneeballenGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.schneeballenGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 14");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 15");
                        }

                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 420, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.chocoGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                        }
                        else if (saveMgr.playerSave.chocoGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 17");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                        }

                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 510, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);
                    }
                }

                myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(420 + (monsterUi.Count - 3) * 200, myContent.GetComponent<RectTransform>().sizeDelta.y);
            }
        }
    }
    #endregion

    public void LevelCheck(GameObject Monster)
    {
        switch (Monster.GetComponent<MakeSoldier>().Name)
        {
            case "체리머핀":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.cherryLevel;
                break;
            case "사탕막대":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.candyLevel;
                break;
            case "스키틀즈케이크":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.skittlesLevel;
                break;
            case "도넛츠":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.donutsLevel;
                break;
            case "슈니발렌":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.schneeballenLevel;
                break;
            case "초코칩쿠키":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.chocoLevel;
                break;
            default:
                break;
        }

        Monster.GetComponent<MakeSoldier>().BaseAttack += Monster.GetComponent<MakeSoldier>().RiseAttack * (Monster.GetComponent<MakeSoldier>().Level-1);
        Monster.GetComponent<MakeSoldier>().Defensive += Monster.GetComponent<MakeSoldier>().RiseDefensive * (Monster.GetComponent<MakeSoldier>().Level - 1);
        Monster.GetComponent<MakeSoldier>().HelthPoint += Monster.GetComponent<MakeSoldier>().HelthPoint;
        Monster.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = Monster.GetComponent<MakeSoldier>().Level.ToString();
    }
}
