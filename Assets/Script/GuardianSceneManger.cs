using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianSceneManger : MonoBehaviour
{
    public GameObject guardianPictureUi;
    public PlayerInfo player;
    public GameObject goGameScene;
    public SaveMgr saveMgr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
    }

    private void Update()
    {
        if (player.playerBuffCheck == true && player.playerDeBuffCheck == true && player.playerGuardianCheck == true)
            goGameScene.GetComponent<Button>().interactable = true;
    }

    public void GuardianPictureUi()
    {
        if(guardianPictureUi.activeSelf)
        {
            guardianPictureUi.SetActive(false);
        }
        else
        {
            guardianPictureUi.SetActive(true);
        }
    }

    public void CheckGameScene()
    {
        SceneMgr.GoGameScene();
    }
}
