using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySupplyList : MonoBehaviour
{
    public PlayerInfo playerInfo;
    private SaveMgr saveMgr;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        UpdateSupply();
    }

    public void UpdateSupply()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.milk.ToString();
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.sugar.ToString();
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = saveMgr.playerSave.flour.ToString();
    }
}
