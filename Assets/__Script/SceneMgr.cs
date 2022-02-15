using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMgr : MonoBehaviour
{
    public static SaveMgr save;
    public static PlayerInfo playerInfo;
    public static string fonlderPath;
    public static FireBaseManger fireBaseManger;

    private void Start()
    {
        fonlderPath = Application.persistentDataPath;
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        fireBaseManger = GameObject.FindGameObjectWithTag("GameManger").GetComponent<FireBaseManger>();
    }

    public static void GoGameMainScene()
    {
        playerInfo.StartGame();
        save.playerSave.firstGame = false;
        SceneManager.LoadScene(0);
    }

    public static void GoGameScene()
    {
        playerInfo.updateFlour = 0;
        playerInfo.updateMilk = 0;
        playerInfo.updateSugar = 0;
        playerInfo.StartGame();

        if(save.playerSave.firstGame)
        {
            fireBaseManger.LogEvent("first_play_game");
        }
        else
        {
            fireBaseManger.LogEvent("second_play_game");
        }

        SceneManager.LoadScene(3);
    }

    public static void GoGameEndScene()
    {
        SceneManager.LoadScene(4);
    }

    public static void GoGameTutorial()
    {
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        playerInfo.StartGame();
        LoadingSceneController.LoadScene("Tutorial");
    }

    public static void GoUpGradeScene()
    {
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        fireBaseManger.LogEvent("go_mainscene");

        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            save.Save();
            GoGameTutorial();
        }
        else
        {
            save.Load();
            LoadingSceneController.LoadScene("UpGradeScene");
        }
    }
}
