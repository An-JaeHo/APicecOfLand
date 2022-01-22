using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInputManger : MonoBehaviour
{
    public Camera gameCamera;
    public bool mouseCheck; 
    public bool armyMove;
    public Transform hitObj;
    public Transform landObj;
    public TutorialSoldierManger moveSoldier;
    public TutorialRangeManger rangeManger;
    public TutorialTileManger tileManger;
    public TutorialTalkManger talkManger;
    public TutorialButtonManger buttonManger;
    public Transform army;
    public GameObject bulidUpgradeUi;
    public float time;
    public bool finalCheck;

    //제작해야되는것
    public GameObject BarrackUi;
    public GameObject bulidUi;
    public GameObject armyUpgradeUi;

    public bool talk;

    void Start()
    {
        finalCheck = false;
        gameCamera = Camera.main;
        mouseCheck = true;
        armyMove = true;
        talk = false;
        buttonManger = GetComponent<TutorialButtonManger>();
    }
    
    void Update()
    {
        if (mouseCheck)
        {
            if (Input.touchCount > 0)
            {
                TouchHit();
                //TouchCameraMove();
            }
            else
            {
                MouseHit();
                //MouseCameraMove();
            }
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (talk || talkManger.talkCheck)
                {
                    talkManger.NextScriptButton();

                    if (talkManger.stopTalkNum == talkManger.spcriptNum)
                    {
                        talkManger.talkCheck = false;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (talk || talkManger.talkCheck)
                {
                    talkManger.NextScriptButton();

                    if (talkManger.stopTalkNum == talkManger.spcriptNum)
                    {
                        talkManger.talkCheck = false;
                    }
                }
            }
        }
    }
    
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
                                BarrackUi.GetComponent<TutorialBarrackController>().land = hit.transform;
                                BarrackUi.GetComponent<TutorialBarrackController>().SwordButton();
                                buttonManger.makeMonsterButton.GetComponent<Button>().interactable = false;
                                talkManger.stopTalkNum = 8;
                                talkManger.NextScriptButton();
                                talkManger.talkCheck = true;
                                talk = false;
                            }
                            break;
                        case "Grass":
                            talk = false;
                            landObj = hit.transform;
                            mouseCheck = false;
                            //talkManger.dimmedCover.SetActive(false);
                            talkManger.NextScriptButton();
                            tileManger.tutorialLand.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 15;
                            landObj.GetComponent<SpriteRenderer>().sortingOrder = 17;
                            bulidUi.GetComponent<TutorialBuildController>().land = hit.transform;
                            bulidUi.GetComponent<TutorialBuildController>().CreateWindow();
                            break;
                        case "Area":
                            break;
                        case "Army":
                            if (hit.transform.GetComponent<TutorialSoldierManger>().movePoint)
                            {
                                rangeManger.PlayerMoveRange(hit.transform);
                            }
                            rangeManger.PlayerAttackRange(hit.transform);
                            armyMove = false;
                            moveSoldier = hit.transform.GetComponent<TutorialSoldierManger>();

                            break;
                        default:
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
                                army.transform.GetComponent<TutorialSoldierManger>().SoldierAction();
                                buttonManger.button.GetComponent<Button>().interactable = false;
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
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().MilkOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "밀가루")
                                    {
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().FlourOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "설탕")
                                    {
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().SugarOutput;
                                    }
                                    bulidUpgradeUi.GetComponent<TutorialBuildController>().land = hit.transform;
                                    bulidUpgradeUi.GetComponent<TutorialBuildController>().ReadAreaInfo();
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

                                army.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                                army.transform.SetParent(hit.transform);
                                moveSoldier.move = true;
                                army.transform.GetComponent<TutorialSoldierManger>().SoldierAction();
                                army.transform.GetComponent<TutorialSoldierManger>().movePoint = false;
                            }

                            ChangeLandInfo();
                            break;

                        case "Army":
                            //if (!hit.transform.GetComponent<TutorialSoldierManger>().movePoint)
                            //{
                            //    talkManger.NextScriptButton();
                            //    talkManger.dimmedCover.SetActive(true);
                            //    talkManger.stopTalkNum = 5;
                            //    moveSoldier = hit.transform.GetComponent<TutorialSoldierManger>();
                            //}
                            break;
                        default:

                            break;
                    }
                    armyMove = true;
                }
            }
        }
        else
        {
            if (!talk && !talkManger.talkCheck)
            {
                //if (Input.GetMouseButtonDown(0))
                //{
                //    ChangeLandInfo();
                //}
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

    private void TouchHit()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, gameCamera.transform.forward, 800);

        if (hit)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
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
                                BarrackUi.GetComponent<TutorialBarrackController>().land = hit.transform;
                                BarrackUi.GetComponent<TutorialBarrackController>().SwordButton();
                                buttonManger.makeMonsterButton.GetComponent<Button>().interactable = false;
                                talkManger.stopTalkNum = 8;
                                talkManger.NextScriptButton();
                                talkManger.talkCheck = true;
                                talk = false;
                            }
                            break;
                        case "Grass":
                            talk = false;
                            landObj = hit.transform;
                            mouseCheck = false;
                            //talkManger.dimmedCover.SetActive(false);
                            talkManger.NextScriptButton();
                            tileManger.tutorialLand.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 15;
                            landObj.GetComponent<SpriteRenderer>().sortingOrder = 17;
                            bulidUi.GetComponent<TutorialBuildController>().land = hit.transform;
                            bulidUi.GetComponent<TutorialBuildController>().CreateWindow();
                            break;
                        case "Area":
                            break;
                        case "Army":
                            if (hit.transform.GetComponent<TutorialSoldierManger>().movePoint)
                            {
                                talk = false;
                                rangeManger.PlayerMoveRange(hit.transform);
                                armyMove = false;

                                if (!finalCheck)
                                {
                                    talkManger.NextScriptButton();
                                    talkManger.talkCheck = true;
                                }
                                moveSoldier = hit.transform.GetComponent<TutorialSoldierManger>();
                            }

                            break;
                        default:
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
                                army.transform.GetComponent<TutorialSoldierManger>().SoldierAction();
                                buttonManger.button.GetComponent<Button>().interactable = false;
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
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().MilkOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "밀가루")
                                    {
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().FlourOutput;
                                    }
                                    else if (hit.transform.GetComponent<MakeArea>().Name == "설탕")
                                    {
                                        bulidUpgradeUi.GetComponent<TutorialBuildController>().nowPoint = hit.transform.GetComponent<MakeArea>().SugarOutput;
                                    }
                                    bulidUpgradeUi.GetComponent<TutorialBuildController>().land = hit.transform;
                                    bulidUpgradeUi.GetComponent<TutorialBuildController>().ReadAreaInfo();
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

                                army.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                                army.transform.SetParent(hit.transform);
                                moveSoldier.move = true;
                                army.transform.GetComponent<TutorialSoldierManger>().SoldierAction();
                                army.transform.GetComponent<TutorialSoldierManger>().movePoint = false;
                            }

                            ChangeLandInfo();
                            break;

                        case "Army":
                            //if (!hit.transform.GetComponent<TutorialSoldierManger>().movePoint)
                            //{
                            //    talkManger.NextScriptButton();
                            //    talkManger.dimmedCover.SetActive(true);
                            //    talkManger.stopTalkNum = 5;
                            //    moveSoldier = hit.transform.GetComponent<TutorialSoldierManger>();
                            //}
                            break;
                        default:

                            break;
                    }
                    armyMove = true;
                }
            }

        }
        else
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!talk && !talkManger.talkCheck)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //ChangeLandInfo();
                    }
                }
            }
        }
    }
}
