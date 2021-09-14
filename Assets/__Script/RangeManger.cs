using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeManger : MonoBehaviour
{
    public TileManger tileManger;
    public InputManger input;
    public GameObject rangePrefeb;
    public List<Transform> rangeList;
    public List<Transform> enemyRangeList;

    void Start()
    {
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManger>();
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
                        if (tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand + (1 + j)].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand + (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand + (1 + j)].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand + (1 + j)]);
                            break;
                        }
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
                        if (tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand - (1 + j)].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand - (1 + j)].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand - (1 + j)].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand - (1 + j)]);
                            break;
                        }
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
                        if (tileManger.tileList[nameOfLand + (17 * (1 + j))].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand + (17 * (1 + j))].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand + (17 * (1 + j))].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand + (17 * (1 + j))]);
                            break;
                        }
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
                        if (tileManger.tileList[nameOfLand - (17 * (1 + j))].GetChild(0).transform.tag == "Enemy"
                            || tileManger.tileList[nameOfLand - (17 * (1 + j))].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[nameOfLand - (17 * (1 + j))].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[nameOfLand - (17 * (1 + j))]);
                            break;
                        }
                    }
                }
            }
        }

        input.army = hitobj;
    }

    public void BuilderMoveRange(Transform hitobj)
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
                    && tileManger.tileList[nameOfLand + (1 + j)].GetComponent<MakeArea>().Movement
                    && tileManger.tileList[nameOfLand + (1 + j)].tag != "Capital")
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
                else
                {
                    break;
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //왼
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (1 + j)].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (1 + j)].GetComponent<MakeArea>().Movement
                    && tileManger.tileList[nameOfLand - (1 + j)].tag != "Capital")
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
                else
                {
                    break;
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //위
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].GetComponent<MakeArea>().Movement
                    && tileManger.tileList[nameOfLand + (17 * (1 + j))].tag != "Capital")
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
                else
                {
                    break;
                }
            }

            for (int j = 0; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
            {
                //아래
                if (nameOfLand % 17 != 0
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].gameObject.activeSelf == true
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].GetComponent<MakeArea>().Movement
                    && tileManger.tileList[nameOfLand - (17 * (1 + j))].tag != "Capital")
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
                else
                {
                    break;
                }
            }
        }

        input.army = hitobj;
    }
}

    


