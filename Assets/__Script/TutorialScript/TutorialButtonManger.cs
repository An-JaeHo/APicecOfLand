using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonManger : MonoBehaviour
{
    [Header ("Set in Inspector")]
    //public GameObject bulidUpgradeUi;
    //public GameObject armyUpgradeUi;
    public GameObject buildUi;
    public GameObject barrackWindow;
    public GameObject settingUi;
    public GameObject button;
    public GameObject makeBuildButton;
    public GameObject makeMonsterButton;
    public TutorialSupplyManger supplyManger;

    [Space(10f)]
    public GameObject CreateAreaPrefab;
    public TutorialInputManger input;
    public Transform buildTile;

    private TutorialPanalController panel;
    private PlayerInfo playerInfo;
    private int checkBuildPoint;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
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
        //if (bulidUpgradeUi.activeSelf)
        //{
        //    bulidUpgradeUi.SetActive(false);
        //    input.mouseCheck = true;
        //}
        //else
        //{
        //    bulidUpgradeUi.SetActive(true);
        //    input.mouseCheck = false;
        //}
    }

    public void ArmyUpgradeButton()
    {
        //if (armyUpgradeUi.activeSelf)
        //{
        //    armyUpgradeUi.SetActive(false);
        //    input.mouseCheck = true;
        //}
        //else
        //{
        //    armyUpgradeUi.SetActive(true);
        //    input.mouseCheck = false;
        //}
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
        }
        else
        {
            settingUi.SetActive(true);
        }

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            input.mouseCheck = false;
        }
        else
        {
            Time.timeScale = 1;
            input.mouseCheck = true;
        }
    }

    public void CheckNeedButton()
    {
        panel = CreateAreaPrefab.GetComponent<TutorialPanalController>();
        playerInfo.flour -= panel.upgradeWood;
        playerInfo.sugar -= panel.upgradeIron;

        panel.baseLand.GetComponent<MakeArea>().InputAreaInfo(panel.code);
        panel.baseLand.GetComponent<AreaManger>().CheckUpdateMaterial();
        //panel.parentUi.GetComponent<TutorialBuildController>().content.transform.position = panel.parentUi.GetComponent<TutorialBuildController>().position;
        input.mouseCheck = true;
        buildTile = panel.baseLand;

        if(input.talkManger.buildCheck)
        {
            input.talkManger.SupplyAndBarrackTalk();
            panel.baseLand.GetComponent<BoxCollider2D>().enabled = false;
            panel.parentUi.GetComponent<TutorialBuildController>().dimmedCover.SetActive(false);
        }
        else if(input.talkManger.barrackCheck)
        {
            input.talkManger.dimmedCover.SetActive(false);
            input.talkManger.stopTalkNum = 7;
            input.talkManger.NextScriptButton();
        }
        
        input.talkManger.talkCheck = true;
        supplyManger.JustUpdateSupply();
        panel.parentUi.SetActive(false);
    }

    public void TurnEnd()
    {
        playerInfo.turnPoint++;
        playerInfo.milk += playerInfo.updateMilk;
        playerInfo.flour += playerInfo.updateFlour;
        playerInfo.sugar += playerInfo.updateSugar;
        input.armyMove = true;

        for (int i = 0; i < barrackWindow.GetComponent<TutorialBarrackController>().monsters.Count; i++)
        {
            barrackWindow.GetComponent<TutorialBarrackController>().monsters[i].GetComponent<TutorialSoldierManger>().movePoint = true;
        }

        if(input.talkManger.moveCheck)
        {
            input.talkManger.attackUi.SetActive(true);
            input.talkManger.stopTalkNum = 1;

            if(input.talkManger.spcriptNum ==0)
            {
                input.talkManger.NextScriptButton();
            }
            
        }

        if(input.talkManger.spcriptNum == 12)
        {
            SceneMgr.GoUpGradeScene();
        }

        buildTile.GetComponent<MakeArea>().Destroy = false;
        buildTile.GetComponent<MakeArea>().firstBuild = false;
        buildTile.GetComponent<AreaManger>().CheckUpdateMaterial();
        supplyManger.UpdateSupply();
    }
}
