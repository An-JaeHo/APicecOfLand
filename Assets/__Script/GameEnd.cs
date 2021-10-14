﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject capital;
    public PlayerInfo playerInfo;

    private void Start()
    {
        capital = GameObject.FindGameObjectWithTag("Capital");
    }

    // Update is called once per frame
    public void GameEnding()
    {
        if (capital.transform.childCount != 0)
        {
            if (capital.transform.GetChild(0).tag == "Enemy" || capital.transform.GetChild(0).tag == "GD")
            {
                SceneMgr.GoGameEndScene();
            }
        }
    }
}