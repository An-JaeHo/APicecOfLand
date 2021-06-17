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
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
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
                        if (hit.transform.childCount == 0)
                        {
                            hitObj = hit.transform;

                            if (armyMove)
                            {
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

                                        }
                                        break;

                                    case "Builder":
                                        if (hit.transform.GetComponent<SoldierManger>().movePoint)
                                        {
                                            rangeManger.PlayerMoveRange(hit.transform);
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
                                        ChangeLandInfo();

                                        break;
                                    case "SelectLand":
                                        if (army.tag == "Builder")
                                        {
                                            if (hit.transform.GetComponent<AreaManger>().pureTag == "Grass")
                                            {
                                                bulidUi.GetComponent<BuildController>().land = hit.transform;
                                                bulidUi.GetComponent<BuildController>().CreateWindow();

                                            }
                                            else if (hit.transform.GetComponent<AreaManger>().pureTag == "Wood")
                                            {
                                                bulidUi.GetComponent<BuildController>().land = hit.transform;
                                                bulidUi.GetComponent<BuildController>().CreateWindow();
                                            }
                                            else if (hit.transform.GetComponent<AreaManger>().pureTag == "Stone")
                                            {
                                                bulidUi.GetComponent<BuildController>().land = hit.transform;
                                                bulidUi.GetComponent<BuildController>().CreateWindow();
                                            }
                                            else if (hit.transform.GetComponent<AreaManger>().pureTag == "Area"
                                                && hit.transform.GetComponent<MakeArea>().Destroy != true)
                                            {
                                                bulidUpgradeUi.GetComponent<BuildController>().land = hit.transform;
                                                bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().Output;
                                                bulidUpgradeUi.GetComponent<BuildController>().ReadAreaInfo();
                                            }

                                            ChangeLandInfo();
                                        }
                                        else
                                        {
                                            army.transform.SetParent(hit.transform);
                                            moveSoldier.move = true;

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
                                //mouseCheck = true;
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
            rangeManger.rangeList[i].transform.tag = rangeManger.rangeList[i].GetComponent<AreaManger>().pureTag;
        }

        rangeManger.rangeList.Clear();
    }
}
