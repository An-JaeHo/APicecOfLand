using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ButtonManger : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject button;
    public GameObject skillInven;
    public GameObject turnPoint;
    public Sprite attackUi;
    public Sprite defendUi;
    public Transform UpgradeLand;
    public GameObject bulidUpgradeUi;
    public GameObject armyUpgradeUi;
    public GameObject repaireUi;
    public GameObject turnCountText;
    public GameObject attackContText;
    public GameObject buildUi;
    public GameObject barrackWindow;
    public GameObject settingUi;
    public SpecialSkillController specialSkillController;

    [Header("Set in ViusalStudio")]
    public InputManger input;
    public SupplyManger supplyManger;
    public TileManger tileManger;
    public BarrackController barrackController;
    public GameObject CreateAreaPrefab;
    public Sprite monsterPicture;
    public Sprite enemyPicture;
    public GameObject armyCheckWindow;
    public GameObject bulidCheckWindow;
    public GameObject dictionaryUi;
    public Timer timer;
    public float buttonTimer;
    public int attackTurnNum;
    public int food;
    public int wood;
    public int iron;
    
    public List<GameObject> amrys;
    public List<GameObject> builders;
    public List<Transform> tiles;
    public List<Transform> destroyTiles;
    public List<GameObject> enemys;
    public PlayerInfo playerInfo;


    private GameObject enemyTileWls;
    private List<GameObject> enemyTiles;
    private PanelController panel;
    private RangeManger rangeManger;
    private GameObject game;
    private bool healCheck;
    private FireBaseManger fireBaseManger;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        fireBaseManger = GameObject.FindGameObjectWithTag("GameManger").GetComponent<FireBaseManger>();
        rangeManger = transform.GetComponent<RangeManger>();
        enemys = new List<GameObject>();
        enemyTiles = new List<GameObject>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        input = GetComponent<InputManger>();
        barrackController = barrackWindow.GetComponent<BarrackController>();
        timer = GameObject.Find("GameTime").GetComponent<Timer>();
        buttonTimer = 1;
        healCheck = false;
        TurnCheck();
    }

    private void Update()
    {
        buttonTimer += Time.deltaTime;

        if (playerInfo.turnPoint < 4 || enemys.Count ==0)
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
            input.mouseCheck = true;
            skillInven.SetActive(false);
        }
        else
        {
            skillInven.SetActive(true);
            input.mouseCheck = false;
        }
    }

    public void RepairButton()
    {
        if (repaireUi.activeSelf)
        {
            input.mouseCheck = true;
            repaireUi.SetActive(false);
        }
        else
        {
            input.mouseCheck = false;
            repaireUi.SetActive(true);
        }
    }

    public void BuildUiButton()
    {
        if (buildUi.activeSelf)
        {
            input.mouseCheck = true;
            buildUi.SetActive(false);
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
            input.mouseCheck = true;
            bulidUpgradeUi.SetActive(false);
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
            input.mouseCheck = true;
            bulidCheckWindow.SetActive(false);
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
            input.mouseCheck = true;
            armyCheckWindow.SetActive(false);
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
            input.mouseCheck = true;
            armyUpgradeUi.SetActive(false);
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
            input.mouseCheck = true;
            barrackWindow.SetActive(false);
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
        }
        else
        {
            settingUi.SetActive(true);
        }

        if (Time.timeScale != 0)
        {
            input.mouseCheck = false;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            input.mouseCheck = true;
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
                rangeManger.rangeList[i].tag = "Barracks";
            }
            else
            {
                rangeManger.rangeList[i].tag = rangeManger.rangeList[i].GetComponent<MakeArea>().Type;
            }
        }

        panel.baseLand.GetComponent<MakeArea>().InputAreaInfo(panel.code);
        panel.baseLand.GetComponent<AreaManger>().CheckUpdateMaterial();
        supplyManger.JustUpdateSupply();
        input.mouseCheck = true;
        panel.parentUi.SetActive(false);
        tiles.Add(panel.baseLand);
    }

    public void CheckUpgradeResources()
    {
        if (playerInfo.flour >= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour && playerInfo.sugar >= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar)
        {
            tileManger.CheckTile();
            playerInfo.flour -= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour;
            playerInfo.sugar -= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar;
            UpgradeLand.GetComponent<AreaManger>().ReturnUpdateSouce();

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
                    break;
                case "Area 16":
                    UpgradeLand.GetComponent<MakeArea>().InputAreaInfo("Area 17");
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
                //너무 이상하다
                Camera.main.transform.position = new Vector3(enemys[i].transform.position.x, enemys[i].transform.position.y,-800f);
                yield return new WaitForSeconds(1f);
                enemys[i].GetComponent<EnemyController>().EnemyMove();

                yield return new WaitForSeconds(2f);

                if (enemys[i].transform.parent.tag == "Capital")
                {
                    enemys[i].transform.GetComponent<GameEnd>().GameEnding();
                }

                if (enemys[i].transform.parent.tag == "Area" 
                    || enemys[i].transform.parent.tag == "Barracks")
                {
                    if (!enemys[i].transform.parent.GetComponent<MakeArea>().Destroy)
                    {
                        enemys[i].transform.GetComponent<AudioSource>().clip = SoundController.FindAndPlayAudio("Destroy");
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
                    else
                    {
                        Destroy(enemys[i].GetComponent<EnemyController>().buffPrefebList[j]);
                    }
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

                if (enemys[i].tag == "Enemy")
                {
                    enemys[i].GetComponent<EnemyController>().enemy.BaseDefensive = enemys[i].GetComponent<EnemyController>().pureDefend;
                }
                else
                {
                    enemys[i].GetComponent<EnemyController>().gd.Defensive= enemys[i].GetComponent<EnemyController>().pureDefend;
                }

                enemys[i].GetComponent<EnemyController>().movePoint = true;
                enemys[i].GetComponent<EnemyController>().CheckBuff();

                if ((i+1) == enemys.Count)
                {
                    button.GetComponent<Button>().interactable = true;
                    Camera.main.transform.position = new Vector3(565, -900, -800);
                    timer.timerCheck = true;
                }
            }
        }
        else
        {
            timer.timerCheck = true;
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
            amrys[i].GetComponent<MakeSoldier>().MovementNumber = 1;
            amrys[i].GetComponent<SoldierManger>().ReturnPure();
            amrys[i].GetComponent<SoldierManger>().CheckBuff();
        }

        
        input.mouseCheck = true;
        timer.limitTime = 30;
        //timer.timerCheck = true;
        supplyManger.JustUpdateSupply();
        yield return null;
    }

    public void TurnEnd()
    {
        playerInfo.turnPoint++;
        input.mouseCheck = false;
        buttonTimer = 0;
        button.GetComponent<Button>().interactable = false;
        timer.timerCheck = false;

        if (playerInfo.turnPoint == 100)
        {
            fireBaseManger.LogEvent("100trun");
        }
        else if (playerInfo.turnPoint == 120)
        {
            int rand = Random.Range(200, 270);
            playerInfo.killingPoint = rand;
            SceneMgr.GoGameEndScene();
        }

        StartCoroutine(moveEnemy());
        rangeManger.rangeList.Clear();
        supplyManger.UpdateSupply();
        turnCountText.GetComponentInChildren<Text>().text = playerInfo.turnPoint.ToString();
        tileManger.NextLand();
        tileManger.SpawnEnemy();
        TurnCheck();
        tileManger.CheckTile();
        tileManger.HospitalCheck();
        input.CheckMonsterMovePoint();
        specialSkillController.SpecialSkillCheck();
    }

    void TurnCheck()
    {
        if (tileManger.attackTurnCheck)
        {
            attackContText.GetComponent<Image>().sprite = defendUi;
            timer.limitTime = 60;
            //공격턴 3 11 26 42 62 82
            if (tileManger.attackTurn == 0)
            {
                attackTurnNum = 3;
            }
            else if (tileManger.attackTurn == 1)
            {
                attackTurnNum = 11;
            }
            else if (tileManger.attackTurn == 2)
            {
                attackTurnNum = 26;
            }
            else if (tileManger.attackTurn == 3)
            {
                attackTurnNum = 42;
            }
            else if (tileManger.attackTurn == 4)
            {
                attackTurnNum = 62;
            }
            else if (tileManger.attackTurn == 5)
            {
                attackTurnNum = 82;
            }
            else if (tileManger.attackTurn == 6)
            {
                attackTurnNum = 102;
            }

            if (healCheck)
            {
                for (int i = 0; i < amrys.Count; i++)
                {
                    amrys[i].GetComponent<MakeSoldier>().HelthPoint +=
                        (int)(amrys[i].GetComponent<SoldierManger>().totalHp * 0.3f);

                    if (amrys[i].GetComponent<MakeSoldier>().HelthPoint >
                        amrys[i].GetComponent<SoldierManger>().totalHp)
                    {
                        amrys[i].GetComponent<MakeSoldier>().HelthPoint =
                            (int)amrys[i].GetComponent<SoldierManger>().totalHp;
                    }

                    amrys[i].GetComponent<SoldierManger>().HpBarScale();
                }

                
                healCheck = false;
            }
        }
        else
        {
            attackContText.GetComponent<Image>().sprite = attackUi;
            timer.limitTime = 30;
            healCheck = true;

            if (tileManger.attackTurn == 0)
            {
                attackTurnNum = 1;
            }
            else if (tileManger.attackTurn == 1)
            {
                attackTurnNum = 8;
            }
            else if (tileManger.attackTurn == 2)
            {
                attackTurnNum = 25;
            }
            else if (tileManger.attackTurn == 3)
            {
                attackTurnNum = 41;
            }
            else if (tileManger.attackTurn == 4)
            {
                attackTurnNum = 61;
            }
            else if (tileManger.attackTurn == 5)
            {
                attackTurnNum = 81;
            }
            else if (tileManger.attackTurn == 6)
            {
                attackTurnNum = 101;
            }
            else if (tileManger.attackTurn == 7)
            {
                attackTurnNum = 121;
            }
        }

        attackTurnNum -= playerInfo.turnPoint;
        attackContText.transform.parent.GetChild(0).GetChild(0).GetComponent<Text>().text = attackTurnNum.ToString();
    }

    public void DestroyCheckArea()
    {
        if(destroyTiles.Count !=0)
        {
            for (int i = 0; i < destroyTiles.Count; i++)
            {
                if (destroyTiles[i].GetComponent<MakeArea>().Destroy == true)
                {
                    destroyTiles[i].GetComponent<AreaManger>().ReturnUpdateSouce();
                    destroyTiles[i].GetComponent<MakeArea>().Code = destroyTiles[i].GetComponent<AreaManger>().pureCode;
                    destroyTiles[i].GetComponent<MakeArea>().Name = null;
                    destroyTiles[i].GetComponent<MakeArea>().Type = "Grass";
                    destroyTiles[i].GetComponent<MakeArea>().Grade = 0;
                    destroyTiles[i].GetComponent<MakeArea>().UpgradeFlour = 0;
                    destroyTiles[i].GetComponent<MakeArea>().UpgradeSugar = 0;
                    destroyTiles[i].GetComponent<MakeArea>().MilkOutput = 0;
                    destroyTiles[i].GetComponent<MakeArea>().FlourOutput = 0;
                    destroyTiles[i].GetComponent<MakeArea>().SugarOutput = 0;
                    destroyTiles[i].GetComponent<MakeArea>().Movement = true;
                    destroyTiles[i].GetComponent<MakeArea>().Destroy = false;
                    destroyTiles[i].GetComponent<MakeArea>().Repair = false;
                    destroyTiles[i].GetComponent<MakeArea>().Effect = null;
                    destroyTiles[i].GetComponent<SpriteRenderer>().sprite = destroyTiles[i].GetComponent<AreaManger>().pureSprite;
                    destroyTiles[i].GetComponent<SpriteRenderer>().color = Color.white;
                    destroyTiles[i].GetComponent<AreaManger>().pureColor = Color.white;
                    destroyTiles[i].tag = "Grass";
                    
                }
            }

            destroyTiles.Clear();
        }
    }
}
