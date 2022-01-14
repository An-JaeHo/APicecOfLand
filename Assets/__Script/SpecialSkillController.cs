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
    public int coolTime;

    private void Start()
    {
        coolTime = 0;
    }

    public void SpecialSkillCheck()
    {
        if(coolTime >=9)
        {
            gameObject.SetActive(true);
        }
        else
        {
            if(gameObject.activeSelf != true)
            {
                coolTime++;
            }
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
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0);
                }

                if(obj!= null)
                {
                    if(obj.GetComponent<MakeArea>().Name != "°­")
                    {
                        obj.GetComponent<SpriteRenderer>().color = Color.red;
                        buttonManger.input.rangeManger.rangeList.Add(obj);
                        buttonManger.input.armyMove = false;
                        buttonManger.enemys[j].GetComponent<EnemyController>().redTiles.Add(obj);
                        skillCheck = true;

                        if (obj.childCount != 0)
                        {
                            obj.tag = "SelectLand";
                        }
                    }
                }
            }
        }
    }
}
