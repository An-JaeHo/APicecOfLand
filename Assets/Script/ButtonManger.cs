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

    //타일 구매용
    public int food;
    public int wood;
    public int iron;
    

    // 야만인 타일용
    private TileManger tileManger;
    private List<GameObject> enemyTiles;
    public List<GameObject> enemys;
    private GameObject enemyTileWls;

    //업그레이드 용
    public Transform UpgradeLand;
    public GameObject bulidUpgradeUi;
    public GameObject armyUpgradeUi;

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
        }
        else
        {
            armyUpgradeUi.SetActive(true);
            input.mouseCheck = false;
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
                case "Troop 1":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 5");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 2":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 6");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 3":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 7");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 4":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 8");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 5":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 9");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 6":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 10");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 7":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 11");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 8":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 12");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 9":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 13");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 10":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 14");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 11":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 15");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                case "Troop 12":
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().SuperMagic("Troop 16");
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.name = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Name;
                    armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<SpriteRenderer>().sprite = armyUpgradeUi.GetComponent<ArmyUpgrade>().army.GetComponent<MakeSoldier>().Picture;
                    break;

                default:
                    break;
            }
            
            playerInfo.people -= 1;
            playerInfo.milk -= armyUpgradeUi.GetComponent<ArmyUpgrade>().armyinfo.ProductionExpense;
            supplyManger.UpdateSupply();
            armyUpgradeUi.SetActive(false);
            input.mouseCheck = true;
        }
    }


    public void CheckNeedButton()
    {
        panel = CreateAreaPrefab.GetComponent<PanelController>();
        playerInfo.flour -= panel.upgradeWood;
        playerInfo.sugar -= panel.upgradeIron;
        input.army.transform.SetParent(input.hitObj.transform);
        input.moveSoldier.move = true;

        for (int i = 0; i < rangeManger.rangeList.Count; i++)
        {
            rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;
        }

        panel.baseLand.GetComponent<MakeArea>().InputAreaInfo(panel.code);

        if(panel.baseLand.tag == "Area" || panel.baseLand.tag == "Barracks")
        {
            panel.baseLand.GetComponent<AreaManger>().pureTag = panel.baseLand.GetComponent<MakeArea>().tag;
            panel.baseLand.GetComponent<AreaManger>().pureCode = panel.baseLand.GetComponent<MakeArea>().Code;
            panel.baseLand.GetComponent<AreaManger>().pureSprite = panel.baseLand.GetComponent<SpriteRenderer>().sprite;
        }

        panel.baseLand.GetComponent<AreaManger>().CheckUpdateMaterial();
        supplyManger.UpdateSupply();
        panel.parentUi.GetComponent<BuildController>().content.transform.position = panel.parentUi.GetComponent<BuildController>().position;
        input.mouseCheck = true;
        panel.parentUi.SetActive(false);
    }

    public void CheckUpgradeResources()
    {
        if (playerInfo.flour >= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour && playerInfo.sugar >= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar)
        {
            switch(UpgradeLand.GetComponent<MakeArea>().Code)
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

            playerInfo.flour -= UpgradeLand.GetComponent<MakeArea>().UpgradeFlour;
            playerInfo.sugar -= UpgradeLand.GetComponent<MakeArea>().UpgradeSugar;

            input.army.transform.SetParent(input.hitObj.transform);
            input.moveSoldier.move = true;

            for (int i = 0; i < rangeManger.rangeList.Count; i++)
            {
                rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;
            }

            UpgradeLand.GetComponent<AreaManger>().CheckUpdateMaterial();
            supplyManger.UpdateSupply();
            input.mouseCheck = true;
            bulidUpgradeUi.SetActive(false);
        }
    }

    IEnumerator moveEnemy()
    {
        if (enemys.Count != 0)
        {
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].GetComponent<EnemyController>().EnemyMove();
                button.GetComponent<Button>().interactable = false;
                
                if (enemys[i].transform.parent.tag == "Area" 
                    || enemys[i].transform.parent.tag == "Barrack")
                {
                    enemys[i].transform.parent.GetComponent<AreaManger>().TurnArea();
                    
                }

                yield return new WaitForSeconds(2f);

                if (enemys[i].transform.parent.tag == "Capital")
                {
                    enemys[i].transform.GetComponent<GameEnd>().GameEnding();
                }
            }
        }

        button.GetComponent<Button>().interactable = true;
        yield return null;
    }

    public void TurnEnd()
    {
        if(playerInfo.turnPoint == 50)
        {
            int rand = Random.Range(200, 270);
            playerInfo.killingPoint = rand;
            SceneManager.LoadScene(3);
        }
        button.GetComponent<Button>().interactable = false;

        foreach (var armys in barrackWindow.GetComponent<BarrackController>().monsters)
        {
            armys.GetComponent<SoldierManger>().movePoint = true;
            armys.GetComponent<SoldierManger>().HpBarScale();
        }

        foreach(var builds in builders)
        {
            builds.GetComponent<SoldierManger>().CheckBuildCount();
        }

        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;

        
        playerInfo.turnPoint++;
        rangeManger.rangeList.Clear();
        supplyManger.UpdateSupply();
        GameObject.Find("ButtonMgr").transform.GetChild(6).GetComponentInChildren<Text>().text = playerInfo.turnPoint.ToString();
        tileManger.NextLand();
        tileManger.SpawnEnemy();

        button.GetComponent<Button>().interactable = true;

        StartCoroutine(moveEnemy());

        for (int i = 0; i < amrys.Count; i++)
        {
            for (int j = 0; j < amrys[i].GetComponent<SoldierManger>().buffPrefebList.Count; j++)
            {
                GameObject.Destroy(amrys[i].GetComponent<SoldierManger>().buffPrefebList[j]);
            }
            amrys[i].GetComponent<SoldierManger>().buffList.Clear();
            amrys[i].GetComponent<SoldierManger>().buffPrefebList.Clear();
        }
        
    }
}
