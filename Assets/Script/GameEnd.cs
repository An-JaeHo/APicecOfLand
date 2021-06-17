using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public SceneMgr sceneMgr;
    public GameObject capital;
    public PlayerInfo playerInfo;

    private void Start()
    {
        capital = GameObject.FindGameObjectWithTag("Capital");
        sceneMgr = GetComponent<SceneMgr>();
    }

    // Update is called once per frame
    public void GameEnding()
    {
        sceneMgr = GetComponent<SceneMgr>();

        if (capital.transform.childCount != 0)
        {
            if (capital.transform.GetChild(0).tag == "Enemy")
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
