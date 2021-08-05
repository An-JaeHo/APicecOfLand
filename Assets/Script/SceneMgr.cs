using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    
    public static void GoGameMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoLodingScene()
    {
        LoadingSceneController.LoadScene("GameScene");
    }

    public static void GoGameScene()
    {
        SceneManager.LoadScene(3);
    }

    public static void GoGameEndScene()
    {
        SceneManager.LoadScene(4);
    }

    public static void GoUpGradeScene()
    {
        SceneManager.LoadScene(1);
    }
}
