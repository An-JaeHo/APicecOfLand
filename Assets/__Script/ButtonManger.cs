using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ButtonManger : MonoBehaviour
{
    public GameObject button;
    public GameObject skillInven;
    public GameObject turnPoint;
    private PlayerInfo playerInfo;
    public GameObject CreateAreaPrefab;
    private PanelController panel;
    private RangeManger rangeManger;
    private GameObject game;
    public InputManger input;
    public SupplyManger supplyManger;
    public List<GameObject> amrys;
    public List<GameObject> builders;
    public Timer timer;
    public float buttonTimer;
    public GameObject turnCountText;
    public List<Transform> tiles;

    //타일 구매용
    public int food;
    public int wood;
    public int iron;
    

    // 야만인 타일용
    public TileManger tileManger;
    private List<GameObject> enemyTiles;
    public List<GameObject> enemys;
    private GameObject enemyTileWls;

    //업그레이드 용
    public Transform UpgradeLand;
    public GameObject bulidUpgradeUi;
    public GameObject armyUpgradeUi;
    public BarrackController barrackController;
    //창
    public GameObject buildUi;
    public GameObject armyCheckWindow;
    public GameObject bulidCheckWindow;
    public GameObject barrackWindow;
    public GameObject settingUi;
    public GameObject dictionaryUi;


    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        rangeManger = transform.GetComponent<RangeManger>();
        enemys = new List<GameObject>();
        enemyTiles = new List<GameObject>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        input = GetComponent<InputManger>();
        barrackController = barrackWindow.GetComponent<BarrackController>();
        timer = GameObject.Find("GameTime").GetComponent<Timer>();
        buttonTimer = 1;
    }

    private void Update()
    {
        buttonTimer += Time.deltaTime;

        if (playerInfo.turnPoint < 9)
        {
            if (buttonTimer > 1f)
            {
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }
    #region 일반적인 버튼모음
    public void SkillInvenButton()
    {
        if(skillInven.activeSelf)
        {
            skillInven.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            skillInven.SetActive(true);
            input.mouseCheck = false;
        }
    }

    public void BuildUiButton()
    {
        if (buildUi.activeSelf)
        {
            buildUi.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            buildUi.SetActive(true);
            input.mouseCheck = false;
        }

        for (int i = 0; i < rangeManger.rangeList.Count; i++)
        {
            rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;
            rangeManger.rangeList[i].transform.tag = rangeManger.rangeList[i].GetComponent<AreaManger>().pureTag;
        }
    }

    public void BuildUpGreadeUiButton()
    {
        if (bulidUpgradeUi.activeSelf)
        {
            bulidUpgradeUi.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            bulidUpgradeUi.SetActive(true);
            input.mouseCheck = false;
        }
    }

    public void BulidCheckButton()
    {
        if (bulidCheckWindow.activeSelf)
        {
            bulidCheckWindow.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            bulidCheckWindow.SetActive(true);
            input.mouseCheck = false;
            if (armyCheckWindow.activeSelf)
                armyCheckWindow.SetActive(false);
        }
    }

    public void ArmyUiButton()
    {
        if (armyCheckWindow.activeSelf)
        {
            armyCheckWindow.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            armyCheckWindow.SetActive(true);
            input.mouseCheck = false;

            if (bulidCheckWindow.activeSelf)
            {
                bulidCheckWindow.SetActive(false);
            }
                
        }
    }

    public void ArmyUpgradeButton()
    {
        if (armyUpgradeUi.activeSelf)
        {
            armyUpgradeUi.SetActive(false);
            input.mouseCheck = true;
            input.time = 0;
        }
        else
        {
            armyUpgradeUi.SetActive(true);
            input.mouseCheck = false;
            input.time = 0;
        }
    }

    public void BarrackButton()
    {
        if (barrackWindow.activeSelf)
        {
            barrackWindow.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            barrackWindow.SetActive(true);
            barrackWindow.GetComponent<BarrackController>().barrackMonsterSprite.gameObject.SetActive(false);
            input.mouseCheck = false;
        }
    }

    public void SettingButton()
    {
        if (settingUi.activeSelf)
        {
            settingUi.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            settingUi.SetActive(true);
            input.mouseCheck = false;
        }
    }

    public void DictionarykButton()
    {
        if (dictionaryUi.activeSelf)
        {
            dictionaryUi.SetActive(false);
            input.mouseCheck = true;
        }
        else
        {
            dictionaryUi.SetActive(true);
            input.mouseCheck = false;
        }
    }

    #endregion 

    public void NeedArmyUpgrade()
    {
        if (playerInfo.people > 1 && playerInfo.milk > armyUpgradeUi.GetComponent<ArmyUpgrade>().armyinfo.ProductionExpense)
        {
            switch (armyUpgradeUi.GetComponent<ArmyUpgrade>().armyinfo.Code)
            {
                case "Mon 1":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 2";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 2":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 3";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 4":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 5";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 5":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 6";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 7":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 8";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 8":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 9";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 10":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 11";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 11":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 12";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 13":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 14";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 14":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 15";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 16":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 17";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;
                case "Mon 17":
                    barrackController.land = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.parent;
                    barrackController.soldierInfo.Code = "Mon 18";
                    amrys.Remove(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    barrackController.MakeSoldierInPlace();
                    Destroy(armyUpgradeUi.GetComponent<ArmyUpgrade>().army.gameObject);
                    break;


                default:
                    break;
            }
            
            playerInfo.people -= 1;
            playerInfo.milk -= armyUpgradeUi.GetComponent<ArmyUpgrade>().upgradeMilk;
            supplyManger.JustUpdateSupply();
            armyUpgradeUi.SetActive(false);
            input.mouseCheck = true;
        }
    }


    public void CheckNeedButton()
    {
        panel = CreateAreaPrefab.GetComponent<PanelController>();
        playerInfo.flour -= panel.upgradeWood;
        playerInfo.sugar -= panel.upgradeIron;
        tileManger.CheckTile();

        for (int i = 0; i < rangeManger.rangeList.Count; i++)
        {
            rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;

            if(rangeManger.rangeList[i].GetComponent<MakeArea>().Name == "병영")
            {
                rangeManger.rangeList[i].tag = "Baarack";
            }
            else
            {
                rangeManger.rangeList[i].tag = rangeManger.rangeList[i].GetComponent<MakeArea>().Type;
            }
            
        }

        //panel.baseLand.GetComponent<BoxCollider2D>().enabled = false;
        panel.baseLand.GetComponent<MakeArea>().InputAreaInfo(panel.code);
        supplyManger.UpdateSupply();
        panel.parentUi.GetComponent<BuildController>().content.transform.position = panel.parentUi.GetComponent<BuildController>().position;
        input.mouseCheck = true;
        panel.parentUi.SetActive(false);
        tiles.Add(panel.baseLand);
    }

    //public void CheckBuildCount()
    //{
    //    for (int i = 0; i < tiles.Count; i++)
    //    {
    //        tiles[i].GetComponent<AreaManger>().buildTurn++;

    //        if (tiles[i].GetComponent<MakeArea>().BuildTurn == tiles[i].GetComponent<AreaManger>().buildTurn
    //             && tiles[i].GetComponent<MakeArea>().firstBuild == true)
    //        {
    //            if (tiles[i].GetComponent<MakeArea>().Type == "Area")
    //            {
    //                tiles[i].GetComponent<SpriteRenderer>().sprite = tiles[i].GetComponent<MakeArea>().Picture;
    //            }
    //            else
    //            {
    //                tiles[i].GetComponent<SpriteRenderer>().sprite = tiles[i].GetComponent<AreaManger>().pureSprite;
    //            }

    //            tiles[i].GetComponent<MakeArea>().Destroy = false;
    //            tiles[i].GetComponent<MakeArea>().firstBuild = false;
    //            tiles[i].GetComponent<AreaManger>().CheckUpdateMaterial();
    //            tiles[i].GetComponent<BoxCollider2D>().enabled = true;
    //            tiles[i].GetComponent<AreaManger>().buildTurn = 0;
    //        }

    //    }
    //}

    public void CheckUpgradeResources()
    {
        if (playerInfo.flour >= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour && playerInfo.sugar >= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar)
        {
            tileManger.CheckTile();
            playerInfo.flour -= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour;
            playerInfo.sugar -= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar;

            switch (UpgradeLand.GetComponent<MakeArea>().Code)
            {
                case "Area 1":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 2");
                    break;
                case "Area 2":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 3");
                    break;
                case "Area 3":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 4");
                    break;
                case "Area 4":
                    break;
                case "Area 5":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 6");
                    break;
                case "Area 6":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 7");
                    break;
                case "Area 7":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 8");
                    break;
                case "Area 8":
                    break;
                case "Area 9":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 10");
                    break;
                case "Area 10":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 11");
                    break;
                case "Area 11":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 12");
                    break;
                case "Area 12":
                    break;
                case "Area 13":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 14");
                    break;
                case "Area 14":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 15");
                    break;
                case "Area 15":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 16");
                    break;
                case "Area 16":
                    break;
                case "Area 17":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 18");
                    break;
                case "Area 18":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 19");
                    break;
                case "Area 19":
                    break;
                case "Area 20":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 21");
                    break;
                case "Area 21":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 22");
                    break;
                case "Area 22":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 23");
                    break;
                case "Area 23":
                    break;
                case "Area 24":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 25");
                    break;
                case "Area 25":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 26");
                    break;
                case "Area 26":
                    break;
            }

            for (int i = 0; i < rangeManger.rangeList.Count; i++)
            {
                rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;

                if (rangeManger.rangeList[i].GetComponent<MakeArea>().Name == "병영")
                {
                    rangeManger.rangeList[i].tag = "Baarack";
                }
                else
                {
                    rangeManger.rangeList[i].tag = rangeManger.rangeList[i].GetComponent<MakeArea>().Type;
                }
            }

            //건설턴 유보
            //UpgradeLand.GetComponent<MakeArea>().firstBuild = true;
            //UpgradeLand.GetComponent<BoxCollider2D>().enabled = false;
            //UpgradeLand.GetComponent<MakeArea>().BuildTurn = 1;
            //UpgradeLand.GetComponent<AreaManger>().buildTurn = 0;

            UpgradeLand.GetComponent<AreaManger>().CheckUpdateMaterial();
            supplyManger.JustUpdateSupply();
            input.mouseCheck = true;
            bulidUpgradeUi.SetActive(false);
        }
    }

    IEnumerator moveEnemy()
    {
        List<string> turnSkill = new List<string>();

        if (enemys.Count != 0)
        {
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].GetComponent<EnemyController>().EnemyMove();

                yield return new WaitForSeconds(2f);

                if (enemys[i].transform.parent.tag == "Capital")
                {
                    enemys[i].transform.GetComponent<GameEnd>().GameEnding();
                }

                if (enemys[i].transform.parent.tag == "Area" 
                    || enemys[i].transform.parent.tag == "Barracks")
                {
                    //효과음
                    if (!enemys[i].transform.parent.GetComponent<MakeArea>().Destroy)
                    {
                        enemys[i].transform.GetComponent<AudioSource>().clip = SoundController.instance.buildSounds[2].audio;
                        enemys[i].transform.GetComponent<AudioSource>().Play();
                    }

                    enemys[i].transform.parent.GetComponent<AreaManger>().TurnArea();
                }

                for (int j = 0; j < enemys[i].GetComponent<EnemyController>().buffPrefebList.Count; j++)
                {
                    enemys[i].GetComponent<EnemyController>().buffPrefebList[j].GetComponent<InputSkill>().Turn--;

                    if (enemys[i].GetComponent<EnemyController>().buffPrefebList[j].GetComponent<InputSkill>().Turn > 0)
                    {
                        turnSkill.Add(enemys[i].GetComponent<EnemyController>().buffPrefebList[j].GetComponent<InputSkill>().Code);
                    }

                    Destroy(enemys[i].GetComponent<EnemyController>().buffPrefebList[j]);
                }

                enemys[i].GetComponent<EnemyController>().buffPrefebList.Clear();

                if (turnSkill.Count != 0)
                {
                    for (int j = 0; j < turnSkill.Count; j++)
                    {
                        enemys[i].GetComponent<EnemyController>().MakeBuffIcon(turnSkill[j]);
                    }

                    for (int j = 0; j < enemys[i].GetComponent<EnemyController>().buffPrefebList.Count; j++)
                    {
                        enemys[i].GetComponent<EnemyController>().buffPrefebList[j].GetComponent<InputSkill>().Turn--;
                    }

                    turnSkill.Clear();
                }

                //enemys[i].GetComponent<EnemyController>().HpBarScale();
                if (enemys[i].tag == "Enemy")
                {
                    enemys[i].GetComponent<EnemyController>().enemy.BaseDefensive = enemys[i].GetComponent<EnemyController>().pureDefend;
                }
                else
                {
                    enemys[i].GetComponent<EnemyController>().gd.Defensive= enemys[i].GetComponent<EnemyController>().pureDefend;
                }
                
                enemys[i].GetComponent<EnemyController>().CheckBuff();
            }
        }

        for (int i = 0; i < amrys.Count; i++)
        {
            for (int j = 0; j < amrys[i].GetComponent<SoldierManger>().buffPrefebList.Count; j++)
            {
                amrys[i].GetComponent<SoldierManger>().buffPrefebList[j].GetComponent<InputSkill>().Turn--;

                if (amrys[i].GetComponent<SoldierManger>().buffPrefebList[j].GetComponent<InputSkill>().Turn > 0)
                {
                    turnSkill.Add(amrys[i].GetComponent<SoldierManger>().buffPrefebList[j].GetComponent<InputSkill>().Code);
                }

                Destroy(amrys[i].GetComponent<SoldierManger>().buffPrefebList[j]);
            }

            amrys[i].GetComponent<SoldierManger>().buffPrefebList.Clear();

            if(turnSkill.Count !=0)
            {
                for (int j = 0; j < turnSkill.Count; j++)
                {
                    amrys[i].GetComponent<SoldierManger>().MakeBuffIcon(turnSkill[j]);
                }

                for (int j = 0; j < amrys[i].GetComponent<SoldierManger>().buffPrefebList.Count; j++)
                {
                    amrys[i].GetComponent<SoldierManger>().buffPrefebList[j].GetComponent<InputSkill>().Turn--;
                }

                turnSkill.Clear();
            }

            amrys[i].GetComponent<SoldierManger>().movePoint = true;
            amrys[i].GetComponent<SoldierManger>().ReturnPure();
            amrys[i].GetComponent<SoldierManger>().CheckBuff();
        }

        button.GetComponent<Button>().interactable = true;
        input.mouseCheck = true;
        timer.limitTime = 60;
        timer.timerCheck = true;
        supplyManger.JustUpdateSupply();
        yield return null;
    }

    public void TurnEnd()
    {
        playerInfo.turnPoint++;
        input.mouseCheck = false;
        buttonTimer = 0;

        if (playerInfo.turnPoint == 50)
        {
            int rand = Random.Range(200, 270);
            playerInfo.killingPoint = rand;
            SceneMgr.GoGameEndScene();
        }

        if(tiles.Count !=0)
        {
            //CheckBuildCount();
        }

        StartCoroutine(moveEnemy());
        rangeManger.rangeList.Clear();
        supplyManger.UpdateSupply();
        turnCountText.GetComponentInChildren<Text>().text = playerInfo.turnPoint.ToString();
        tileManger.NextLand();
        tileManger.SpawnEnemy();
        tileManger.CheckTile();
    }
}
