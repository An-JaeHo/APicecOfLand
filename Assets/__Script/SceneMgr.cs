using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMgr : MonoBehaviour
{
    public static SaveMgr save;
    public static string fonlderPath;

    private void Start()
    {
        fonlderPath = Application.persistentDataPath;
    }

    public static void GoGameMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoGameScene()
    {
        SceneManager.LoadScene(3);
    }

    public static void GoGameEndScene()
    {
        SceneManager.LoadScene(4);
    }

    public static void GoGameTutorial()
    {
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        LoadingSceneController.LoadScene("Tutorial");
    }

    public static void GoUpGradeScene()
    {
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();

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
