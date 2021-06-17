using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void GoGameMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoChareterScene()
    {
        SceneManager.LoadScene(1);
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
