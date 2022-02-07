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
}