using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeInputManger : MonoBehaviour
{
    public Camera gameCamera;
    public Transform hitObj;
    public GameObject upGradeWindow;
    public bool mouseCheck;
    public UpGradeMonsterInfo upGradeMonsterInfo;
    private float minPosX;
    private float maxPosX;
    private float fristPosX;
    private bool mouseMonsterCheck;

    void Start()
    {
        gameCamera = Camera.main;
        mouseCheck = true;
        fristPosX = 540f;
        minPosX = 1f;
        maxPosX = 1080f;
        mouseMonsterCheck = false;
    }

    void Update()
    {
        if(mouseCheck)
        {
            if (Input.touchCount > 0)
            {
                TouchHit();
            }
            else
            {
                Mounshit();
            }
        }

        
    }

    private void Mounshit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseMonsterCheck = true;
        }

        if (mouseMonsterCheck)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 moveMousePos = Input.mousePosition;
                float moveMonsterInterpolate;

                if (moveMousePos.x < maxPosX
                    && moveMousePos.x > minPosX)
                {
                    if (moveMousePos.x > 540f)
                    {
                        moveMonsterInterpolate = (moveMousePos.x - 540f) / (maxPosX - 540f);
                    }
                    else
                    {
                        moveMonsterInterpolate = ((moveMousePos.x - 540f) / 540f);
                    }
                    
                    upGradeMonsterInfo.interporlateNum = moveMonsterInterpolate;

                    if (moveMonsterInterpolate > 1)
                    {
                        moveMonsterInterpolate = 1;
                        upGradeMonsterInfo.interporlateNum = moveMonsterInterpolate;
                        mouseMonsterCheck = false;
                        upGradeMonsterInfo.FindAndMakeMonster();
                    }

                    if (moveMonsterInterpolate < -1)
                    {
                        moveMonsterInterpolate = -1;
                        upGradeMonsterInfo.interporlateNum = moveMonsterInterpolate;
                        mouseMonsterCheck = false;
                        upGradeMonsterInfo.FindAndMakeMonster();
                    }
                }
                else
                {
                    if (moveMousePos.x > maxPosX)
                    {
                        moveMonsterInterpolate = 1f;
                        upGradeMonsterInfo.interporlateNum = moveMonsterInterpolate;
                        mouseMonsterCheck = false;
                        upGradeMonsterInfo.FindAndMakeMonster();
                    }

                    if (moveMousePos.x < minPosX)
                    {
                        moveMonsterInterpolate = -1f;
                        upGradeMonsterInfo.interporlateNum = moveMonsterInterpolate;
                        mouseMonsterCheck = false;
                        upGradeMonsterInfo.FindAndMakeMonster();
                    }
                }

                upGradeMonsterInfo.RoundMonster();
            }
        }
    }

    private void TouchHit()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition = gameCamera.ScreenToWorldPoint(touchPosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, gameCamera.transform.forward, 800);

            if (hit)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    hitObj = hit.transform;

                    switch (hit.transform.tag)
                    {
                        case "Army":
                            upGradeWindow.SetActive(true);
                            upGradeWindow.GetComponent<UpGradeSceneWindow>().UpGradeCheck(hit.transform);
                            mouseCheck = false;
                            break;
                    }
                }
            }

        }
    }
}
