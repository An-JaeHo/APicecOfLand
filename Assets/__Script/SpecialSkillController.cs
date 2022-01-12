using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialSkillController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public ButtonManger buttonManger;
    public TileManger tileManger;
    public bool skillCheck;
    int coolTime;

    private void Start()
    {
        coolTime = 10;
        skillCheck = true;
    }

    public void SpecialSkillCheck()
    {
        if(coolTime >=10)
        {
            gameObject.SetActive(true);
        }
        else
        {
            coolTime++;
        }
    }

    public void CandleSkillButton()
    {
        for (int j = 0; j < buttonManger.enemys.Count; j++)
        {
            int nameOfLand = Int32.Parse(buttonManger.enemys[j].transform.parent.parent.name);
            Transform obj = null;

            for (int i = 0; i < tileManger.activeChildtileList.Count; i++)
            {
                if (tileManger.activeChildtileList[i].name == nameOfLand.ToString())
                {
                    Debug.Log("Test 1");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 1).ToString())
                {
                    Debug.Log("Test 2");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 1).ToString())
                {
                    Debug.Log("Test 3");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17).ToString())
                {
                    Debug.Log("Test 4");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17).ToString())
                {
                    Debug.Log("Test 5");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 + 1).ToString())
                {
                    Debug.Log("Test 6");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 - 1).ToString())
                {
                    Debug.Log("Test 7");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 + 1).ToString())
                {
                    Debug.Log("Test 8");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 - 1).ToString())
                {
                    Debug.Log("Test 9");
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }

                if(obj!= null)
                {
                    obj.GetComponent<SpriteRenderer>().color = Color.red;
                    buttonManger.input.rangeManger.rangeList.Add(obj);
                    buttonManger.input.armyMove = false;
                    skillCheck = true;
                    if(obj.childCount !=0)
                    {
                        obj.tag = "SelectLand";
                    }
                    
                }
            }
        }
    }
}
