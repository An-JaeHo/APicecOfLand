using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySupplyList : MonoBehaviour
{
    public PlayerInfo playerInfo;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        UpdateSupply();
    }

    public void UpdateSupply()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = playerInfo.milk.ToString();
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = playerInfo.flour.ToString();
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = playerInfo.sugar.ToString();
    }
}
