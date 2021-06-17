using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffNDeBuffInfo : MonoBehaviour
{
    public Buff buff;
    public DeBuff deBuff;
    public PlayerInfo player;
    public bool buffCheck;
    public AbilityUiController ability;

    public void BuffInput()
    {
        ability = GameObject.FindGameObjectWithTag("AbilityUi").GetComponent<AbilityUiController>();

        if (buffCheck)
        {
            player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
            GameObject.Find("GadianSelectBuff").transform.GetChild(1).GetComponent<Text>().text = buff.Name;
            player.playerBuff = buff;
            player.playerBuffCheck = true;
            GameObject.Find("AbilityUi").SetActive(false);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
            GameObject.Find("GadianSelectDeBuff").transform.GetChild(1).GetComponent<Text>().text = deBuff.Name;
            player.playerDebuff = deBuff;
            player.playerDeBuffCheck = true;
            GameObject.Find("AbilityUi").SetActive(false);
        }

        
        ability.ClearAll();
    }
}
