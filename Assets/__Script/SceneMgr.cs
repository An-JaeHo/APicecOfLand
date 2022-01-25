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

    private void Start()
    {
        fonlderPath = Application.persistentDataPath;
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
    }

    public static void GoGameMainScene()
    {
        playerInfo.StartGame();
        SceneManager.LoadScene(0);
    }

    public static void GoGameScene()
    {
        playerInfo.updateFlour = 0;
        playerInfo.updateMilk = 0;
        playerInfo.updateSugar = 0;
        playerInfo.StartGame();
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
        playerInfo.StartGame();
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            LoadingSceneController.LoadScene("Tutorial");
        }
        else
        {
            LoadingSceneController.LoadScene("UpGradeScene");
        }

        save.Load();
    }
}
