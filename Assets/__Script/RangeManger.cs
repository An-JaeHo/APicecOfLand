﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeManger : MonoBehaviour
{
    public GameObject cnadleObj;
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
                            rangeList.Add(tileManger.tileList[nameOfLand- (17 * (1 + j))]);
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


    public void CandelRange(Transform hitobj)
    {
        int nameOfLand = Int32.Parse(hitobj.parent.parent.name);

        for (int i = 0; i < tileManger.activeChildtileList.Count; i++)
        {
            if(tileManger.activeChildtileList[i].GetChild(0).childCount !=0)
            {
                Transform obj = null;

                if (tileManger.activeChildtileList[i].name == nameOfLand.ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 + 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }
                else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 - 1).ToString())
                {
                    obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
                }

                if(obj != null)
                {
                    

                    if (obj.tag == "Enemy")
                    {
                        obj.GetComponent<MakeEnemy>().BaseHelthPoint -= 500;
                        obj.GetComponent<EnemyController>().HpBarScale();
                        GameObject candle = Instantiate(cnadleObj, obj.parent);
                        candle.transform.localPosition = new Vector3(0, -0.5f);
                        candle.transform.localScale = new Vector3(0.2f, 0.2f);
                        candle.GetComponent<SpriteRenderer>().sortingOrder = obj.parent.GetComponent<SpriteRenderer>().sortingOrder + 1;

                        if (obj.GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
                        {
                            obj.GetComponent<EnemyController>().ani.SetBool("Dead", true);
                            tileManger.buttonManger.enemys.Remove(obj.gameObject);
                        }
                        else
                        {
                            obj.GetComponent<SoldierManger>().ani.SetTrigger("Damage");
                        }
                    }
                    else if (obj.tag == "Boss")
                    {
                        obj.GetComponent<GDController>().HelthPoint -= 500;
                        obj.GetComponent<EnemyController>().HpBarScale();
                        GameObject candle = Instantiate(cnadleObj, obj.parent);
                        candle.transform.localPosition = new Vector3(0, -0.5f);
                        candle.transform.localScale = new Vector3(0.2f, 0.2f);
                        candle.GetComponent<SpriteRenderer>().sortingOrder = obj.parent.GetComponent<SpriteRenderer>().sortingOrder + 1;

                        //if (obj.GetComponent<GDController>().HelthPoint <= 0)
                        //{
                        //    obj.GetComponent<EnemyController>().ani.SetBool("Dead", true);
                        //    tileManger.buttonManger.enemys.Remove(obj.gameObject);
                        //}
                        //else
                        //{
                        //    obj.GetComponent<SoldierManger>().ani.SetTrigger("Damage");
                        //}
                    }
                    //if (tileManger.activeChildtileList[i].GetChild(0).GetChild(0).tag == "Enemy")
                    //{
                    //    tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<MakeEnemy>().BaseHelthPoint -= 500;
                    //    tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<EnemyController>().HpBarScale();

                    //    if (tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
                    //    {
                    //        tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<EnemyController>().ani.SetBool("Dead", true);
                    //        tileManger.buttonManger.enemys.Remove(tileManger.activeChildtileList[i].GetChild(0).GetChild(0).gameObject);
                    //    }
                    //    else
                    //    {
                    //        tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<SoldierManger>().ani.SetTrigger("Damage");
                    //    }
                    //}
                    //else if (tileManger.activeChildtileList[i].GetChild(0).GetChild(0).tag == "Boss")
                    //{
                    //    tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<GDController>().HelthPoint -= 500;
                    //    tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<EnemyController>().HpBarScale();

                    //    if (tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<GDController>().HelthPoint <= 0)
                    //    {
                    //        tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<EnemyController>().ani.SetBool("Dead", true);
                    //        tileManger.buttonManger.enemys.Remove(tileManger.activeChildtileList[i].GetChild(0).GetChild(0).gameObject);
                    //    }
                    //    else
                    //    {
                    //        tileManger.activeChildtileList[i].GetChild(0).GetChild(0).GetComponent<SoldierManger>().ani.SetTrigger("Damage");
                    //    }
                    //}
                }
            }
            
        }
    }
}

    


