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

        // 오른쪽 
        if (hitobj.GetComponent<MakeSoldier>().Movement >= 1)
        {
            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //오
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand + (1 + j)].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand + (1 + j)].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand + (1 + j)].childCount == 0)
                    {
                        tileManger.tileList[nameOfLand + (1 + j)].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[nameOfLand + (1 + j)].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[nameOfLand + (1 + j)]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //왼
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (1 + j)].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (1 + j)].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand - (1 + j)].childCount == 0)
                    {
                        tileManger.tileList[nameOfLand - (1 + j)].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[nameOfLand - (1 + j)].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[nameOfLand - (1 + j)]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //위
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand + (17 * (1 + j))].childCount == 0)
                    {
                        tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[nameOfLand + (17 * (1 + j))].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[nameOfLand + (17 * (1 + j))]);

                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //아래
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand - (17 * (1 + j))].childCount == 0)
                    {
                        tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[nameOfLand - (17 * (1 + j))].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[nameOfLand - (17 * (1 + j))]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        input.army = hitobj;
    }

    public void PlayerAttackRange(Transform hitobj)
    {
        Transform rect = hitobj.parent.GetComponent<Transform>();
        MakeSoldier soldier = hitobj.GetComponent<MakeSoldier>();
        int nameOfLand = Int32.Parse(hitobj.parent.parent.name) - 1;

        // 오른쪽 
        if (hitobj.GetComponent<MakeSoldier>().attackCount >= 1)
        {
            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().AttackRange; j++)
            {
                //오
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand + (1 + j)].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand + (1 + j)].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand + (1 + j)].childCount != 0)
                    {
                        if (tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand + (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand + (1 + j)].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand + (1 + j)]);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //왼
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (1 + j)].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (1 + j)].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand - (1 + j)].childCount != 0)
                    {
                        if (tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand - (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand - (1 + j)].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand - (1 + j)]);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //위
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand + (17 * (1 + j))].childCount != 0)
                    {
                        if (tileManger.tileList[nameOfLand + (17 * (1 + j))].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand + (17 * (1 + j))].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand + (17 * (1 + j))].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand + (17 * (1 + j))]);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //아래
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[nameOfLand - (17 * (1 + j))].childCount != 0)
                    {
                        if (tileManger.tileList[nameOfLand - (17 * (1 + j))].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand - (17 * (1 + j))].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand - (17 * (1 + j))].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand - (17 * (1 + j))]);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        input.army = hitobj;
    }
}
