using System.Collections;
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
        input.specialSkillController.skillCheck = false;
        //for (int i = 0; i < tileManger.activeChildtileList.Count; i++)
        //{
        //    if(tileManger.activeChildtileList[i].GetChild(0).childCount !=0)
        //    {
        //        Transform obj = null;

        //        if (tileManger.activeChildtileList[i].name == nameOfLand.ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand + 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand - 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 + 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand + 17 - 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 + 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }
        //        else if (tileManger.activeChildtileList[i].name == (nameOfLand - 17 - 1).ToString())
        //        {
        //            obj = tileManger.activeChildtileList[i].GetChild(0).GetChild(0);
        //        }

        //        if(obj != null)
        //        {
        //            for (int z = 0; z < obj.GetComponent<EnemyController>().redTiles.Count; z++)
        //            {
        //                if (obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Name == "우주선")
        //                {
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Name = null;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Type = "Grass";
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Grade = 0;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Movement = true;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Destroy = false;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Repair = false;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Effect = null;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<SpriteRenderer>().color = Color.white;
        //                    obj.GetComponent<EnemyController>().redTiles[z].GetComponent<AreaManger>().pureColor = Color.white;
        //                    obj.GetComponent<EnemyController>().redTiles[z].tag = "Grass";

        //                    for (int j = 0; j < tileManger.destroyAreaObj.Length; j++)
        //                    {
        //                        if (obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Code==tileManger.destroyAreaObj[j].name)
        //                        {
        //                            obj.GetComponent<EnemyController>().redTiles[z].GetComponent<MakeArea>().Picture=tileManger.destroyAreaObj[j];
        //                            obj.GetComponent<EnemyController>().redTiles[z].GetComponent<SpriteRenderer>().sprite=tileManger.destroyAreaObj[j];
        //                        }
        //                    }

        //                    if (obj.GetComponent<EnemyController>().redTiles[z].childCount == 0)
        //                    {
        //                        GameObject tileCandle = Instantiate(cnadleObj);
        //                        tileCandle.SetActive(true);
        //                        tileCandle.transform.parent = obj.GetComponent<EnemyController>().redTiles[z];
        //                        tileCandle.transform.localPosition = new Vector3(0, -0.5f);
        //                        tileCandle.transform.localScale = new Vector3(0.2f, 0.2f);
        //                        tileCandle.GetComponent<SpriteRenderer>().sortingOrder = obj.GetComponent<EnemyController>().redTiles[z].GetComponent<SpriteRenderer>().sortingOrder + 1;
        //                    }

        //                    tileManger.enemyLand.Remove(obj.GetComponent<EnemyController>().redTiles[z]);
        //                }
        //            }

        //            GameObject candle = Instantiate(cnadleObj, obj.parent);
        //            candle.transform.localPosition = new Vector3(0, -0.5f);
        //            candle.transform.localScale = new Vector3(0.2f, 0.2f);
        //            candle.GetComponent<SpriteRenderer>().sortingOrder = obj.parent.GetComponent<SpriteRenderer>().sortingOrder + 1;

        //            if (obj.tag == "Enemy")
        //            {
        //                obj.GetComponent<MakeEnemy>().BaseHelthPoint -= 300;
        //                obj.GetComponent<EnemyController>().HpBarScale();

        //                if (obj.GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
        //                {
        //                    obj.GetComponent<EnemyController>().ani.SetBool("Dead", true);
        //                    tileManger.buttonManger.enemys.Remove(obj.gameObject);
        //                }
        //                else
        //                {
        //                    obj.GetComponent<SoldierManger>().ani.SetTrigger("Damage");
        //                }
        //            }
        //            else if (obj.tag == "Boss")
        //            {
        //                obj.GetComponent<GDController>().HelthPoint -= 500;
        //                obj.GetComponent<EnemyController>().HpBarScale();

        //                //if (obj.GetComponent<GDController>().HelthPoint <= 0)
        //                //{
        //                //    obj.GetComponent<EnemyController>().ani.SetBool("Dead", true);
        //                //    tileManger.buttonManger.enemys.Remove(obj.gameObject);
        //                //}
        //                //else
        //                //{
        //                //    obj.GetComponent<SoldierManger>().ani.SetTrigger("Damage");
        //                //}
        //            }
        //        }
        //    }
        //}
    }
}

    


