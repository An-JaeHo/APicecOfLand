using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TutorialRangeManger : MonoBehaviour
{
    public TutorialTileManger tileManger;
    public TutorialInputManger input;
    public GameObject rangePrefeb;
    public List<Transform> rangeList;
    public List<Transform> enemyRangeList;

    void Start()
    {
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
    }

    public void PlayerMoveRange(Transform hitobj)
    {
        Transform rect = hitobj.parent.GetComponent<Transform>();
        MakeSoldier soldier = hitobj.GetComponent<MakeSoldier>();

        int nameOfLand = Int32.Parse(hitobj.parent.parent.name) - 1;

        // ¿À¸¥ÂÊ 
        if (hitobj.GetComponent<MakeSoldier>().Movement >= 1)
        {
            //for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            //{
            //    if(tileManger.tileList[nameOfLand + (1 + j)] !=null)
            //    {
            //        //¿À
            //        if (nameOfLand % 17 != 0
            //            && tileManger.tileList[nameOfLand + (1 + j)].gameObject.activeSelf == true
            //            && tileManger.tileList[nameOfLand + (1 + j)].GetComponent<MakeArea>().Movement)
            //        {
            //            if (tileManger.tileList[nameOfLand + (1 + j)].childCount == 0)
            //            {
            //                tileManger.tileList[nameOfLand + (1 + j)].GetComponent<SpriteRenderer>().color = Color.cyan;
            //                tileManger.tileList[nameOfLand + (1 + j)].tag = "SelectLand";
            //                rangeList.Add(tileManger.tileList[nameOfLand + (1 + j)]);
            //            }
            //            else
            //            {
            //                if (tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "Enemy"
            //                    || tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "GD")
            //                {
            //                    tileManger.tileList[nameOfLand + (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
            //                    tileManger.tileList[nameOfLand + (1 + j)].tag = "SelectLand";
            //                    rangeList.Add(tileManger.tileList[nameOfLand + (1 + j)]);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            //{
            //    if (tileManger.tileList[nameOfLand - (1 + j)] != null)
            //    {
            //        //¿Þ

            //        if (tileManger.tileList[nameOfLand - (1 + j)].childCount == 0)
            //        {
            //            tileManger.tileList[nameOfLand - (1 + j)].GetComponent<SpriteRenderer>().color = Color.cyan;
            //            tileManger.tileList[nameOfLand - (1 + j)].tag = "SelectLand";
            //            rangeList.Add(tileManger.tileList[nameOfLand - (1 + j)]);
            //        }
            //        else
            //        {
            //            if (tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "Enemy"
            //                || tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "GD")
            //            {
            //                tileManger.tileList[nameOfLand - (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
            //                tileManger.tileList[nameOfLand - (1 + j)].tag = "SelectLand";
            //                rangeList.Add(tileManger.tileList[nameOfLand - (1 + j)]);
            //                break;
            //            }

            //        }
            //    }
            //}
            
            for (int i = 0; i < 1; i++)
            {
                tileManger.tileList[nameOfLand -(1+i)].GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

                if (tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).childCount == 0)
                {
                    tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).GetComponent<SpriteRenderer>().color = Color.cyan;
                    tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).tag = "SelectLand";
                    rangeList.Add(tileManger.tileList[nameOfLand - (1 + i)]);
                }
                else
                {
                    if (tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).GetChild(0).transform.tag == "Enemy"
                        || tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).transform.tag == "GD")
                    {
                        tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                        tileManger.tileList[nameOfLand - (1 + i)].GetChild(0).tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[nameOfLand - (1 + i)]);
                        input.talkManger.stopTalkNum = 5;
                        input.talkManger.talkCheck = true;
                        break;
                    }
                }
            }
        }

        input.army = hitobj;
    }
}
