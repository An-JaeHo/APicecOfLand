using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialBarrackController : MonoBehaviour
{
    public JsonManger json;
    public GameObject kindofmonster;
    public GameObject parent;
    public List<GameObject> monsterUi;
    public List<GameObject> monsters;
    public MakeSoldier soldierInfo;
    public PlayerInfo playerInfo;
    public GameObject soldierMakeButton;
    public GameObject[] MonsterObj;
    public int usingPeople;
    public GameObject dimmedCover;

    //Æ©Åä¸®¾óÀü¿ë
    public TutorialSupplyManger supplyManger;
    public TutorialButtonManger buttonManger;
    public TutorialInputManger inputManger;

    //land
    public Transform land;

    //Prefebs
    public GameObject soldierPrefeb;
    public SaveMgr saveMgr;

    //StateUi
    public GameObject myContent;
    public Sprite barrackSprite;
    public Transform barrackMonsterSprite;
    public int i;

    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<TutorialSupplyManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
        transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = barrackSprite;
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
            GameObject prefebSoldier = Instantiate(soldierPrefeb, new Vector3(land.position.x, land.position.y + 25f), Quaternion.identity);
            prefebSoldier.transform.SetParent(land);
            prefebSoldier.GetComponent<MakeSoldier>().SuperMagic(soldierInfo.Code);
            SaveLevelCheck(prefebSoldier);
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
            usingPeople++;
            supplyManger.UpdateSupply();
            barrackMonsterSprite.gameObject.SetActive(false);
            gameObject.SetActive(false);
            inputManger.talkManger.MoveTalk();
            inputManger.talkManger.talkCheck = true;
            inputManger.talkManger.stopTalkNum = 1;
            inputManger.ChangeLandInfo();
        }

        inputManger.mouseCheck = true;
    }

    #region °Ë»ç³ª¿À´Â ¹öÆ°
    public void SwordButton()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = barrackSprite;

        // 1 5 9 13
        for (int i = 0; i < json.information.monster.Length; i++)
        {
            if (json.information.monster[i].Specialities == "Unit")
            {
                if (monsterUi.Count >= 6)
                {

                }
                else
                {
                    //if (json.information.monster[i].Code == "Mon 1")
                    //{
                    //    GameObject monster = Instantiate(kindofmonster, parent.transform);

                    //    if (saveMgr.playerSave.SaveCherryGrade == 1)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    }
                    //    else if (saveMgr.playerSave.SaveCherryGrade == 2)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 2");
                    //    }
                    //    else
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 3");
                    //    }

                    //    monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                    //    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.position = new Vector3(monster.transform.parent.position.x + 60, monster.transform.parent.position.y - 70);
                    //    monsterUi.Add(monster);
                    //}

                    //if (json.information.monster[i].Code == "Mon 4")
                    //{
                    //    GameObject monster = Instantiate(kindofmonster, parent.transform);

                    //    if (saveMgr.playerSave.SaveCandyGrade == 1)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    }
                    //    else if (saveMgr.playerSave.SaveCandyGrade == 2)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 5");
                    //    }
                    //    else
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 6");
                    //    }
                    //    monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                    //    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.position = new Vector3(monster.transform.parent.position.x + 150, monster.transform.parent.position.y - 70);
                    //    monsterUi.Add(monster);
                    //}

                    //if (json.information.monster[i].Code == "Mon 7")
                    //{
                    //    GameObject monster = Instantiate(kindofmonster, parent.transform);

                    //    if (saveMgr.playerSave.SaveSkittlesGrade == 1)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    }
                    //    else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 8");
                    //    }
                    //    else
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 9");
                    //    }
                    //    monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                    //    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.position = new Vector3(monster.transform.parent.position.x + 240, monster.transform.parent.position.y - 70);
                    //    monsterUi.Add(monster);
                    //}

                    //if (json.information.monster[i].Code == "Mon 10")
                    //{
                    //    GameObject monster = Instantiate(kindofmonster, parent.transform);

                    //    if (saveMgr.playerSave.SaveDonutsGrade == 1)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    }
                    //    else if (saveMgr.playerSave.SaveDonutsGrade == 2)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 11");
                    //    }
                    //    else
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 12");
                    //    }
                    //    monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                    //    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.position = new Vector3(monster.transform.parent.position.x + 330, monster.transform.parent.position.y - 70);
                    //    monsterUi.Add(monster);
                    //}


                    //if (json.information.monster[i].Code == "Mon 13")
                    //{
                    //    GameObject monster = Instantiate(kindofmonster, parent.transform);

                    //    if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic(json.information.monster[i].Code);
                    //    }
                    //    else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 14");
                    //    }
                    //    else
                    //    {
                    //        monster.GetComponent<MakeSoldier>().SuperMagic("Mon 15");
                    //    }

                    //    monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                    //    monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                    //    monster.transform.position = new Vector3(monster.transform.parent.position.x + 420, monster.transform.parent.position.y - 70);
                    //    monsterUi.Add(monster);
                    //}

                    if (json.information.monster[i].Code == "Mon 16")
                    {
                        GameObject monster = Instantiate(kindofmonster, parent.transform);

                        if (saveMgr.playerSave.SaveChocoGrade == 1)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                        }
                        else if (saveMgr.playerSave.SaveChocoGrade == 2)
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                        }
                        else
                        {
                            monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                        }

                        monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        monster.transform.position = new Vector3(monster.transform.parent.position.x + 60, monster.transform.parent.position.y - 70);
                        monsterUi.Add(monster);

                        //monster.transform.GetChild(0).GetComponent<Image>().sprite = monster.GetComponent<MakeSoldier>().Picture;
                        //monster.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = monster.GetComponent<MakeSoldier>().Name;
                        //monster.transform.name = monster.GetComponent<MakeSoldier>().Name;
                        //monster.transform.position = new Vector3(monster.transform.parent.position.x + 510, monster.transform.parent.position.y - 70);
                        //monsterUi.Add(monster);
                    }
                }

                myContent.GetComponent<RectTransform>().sizeDelta = new Vector2(420 + (monsterUi.Count - 3) * 200, myContent.GetComponent<RectTransform>().sizeDelta.y);
            }
        }
    }
    #endregion

    public void SaveLevelCheck(GameObject Monster)
    {
        switch (Monster.GetComponent<MakeSoldier>().Name)
        {
            case "¾çÃÊ¸ÓÇÉ":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveCherryLevel;
                break;
            case "ÁøÀúÄíÅ°":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveCandyLevel;
                break;
            case "½ºÅ°Æ²ÁîÄÉÀÌÅ©":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveSkittlesLevel;
                break;
            case "µµ³ÓÃ÷":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveDonutsLevel;
                break;
            case "½´´Ï¹ß·»":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveSchneeballenLevel;
                break;
            case "ÃÊÄÚÄ¨ÄíÅ°":
                Monster.GetComponent<MakeSoldier>().Level = saveMgr.playerSave.SaveChocoLevel;
                break;
            default:
                break;
        }

        Monster.GetComponent<MakeSoldier>().BaseAttack += Monster.GetComponent<MakeSoldier>().RiseAttack * (Monster.GetComponent<MakeSoldier>().Level - 1);
        Monster.GetComponent<MakeSoldier>().Defensive += Monster.GetComponent<MakeSoldier>().RiseDefensive * (Monster.GetComponent<MakeSoldier>().Level - 1);
        Monster.GetComponent<MakeSoldier>().HelthPoint = (int)(Monster.GetComponent<TutorialSoldierManger>().totalHp);
        Monster.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = Monster.GetComponent<MakeSoldier>().Level.ToString();
    }
}
