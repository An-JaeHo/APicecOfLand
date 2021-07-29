using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{
    public Camera gameCamera;
    public TileManger Land;
    public LayerMask layerMask;
    public Transform hitObj;
    public Transform landObj;
    public Transform hitObjPreFeb;
    public GameObject objectPool;
    public Button button;
    public Transform army;
    public RangeManger rangeManger;

    public bool armyMove;
    public SoldierManger moveSoldier;

    public GameObject bulidUi;
    public GameObject bulidUpgradeUi;
    public GameObject BarrackUi;
    public GameObject armyUpgradeUi;
    private Vector3 MouseStart;
    public float time;


    public bool mouseCheck;

    private void Start()
    {
        gameCamera = Camera.main;
        Land = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        rangeManger = GetComponent<RangeManger>();
        armyMove = true;

        mouseCheck = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameCamera.transform.position.z);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = gameCamera.transform.position.z;
        }
        else if (Input.GetMouseButton(1))
        {
            var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameCamera.transform.position.z);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.z = gameCamera.transform.position.z;
            gameCamera.transform.position = gameCamera.transform.position - (MouseMove - MouseStart);
        }

        if (mouseCheck)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, gameCamera.transform.forward, 800);

            if (hit)
            {
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
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (armyMove)
                        {
                            hitObj = hit.transform;
                            if (hitObjPreFeb != null && hitObjPreFeb.GetComponent<SpriteRenderer>().color == Color.red)
                            {
                                hitObjPreFeb.GetComponent<SpriteRenderer>().color = Color.white;
                            }

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

                                case "Builder":
                                    if (hit.transform.GetComponent<SoldierManger>().movePoint)
                                    {
                                        rangeManger.BuilderMoveRange(hit.transform);
                                        armyMove = false;
                                        moveSoldier = hit.transform.GetComponent<SoldierManger>();
                                    }
                                    break;
                                default:
                                    ChangeLandInfo();
                                    time = 0;
                                    break;
                            }
                        }
                        else
                        {
                            hitObj = hit.transform;
                            switch (hit.transform.tag)
                            {
                                case "Enemy":
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                    ChangeLandInfo();
                                    break;
                                case "GD":
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                    ChangeLandInfo();

                                    break;
                                case "SelectLand":
                                    if (army.tag == "Builder")
                                    {
                                        if (hit.transform.GetComponent<MakeArea>().Type == "Grass")
                                        {
                                            if (hit.transform.GetComponent<MakeArea>().Destroy == true)
                                            {

                                            }
                                            else
                                            {
                                                landObj = hit.transform;
                                                mouseCheck = false;
                                                bulidUi.GetComponent<BuildController>().land = hit.transform;
                                                bulidUi.GetComponent<BuildController>().CreateWindow();
                                            }
                                        }
                                        else if (hit.transform.GetComponent<MakeArea>().Type == "Area"
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

                                        ChangeLandInfo();
                                    }
                                    else
                                    {
                                        if(int.Parse(army.parent.parent.name) +1  == int.Parse(hit.transform.parent.name))
                                        {
                                            army.transform.GetChild(1).localScale = new Vector3(0.4f, 0.4f);
                                        }
                                        else if (int.Parse(army.parent.parent.name) - 1 == int.Parse(hit.transform.parent.name))
                                        {
                                            army.transform.GetChild(1).localScale = new Vector3(-0.4f, 0.4f);
                                        }

                                        //if (int.Parse(input.army.parent.parent.name) > int.Parse(input.landObj.transform.parent.name))
                                        //{
                                        //    input.army.GetChild(1).transform.localScale = new Vector3(-0.8f, 1);
                                        //}
                                        //else
                                        //{
                                        //    input.army.GetChild(1).transform.localScale = new Vector3(0.8f, 1);
                                        //}

                                        army.transform.SetParent(hit.transform);
                                        moveSoldier.move = true;
                                        army.transform.GetComponent<SoldierManger>().SoldierAction();

                                        ChangeLandInfo();
                                    }

                                    break;


                                default:
                                    ChangeLandInfo();
                                    break;
                            }
                            armyMove = true;
                        }
                    }

                }

                if (Input.GetMouseButtonUp(0))
                {
                    time = 0;

                    switch (hit.transform.tag)
                    {
                        case "Army":
                            if (hit.transform.GetComponent<SoldierManger>().movePoint)
                            {
                                rangeManger.PlayerMoveRange(hit.transform);
                                armyMove = false;
                                moveSoldier = hit.transform.GetComponent<SoldierManger>();
                                Land.CheckTile();
                            }
                            break;
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
    }


    public void ChangeLandInfo()
    {
        for (int i = 0; i < rangeManger.rangeList.Count; i++)
        {
            rangeManger.rangeList[i].GetComponent<SpriteRenderer>().color = rangeManger.rangeList[i].GetComponent<AreaManger>().pureColor;

            if (rangeManger.rangeList[i].GetComponent<MakeArea>().Type == "Area")
            {
                rangeManger.rangeList[i].transform.tag = "Area";
            }

            if (rangeManger.rangeList[i].GetComponent<MakeArea>().Name == "병영")
            {
                rangeManger.rangeList[i].transform.tag = "Barracks";
            }

            if (rangeManger.rangeList[i].GetComponent<MakeArea>().Type == "Grass")
            {
                rangeManger.rangeList[i].transform.tag = "Grass";
            }

            if (rangeManger.rangeList[i].GetComponent<AreaManger>().pureTag == "Capital")
            {
                rangeManger.rangeList[i].transform.tag = "Capital";
            }
        }

        
        rangeManger.rangeList.Clear();
    }
}
