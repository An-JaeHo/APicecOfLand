using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInputManger : MonoBehaviour
{
    public Camera gameCamera;
    public bool mouseCheck; 
    public bool armyMove;
    public Transform hitObj;
    public Transform landObj;


    //제작해야되는것
    public GameObject BarrackUi;
    public GameObject bulidUi;

    void Start()
    {
        gameCamera = Camera.main;
        mouseCheck = true;
        armyMove = true;
    }
    
    void Update()
    {
        
    }

    /*
    private void MouseHit()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, gameCamera.transform.forward, 800);

        if (hit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (armyMove)
                {
                    hitObj = hit.transform;

                    switch (hit.transform.tag)
                    {
                        case "Barracks":
                            if (hit.transform.GetComponent<MakeArea>().Destroy == false)
                            {
                                BarrackUi.SetActive(true);
                                BarrackUi.GetComponent<BarrackController>().land = hit.transform;
                                BarrackUi.GetComponent<BarrackController>().SwordButton();
                                mouseCheck = false;
                            }
                            break;
                        case "Grass":
                            // 요리사 삭제
                            landObj = hit.transform;
                            mouseCheck = false;
                            bulidUi.GetComponent<BuildController>().land = hit.transform;
                            bulidUi.GetComponent<BuildController>().CreateWindow();
                            armyMove = false;
                            break;
                        case "Area":
                            break;
                        case "Army":
                            if (hit.transform.GetComponent<SoldierManger>().movePoint)
                            {
                                rangeManger.PlayerMoveRange(hit.transform);
                                armyMove = false;
                                moveSoldier = hit.transform.GetComponent<SoldierManger>();
                                Land.CheckTile();
                            }

                            break;
                        default:
                            ChangeLandInfo();
                            break;
                    }
                }
                else
                {
                    hitObj = hit.transform;
                    switch (hit.transform.tag)
                    {
                        case "Enemy":
                            if (hit.transform.parent.tag == "SelectLand")
                            {
                                moveSoldier.enemy = hit.transform;
                                moveSoldier.attack = true;
                                army.transform.GetComponent<SoldierManger>().SoldierAction();
                            }
                            break;
                        case "GD":
                            if (hit.transform.parent.tag == "SelectLand")
                            {
                                moveSoldier.enemy = hit.transform;
                                moveSoldier.attack = true;
                                army.transform.GetComponent<SoldierManger>().SoldierAction();
                            }
                            break;
                        case "SelectLand":
                            if (army.tag == "Builder")
                            {
                                if (hit.transform.GetComponent<MakeArea>().Type == "Area"
                                    && hit.transform.GetComponent<MakeArea>().Destroy != true)
                                {
                                    if (hit.transform.GetComponent<MakeArea>().Name == "우유")
                                    {
                                        bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().MilkOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "밀가루")
                                    {
                                        bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().FlourOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "설탕")
                                    {
                                        bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().SugarOutput;
                                    }
                                    bulidUpgradeUi.GetComponent<BuildController>().land = hit.transform;
                                    bulidUpgradeUi.GetComponent<BuildController>().ReadAreaInfo();
                                }
                            }
                            else
                            {
                                if (int.Parse(army.parent.parent.name) >= int.Parse(hit.transform.parent.name)
                                         && Mathf.Abs(int.Parse(army.parent.parent.name) - int.Parse(hit.transform.parent.name)) <= 10)
                                {
                                    army.transform.GetChild(1).localScale = new Vector3(-0.4f, 0.4f);
                                }
                                else if (int.Parse(army.parent.parent.name) < int.Parse(hit.transform.parent.name)
                                    && Mathf.Abs(int.Parse(army.parent.parent.name) - int.Parse(hit.transform.parent.name)) <= 10)
                                {
                                    army.transform.GetChild(1).localScale = new Vector3(0.4f, 0.4f);
                                }

                                army.transform.SetParent(hit.transform);
                                moveSoldier.move = true;
                                army.transform.GetComponent<SoldierManger>().SoldierAction();
                                army.transform.GetComponent<SoldierManger>().movePoint = false;
                            }
                            break;


                        default:

                            break;
                    }
                    ChangeLandInfo();
                    armyMove = true;
                }
            }

            if (Input.GetMouseButton(0))
            {
                time += Time.deltaTime;

                if (time >= 3)
                {
                    switch (hit.transform.tag)
                    {
                        case "Army":
                            armyUpgradeUi.SetActive(true);
                            armyUpgradeUi.GetComponent<ArmyUpgrade>().UpdateArmyInfo(hit.transform);
                            break;
                    }
                    return;
                }
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeLandInfo();
            }
        }
    }
    */
}
