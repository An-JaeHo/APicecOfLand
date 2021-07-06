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

        
        for (int i = 0; i < tileManger.tileList.Count; i++)
        {
            // 오른쪽 
            if (tileManger.tileList[i].parent.name == (Int32.Parse(hitobj.parent.parent.name) + 1).ToString())
            {
                if (Int32.Parse(hitobj.parent.parent.name) % 17 != 0 
                    && tileManger.tileList[i].gameObject.activeSelf == true
                    && tileManger.tileList[i].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[i].childCount == 0)
                    {
                        //tileManger.activeChildtileList[i].transform.GetChild(0).GetComponent<AreaManger>().pureTag = tileManger.activeChildtileList[i].transform.tag;
                        tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[i].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[i]);

                        if (hitobj.GetComponent<MakeSoldier>().Movement >= 2)
                        {
                            for (int j = 1; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
                            {
                                int nameOfLand = Int32.Parse(tileManger.tileList[i].parent.name) - 1;

                                if (nameOfLand % 17 != 0
                                    && tileManger.tileList[nameOfLand + j].gameObject.activeSelf == true
                                    && tileManger.tileList[nameOfLand + j].GetComponent<MakeArea>().Movement)
                                {
                                    if (tileManger.tileList[nameOfLand + j].childCount == 0)
                                    {
                                        //Debug.Log(tileManger.tileList[nameOfLand + j].parent.name);
                                        tileManger.tileList[nameOfLand + j].GetComponent<SpriteRenderer>().color = Color.cyan;
                                        tileManger.tileList[nameOfLand + j].tag = "SelectLand";
                                        rangeList.Add(tileManger.tileList[nameOfLand + j]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if(tileManger.tileList[i].GetChild(0).transform.tag == "Enemy" || tileManger.tileList[i].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[i].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[i]);
                        }
                        
                    }
                }
            }

            //왼쪽
            if (tileManger.tileList[i].parent.name == (Int32.Parse(hitobj.parent.parent.name) - 1).ToString())
            {
                if (Int32.Parse(hitobj.parent.parent.name) % 17 != 0
                    && tileManger.tileList[i].gameObject.activeSelf == true
                    && tileManger.tileList[i].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[i].childCount == 0)
                    {
                        //tileManger.activeChildtileList[i].transform.GetChild(0).GetComponent<AreaManger>().pureTag = tileManger.activeChildtileList[i].transform.tag;
                        tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[i].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[i]);

                        if (hitobj.GetComponent<MakeSoldier>().Movement >= 2)
                        {
                            for (int j = 1; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
                            {
                                int nameOfLand = Int32.Parse(tileManger.tileList[i].parent.name) - 1;

                                if (nameOfLand % 17 != 0
                                    && tileManger.tileList[nameOfLand - j].gameObject.activeSelf == true
                                    && tileManger.tileList[nameOfLand - j].GetComponent<MakeArea>().Movement)
                                {
                                    if (tileManger.tileList[nameOfLand - j].childCount == 0)
                                    {
                                        tileManger.tileList[nameOfLand - j].GetComponent<SpriteRenderer>().color = Color.cyan;
                                        tileManger.tileList[nameOfLand - j].tag = "SelectLand";
                                        rangeList.Add(tileManger.tileList[nameOfLand - j]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy" || tileManger.tileList[i].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[i].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[i]);
                        }

                    }
                }

                
            }

            //아래
            if (tileManger.tileList[i].parent.name == (Int32.Parse(hitobj.parent.parent.name) + 17).ToString())
            {
                if (Int32.Parse(hitobj.parent.parent.name) % 17 != 0
                    && tileManger.tileList[i].gameObject.activeSelf == true
                    && tileManger.tileList[i].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[i].childCount == 0)
                    {
                        //tileManger.activeChildtileList[i].transform.GetChild(0).GetComponent<AreaManger>().pureTag = tileManger.activeChildtileList[i].transform.tag;
                        tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[i].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[i]);

                        if (hitobj.GetComponent<MakeSoldier>().Movement >= 2)
                        {
                            for (int j = 1; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
                            {
                                int nameOfLand = Int32.Parse(tileManger.tileList[i].parent.name) - 1;

                                if (nameOfLand % 17 != 0
                                    && tileManger.tileList[nameOfLand + j * 17].gameObject.activeSelf == true
                                    && tileManger.tileList[nameOfLand + j * 17].GetComponent<MakeArea>().Movement)
                                {
                                    if (tileManger.tileList[nameOfLand + j * 17].childCount == 0)
                                    {
                                        tileManger.tileList[nameOfLand + j * 17].GetComponent<SpriteRenderer>().color = Color.cyan;
                                        tileManger.tileList[nameOfLand + j * 17].tag = "SelectLand";
                                        rangeList.Add(tileManger.tileList[nameOfLand + j * 17]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy" || tileManger.tileList[i].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[i].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[i]);
                        }

                    }
                }

                
            }

            //위
            if (tileManger.tileList[i].parent.name == (Int32.Parse(hitobj.parent.parent.name) - 17).ToString())
            {
                if (Int32.Parse(hitobj.parent.parent.name) % 17 != 0
                    && tileManger.tileList[i].gameObject.activeSelf == true
                    && tileManger.tileList[i].GetComponent<MakeArea>().Movement)
                {
                    if (tileManger.tileList[i].childCount == 0)
                    {
                        //tileManger.activeChildtileList[i].transform.GetChild(0).GetComponent<AreaManger>().pureTag = tileManger.activeChildtileList[i].transform.tag;
                        tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.cyan;
                        tileManger.tileList[i].tag = "SelectLand";
                        rangeList.Add(tileManger.tileList[i]);

                        if (hitobj.GetComponent<MakeSoldier>().Movement >= 2)
                        {
                            for (int j = 1; j < hitobj.GetComponent<MakeSoldier>().Movement; j++)
                            {
                                int nameOfLand = Int32.Parse(tileManger.tileList[i].parent.name) - 1;

                                if (nameOfLand % 17 != 0
                                    && tileManger.tileList[nameOfLand - j * 17].gameObject.activeSelf == true
                                    && tileManger.tileList[nameOfLand - j * 17].GetComponent<MakeArea>().Movement)
                                {
                                    if (tileManger.tileList[nameOfLand - j * 17].childCount == 0)
                                    {
                                        tileManger.tileList[nameOfLand - j * 17].GetComponent<SpriteRenderer>().color = Color.cyan;
                                        tileManger.tileList[nameOfLand - j * 17].tag = "SelectLand";
                                        rangeList.Add(tileManger.tileList[nameOfLand - j * 17]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy" || tileManger.tileList[i].GetChild(0).transform.tag == "GD")
                        {
                            tileManger.tileList[i].GetComponent<SpriteRenderer>().color = Color.red;
                            tileManger.tileList[i].tag = "SelectLand";
                            rangeList.Add(tileManger.tileList[i]);
                        }

                    }
                }

                
            }
        }
        
        input.army = hitobj;
    }
}

    


