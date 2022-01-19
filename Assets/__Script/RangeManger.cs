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
    public GameObject specialSkillPreFeb;
    public SpecialSkillController specialSkillController;

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
        specialSkillController.coolTime = 0;
        List<Transform> redTiles = hitobj.GetComponent<EnemyController>().redTiles;

        if(redTiles.Count != 0)
        {
            for (int i = 0; i < redTiles.Count; i++)
            {
                if (redTiles[i].childCount != 0)
                {
                    if (redTiles[i].GetChild(0).tag == "Enemy")
                    {
                        GameObject specialSkill = Instantiate(specialSkillPreFeb, redTiles[i].GetChild(0).transform);
                        specialSkill.transform.localPosition = new Vector3(0, -0.9f);
                        specialSkill.transform.localScale = new Vector3(0.4f, 0.4f);

                        if (redTiles[i].GetChild(0).tag == "Enemy")
                        {
                            redTiles[i].GetChild(0).GetComponent<MakeEnemy>().BaseHelthPoint -= 300;

                            if (redTiles[i].GetChild(0).GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
                            {
                                redTiles[i].GetChild(0).GetComponent<EnemyController>().ani.SetBool("Dead", true);
                                tileManger.buttonManger.enemys.Remove(redTiles[i].GetChild(0).gameObject);
                                tileManger.CheckTile();
                            }
                            else
                            {
                                redTiles[i].GetChild(0).GetComponent<EnemyController>().ani.SetTrigger("Damage");
                            }
                        }
                        else
                        {
                            redTiles[i].GetChild(0).GetComponent<GDController>().HelthPoint -= 300;

                            if (redTiles[i].GetChild(0).GetComponent<GDController>().HelthPoint <= 0)
                            {
                                redTiles[i].GetChild(0).GetComponent<EnemyController>().ani.SetBool("Dead", true);
                                tileManger.buttonManger.enemys.Remove(redTiles[i].gameObject);
                                tileManger.bossHP.SetActive(false);
                                tileManger.CheckTile();
                            }
                            else
                            {
                                redTiles[i].GetChild(0).GetComponent<EnemyController>().ani.SetTrigger("Damage");
                            }
                        }

                        redTiles[i].GetChild(0).GetComponent<EnemyController>().HpBarScale();

                    }
                }

                if (redTiles[i].GetComponent<MakeArea>().Name == "우주선")
                {
                    GameObject specialSkill = Instantiate(specialSkillPreFeb, redTiles[i]);
                    specialSkill.transform.localPosition = new Vector3(0, -0.6f);
                    specialSkill.transform.localScale = new Vector3(0.4f, 0.4f);

                    for (int j = 0; j < tileManger.destroyAreaObj.Length; j++)
                    {
                        if (redTiles[i].GetComponent<MakeArea>().Code == tileManger.destroyAreaObj[j].name)
                        {
                            redTiles[i].GetComponent<MakeArea>().Picture = tileManger.destroyAreaObj[j];
                            redTiles[i].GetComponent<SpriteRenderer>().sprite = tileManger.destroyAreaObj[j];
                        }
                    }

                    redTiles[i].GetComponent<MakeArea>().Name = null;
                    redTiles[i].GetComponent<MakeArea>().Type = "Grass";
                    redTiles[i].GetComponent<MakeArea>().Grade = 0;
                    redTiles[i].GetComponent<MakeArea>().UpgradeFlour = 0;
                    redTiles[i].GetComponent<MakeArea>().UpgradeSugar = 0;
                    redTiles[i].GetComponent<MakeArea>().MilkOutput = 0;
                    redTiles[i].GetComponent<MakeArea>().FlourOutput = 0;
                    redTiles[i].GetComponent<MakeArea>().SugarOutput = 0;
                    redTiles[i].GetComponent<MakeArea>().Movement = true;
                    redTiles[i].GetComponent<MakeArea>().Destroy = false;
                    redTiles[i].GetComponent<MakeArea>().Repair = false;
                    redTiles[i].GetComponent<MakeArea>().Effect = null;
                    redTiles[i].GetComponent<SpriteRenderer>().color = Color.white;
                    redTiles[i].GetComponent<AreaManger>().pureColor = Color.white;
                    tileManger.enemyLand.Remove(redTiles[i]);
                    redTiles[i].tag = "Grass";
                }


            }
        }
    }
}

    


