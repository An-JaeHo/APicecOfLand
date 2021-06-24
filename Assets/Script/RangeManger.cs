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
                        if(tileManger.tileList[i].GetChild(0).transform.tag == "Enemy")
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
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy")
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
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy")
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
                        if (tileManger.tileList[i].GetChild(0).transform.tag == "Enemy")
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

    public List<Transform> EnemyRange(GameObject obj)
    {
        //List<Transform> mylist = new List<Transform>(); ;
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();

        //대각 2칸거리 282
        foreach (var tileInfo in tileManger.activeChildtileList)
        {
            if ((Mathf.Abs((int)Vector3.Distance(obj.transform.parent.position, tileInfo.GetChild(0).transform.position)) <= 141*10)
                && obj.transform.parent.position != tileInfo.GetChild(0).transform.GetComponent<Transform>().position)
            {
                //tileTag.Add(tileInfo.transform.tag);
                enemyRangeList.Add(tileInfo.GetChild(0));
            }
        }
        
        return enemyRangeList;
    }

    public List<Transform> BulidingRange(Transform transform)
    {
        Transform rect = transform.parent.GetComponent<Transform>();

        List<Transform> mylist = new List<Transform>(); ;

        //대각 2칸거리 282
        foreach (var tileInfo in tileManger.activeChildtileList)
        {
            if ((Mathf.Abs((int)Vector3.Distance(rect.position, tileInfo.transform.position)) <= 282)
                && rect.position != tileInfo.transform.GetComponent<Transform>().position)
            {
                mylist.Add(tileInfo);
            }
        }

        return mylist;
    }

    public bool DeleteSkillRange(Transform my)
    {

        return true;
    }

}

    


