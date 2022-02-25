using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{
    public TileManger Land;
    public LayerMask layerMask;
    public Transform hitObj;
    public Transform landObj;
    public Transform hitObjPreFeb;
    public GameObject objectPool;
    public Button button;
    public Transform army;
    public RangeManger rangeManger;
    public ButtonManger buttonManger;
    public bool armyMove;
    public SoldierManger moveSoldier;

    public GameObject bulidUi;
    public GameObject bulidUpgradeUi;
    public GameObject BarrackUi;
    public GameObject armyUpgradeUi;
    public GameObject repairUi;
    public Image monsterMoveCheckImgae;
    private Vector3 MouseStart;
    public float time;
    public bool touchCheck;
    public bool mouseCheck;
    

    //카메라이동제한
    public Camera gameCamera;
    public Vector3 startPos;
    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;
    private int distance;
    private int moveDistance;

    public SpecialSkillController specialSkillController;

    private void Start()
    {
        gameCamera = Camera.main;
        Land = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        rangeManger = GetComponent<RangeManger>();
        armyMove = true;
        minPosX = -200;
        maxPosX = 1200;
        minPosY = -1600;
        maxPosY = -200;
        startPos = new Vector3(550, -900);
        mouseCheck = true;
        touchCheck = false;
    }

    private void Update()
    {
        if (mouseCheck)
        {
            time += Time.deltaTime;

            if (Input.touchCount > 0)
            {
                //TouchCameraMove();
                TouchHit();
            }
            else
            {
                MouseHit();
                MouseCameraMove();
            }
        }
    }

    //클릭 용도
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
                    if (hitObjPreFeb != null && hitObjPreFeb.GetComponent<SpriteRenderer>().color == Color.red)
                    {
                        hitObjPreFeb.GetComponent<SpriteRenderer>().color = Color.white;
                    }

                    switch (hit.transform.tag)
                    {
                        case "Barracks":
                            if(Land.attackTurnCheck)
                            {
                                if (hit.transform.GetComponent<MakeArea>().Destroy == false)
                                {
                                    BarrackUi.SetActive(true);
                                    BarrackUi.GetComponent<BarrackController>().land = hit.transform;
                                    BarrackUi.GetComponent<BarrackController>().SwordButton();
                                    BarrackUi.GetComponent<BarrackController>().soldierMakeButton.GetComponent<Button>().interactable = false;
                                    mouseCheck = false;
                                }
                            }
                            break;

                        case "Army":
                            if (hit.transform.GetComponent<SoldierManger>().movePoint || hit.transform.GetComponent<MakeSoldier>().MovementNumber > 0)
                            {
                                rangeManger.PlayerMoveRange(hit.transform);
                            }
                                rangeManger.PlayerAttackRange(hit.transform);
                                armyMove = false;
                                moveSoldier = hit.transform.GetComponent<SoldierManger>();
                                Land.CheckTile();
                            break;

                        case "Grass":
                            if (Land.attackTurnCheck)
                            {
                                if(hit.transform.GetComponent<MakeArea>().Movement == true)
                                {
                                    if (hit.transform.GetComponent<MakeArea>().Destroy != true)
                                    {
                                        landObj = hit.transform;
                                        mouseCheck = false;
                                        bulidUi.GetComponent<BuildController>().land = hit.transform;
                                        bulidUi.GetComponent<BuildController>().CreateWindow();
                                        bulidUi.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
                                    }
                                    else
                                    {
                                        repairUi.SetActive(true);
                                        repairUi.GetComponent<RepairController>().SettingRepair();
                                    }
                                }
                            }
                            break;

                        case "Area":
                            if (Land.attackTurnCheck)
                            {
                                if(hit.transform.GetComponent<MakeArea>().Grade != hit.transform.GetComponent<MakeArea>().maxGrade)
                                {
                                    mouseCheck = false;

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
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "집")
                                    {
                                        bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().Population;
                                    }

                                    Land.buttonManger.UpgradeLand = hit.transform;
                                    bulidUpgradeUi.GetComponent<BuildController>().land = hit.transform;
                                    bulidUpgradeUi.GetComponent<BuildController>().ReadAreaInfo();
                                }
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
                                if (specialSkillController.skillCheck)
                                {
                                    rangeManger.CandelRange(hit.transform);
                                    specialSkillController.gameObject.SetActive(false);
                                }
                                else
                                {
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                }
                            }
                            break;
                        case "GD":
                            if (hit.transform.parent.tag == "SelectLand")
                            {
                                if (specialSkillController.skillCheck)
                                {
                                    rangeManger.CandelRange(hit.transform);
                                    specialSkillController.gameObject.SetActive(false);
                                }
                                else
                                {
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                }
                            }
                            break;
                        case "SelectLand":
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
                            mouseCheck = false;
                            army.transform.SetParent(hit.transform);
                            moveSoldier.move = true;
                            army.transform.GetComponent<SoldierManger>().SoldierAction();
                            army.transform.GetComponent<SoldierManger>().movePoint = false;
                            break;
                        default:
                            break;
                    }
                    
                    ChangeLandInfo();
                    CheckMonsterMovePoint();
                    armyMove = true;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                time += Time.deltaTime;

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

    //터치 용도
    private void TouchHit()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchCheck = true;
                time = 0;
            }

            TouchCameraMove();

            RaycastHit2D hit = new RaycastHit2D();

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Vector3 touchPosition = Input.GetTouch(0).position;
                touchPosition = gameCamera.ScreenToWorldPoint(touchPosition);
                hit = Physics2D.Raycast(touchPosition, gameCamera.transform.forward, 800);
            }

            if (hit && touchCheck)
            {
                touchCheck = false;

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
                            if (Land.attackTurnCheck)
                            {
                                if (hit.transform.GetComponent<MakeArea>().Destroy == false)
                                {
                                    BarrackUi.SetActive(true);
                                    BarrackUi.GetComponent<BarrackController>().land = hit.transform;
                                    BarrackUi.GetComponent<BarrackController>().SwordButton();
                                    BarrackUi.GetComponent<BarrackController>().soldierMakeButton.GetComponent<Button>().interactable = false;
                                    mouseCheck = false;
                                }
                            }
                            break;

                        case "Army":
                            if (hit.transform.GetComponent<SoldierManger>().movePoint || hit.transform.GetComponent<MakeSoldier>().MovementNumber > 0)
                            {
                                rangeManger.PlayerMoveRange(hit.transform);
                            }
                            rangeManger.PlayerAttackRange(hit.transform);
                            armyMove = false;
                            moveSoldier = hit.transform.GetComponent<SoldierManger>();
                            Land.CheckTile();
                            break;

                        case "Grass":
                            if (Land.attackTurnCheck)
                            {
                                if (hit.transform.GetComponent<MakeArea>().Movement == true)
                                {
                                    if (hit.transform.GetComponent<MakeArea>().Destroy != true)
                                    {
                                        landObj = hit.transform;
                                        mouseCheck = false;
                                        bulidUi.GetComponent<BuildController>().land = hit.transform;
                                        bulidUi.GetComponent<BuildController>().CreateWindow();
                                        bulidUi.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
                                    }
                                    else
                                    {
                                        repairUi.SetActive(true);
                                        repairUi.GetComponent<RepairController>().SettingRepair();
                                    }
                                }
                            }
                            break;

                        case "Area":
                            if (Land.attackTurnCheck)
                            {
                                if (hit.transform.GetComponent<MakeArea>().Grade != hit.transform.GetComponent<MakeArea>().maxGrade)
                                {
                                    mouseCheck = false;

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
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "집")
                                    {
                                        bulidUpgradeUi.GetComponent<BuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().Population;
                                    }

                                    Land.buttonManger.UpgradeLand = hit.transform;
                                    bulidUpgradeUi.GetComponent<BuildController>().land = hit.transform;
                                    bulidUpgradeUi.GetComponent<BuildController>().ReadAreaInfo();
                                }
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
                                if (specialSkillController.skillCheck)
                                {
                                    rangeManger.CandelRange(hit.transform);
                                    specialSkillController.gameObject.SetActive(false);
                                }
                                else
                                {
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                }
                                ChangeLandInfo();
                                armyMove = true;
                            }
                            break;
                        case "GD":
                            if (hit.transform.parent.tag == "SelectLand")
                            {
                                if (specialSkillController.skillCheck)
                                {
                                    rangeManger.CandelRange(hit.transform);
                                    specialSkillController.gameObject.SetActive(false);
                                }
                                else
                                {
                                    moveSoldier.enemy = hit.transform;
                                    moveSoldier.attack = true;
                                    army.transform.GetComponent<SoldierManger>().SoldierAction();
                                }
                                ChangeLandInfo();
                                armyMove = true;
                            }
                            break;
                        case "SelectLand":
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
                            mouseCheck = false;
                            army.transform.SetParent(hit.transform);
                            moveSoldier.move = true;
                            army.transform.GetComponent<SoldierManger>().SoldierAction();
                            army.transform.GetComponent<SoldierManger>().movePoint = false;
                            ChangeLandInfo();
                            armyMove = true;
                            break;
                        default:
                            ChangeLandInfo();
                            break;
                    }

                    
                    CheckMonsterMovePoint();
                }
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && !touchCheck)
                {
                    ChangeLandInfo();
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            TouchCameraZoom();
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

        armyMove = true;
        rangeManger.rangeList.Clear();
    }

    private void MouseCameraMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = 0;
        }
        else if (Input.GetMouseButton(1))
        {
            if (gameCamera.transform.position.x < maxPosX + 50
            && gameCamera.transform.position.x > minPosX - 50
            && gameCamera.transform.position.y < maxPosY + 50
            && gameCamera.transform.position.y > minPosY - 50)
            {
                Vector3 MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
                MouseMove.z = 0;
                gameCamera.transform.position = gameCamera.transform.position - (MouseMove - MouseStart);

            }

            if (gameCamera.transform.position.x > maxPosX)
            {
                gameCamera.transform.position = new Vector3(maxPosX, gameCamera.transform.position.y, -800);
            }

            if (gameCamera.transform.position.x < minPosX)
            {
                gameCamera.transform.position = new Vector3(minPosX, gameCamera.transform.position.y, -800);
            }

            if (gameCamera.transform.position.y > maxPosY)
            {
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x, maxPosY, -800);
            }

            if (gameCamera.transform.position.y < minPosY)
            {
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x, minPosY, -800);
            }
        }
    }

    private void TouchCameraMove()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            MouseStart = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = 0;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if(time > 0.2f)
            {
                touchCheck = false;
            }

            if (gameCamera.transform.position.x < maxPosX + 50
            && gameCamera.transform.position.x > minPosX - 50
            && gameCamera.transform.position.y < maxPosY + 50
            && gameCamera.transform.position.y > minPosY - 50)
            {
                Vector3 MouseMove = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
                MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
                MouseMove.z = 0;
                gameCamera.transform.position = gameCamera.transform.position - (MouseMove - MouseStart);
            }
            else
            {
                if (gameCamera.transform.position.x > maxPosX)
                {
                    gameCamera.transform.position = new Vector3(maxPosX, gameCamera.transform.position.y, -800);
                }

                if (gameCamera.transform.position.x < minPosX)
                {
                    gameCamera.transform.position = new Vector3(minPosX, gameCamera.transform.position.y, -800);
                }

                if (gameCamera.transform.position.y > maxPosY)
                {
                    gameCamera.transform.position = new Vector3(gameCamera.transform.position.x, maxPosY, -800);
                }

                if (gameCamera.transform.position.y < minPosY)
                {
                    gameCamera.transform.position = new Vector3(gameCamera.transform.position.x, minPosY, -800);
                }
            }
        }
    }

    public void CheckMonsterMovePoint()
    {
        
        for (int i = 0; i < buttonManger.amrys.Count; i++)
        {
            if (buttonManger.amrys[i].GetComponent<SoldierManger>().movePoint == true)
            {
                monsterMoveCheckImgae.color = Color.white;
                return;
            }
            else
            {
                monsterMoveCheckImgae.color = Color.gray;
            }
        }
    }

    private void TouchCameraZoom()
    {
        Vector3 touchOne;
        Vector3 touchTwo;
        int speed = 3;
        

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchOne = Input.GetTouch(0).position;
            touchTwo = Input.GetTouch(1).position;

            distance = (int)Vector3.Distance(touchOne, touchTwo);
        }

        if(Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            touchOne = Input.GetTouch(0).position;
            touchTwo = Input.GetTouch(1).position;

            distance = (int)Vector3.Distance(touchOne, touchTwo);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchOne = Input.GetTouch(0).position;
            touchTwo = Input.GetTouch(1).position;
            
            moveDistance = (int)Vector3.Distance(touchOne, touchTwo);

            Debug.Log("distance : " + distance + "  moveDistance : " + moveDistance);

            if (moveDistance > distance)
            {
                if (Camera.main.orthographicSize > 100)
                {
                    Camera.main.orthographicSize -= speed;
                }
            }
            else
            {
                if (Camera.main.orthographicSize < 500)
                {
                    Camera.main.orthographicSize += speed;
                }
            }
        }
    }
}
