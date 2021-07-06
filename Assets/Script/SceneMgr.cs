using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    
    public static void GoGameMainScene()
    {
        Debug.Log("afaf");
        SceneManager.LoadScene(0);
    }

    public void GoLodingScene()
    {
        LoadingSceneController.LoadScene("GameScene");
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoGameEndScene()
    {
        SceneManager.LoadScene(3);
    }
}
