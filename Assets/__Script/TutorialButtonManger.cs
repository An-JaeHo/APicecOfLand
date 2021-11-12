using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonManger : MonoBehaviour
{
    public GameObject bulidUpgradeUi;
    public GameObject armyUpgradeUi;
    public GameObject buildUi;
    public GameObject barrackWindow;
    public GameObject settingUi;
    public TutorialSupplyManger supplyManger;
    public GameObject CreateAreaPrefab;
    private TutorialPanalController panel;
    private PlayerInfo playerInfo;
    public TutorialInputManger input;
    public Transform buildTile;
    private int checkBuildPoint;

    //빌드말하기버튼
    public GameObject button;
    public GameObject makeBuildButton;
    public GameObject makeMonsterButton;


    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<TutorialSupplyManger>();
        input = GetComponent<TutorialInputManger>();
        checkBuildPoint = 0;
        button.GetComponent<Button>().interactable = false;
        makeBuildButton.GetComponent<Button>().interactable = false;
        makeMonsterButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            barrackWindow.GetComponent<BarrackController>().barrackMonsterSprite.gameObject.SetActive(false);
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

    public void CheckNeedButton()
    {
        panel = CreateAreaPrefab.GetComponent<TutorialPanalController>();
        playerInfo.flour -= panel.upgradeWood;
        playerInfo.sugar -= panel.upgradeIron;

        panel.baseLand.GetComponent<MakeArea>().InputAreaInfo(panel.code);
        supplyManger.UpdateSupply();
        panel.parentUi.GetComponent<TutorialBuildController>().content.transform.position = panel.parentUi.GetComponent<TutorialBuildController>().position;
        input.mouseCheck = true;
        buildTile = panel.baseLand;

        input.talkManger.NextScriptButton();
        input.talkManger.talkCheck = true;
        input.talkManger.stopTalkNum = 6;
        panel.parentUi.SetActive(false);
        
    }

    public void TurnEnd()
    {
        playerInfo.turnPoint++;
        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;
        checkBuildPoint++;

        if (buildTile != null)
        {
            if (buildTile.GetComponent<MakeArea>().BuildTurn == checkBuildPoint)
            {
                if (buildTile.tag == "Area" || buildTile.tag == "Barracks")
                {
                    buildTile.GetComponent<SpriteRenderer>().sprite = buildTile.GetComponent<MakeArea>().Picture;
                    input.talkManger.NextScriptButton();
                    input.talk = true;
                }
                else
                {
                    buildTile.GetComponent<SpriteRenderer>().sprite = buildTile.GetComponent<AreaManger>().pureSprite;
                }

                buildTile.GetComponent<MakeArea>().Destroy = false;
                buildTile.GetComponent<MakeArea>().firstBuild = false;
                buildTile.GetComponent<AreaManger>().CheckUpdateMaterial();

                checkBuildPoint = 0;
            }
        }

        //if (transform.parent.GetComponent<MakeArea>().BuildTurn != builderPoint
        //    && transform.parent.GetComponent<MakeArea>().firstBuild == true)
        //{

        //    builderPoint++;
        //}
        //else
        //{
        //    movePoint = true;
        //    if (transform.parent.tag == "Area" || transform.parent.tag == "Barracks")
        //    {
        //        transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<MakeArea>().Picture;
        //    }
        //    else
        //    {
        //        transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<AreaManger>().pureSprite;
        //    }

        //    transform.parent.GetComponent<MakeArea>().Destroy = false;
        //    transform.parent.GetComponent<MakeArea>().firstBuild = false;
        //    transform.parent.GetComponent<AreaManger>().CheckUpdateMaterial();

        //    builderPoint = 0;
        //}

        //StartCoroutine(moveEnemy());
        supplyManger.UpdateSupply();
        //turnCountText.GetComponentInChildren<Text>().text = playerInfo.turnPoint.ToString();
        //tileManger.SpawnEnemy();
        
    }
}
