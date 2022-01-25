using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeButtonManger : MonoBehaviour
{
    public GameObject settingButton;
    public GameObject upGradeWindow;
    public AudioSource soundBgm;
    public Slider bgmBar;
    public float bgmVolume;
    public UpGradeButtonManger buttonManger;
    public UpGradeMonsterInfo upGradeMonsterInfo;
    public UpGradeInputManger upGradeInputManger;

    public bool check;
    public bool nextMonsterRightCheck;
    public bool nextMonsterLeftCheck;


    private void Start()
    {
        soundBgm = GameObject.FindGameObjectWithTag("GameManger").GetComponent<AudioSource>();
        upGradeInputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<UpGradeInputManger>();
        bgmVolume = 1f;
        check = true;
        nextMonsterRightCheck = false;
        nextMonsterLeftCheck = false;
    }

    void Update()
    {
        if (check)
        {

        }
        soundBgm.volume = bgmBar.value;

        if(nextMonsterRightCheck)
        {
            upGradeMonsterInfo.interporlateNum += Time.deltaTime;

            if(upGradeMonsterInfo.interporlateNum > 1)
            {
                upGradeMonsterInfo.interporlateNum = 1;
                nextMonsterRightCheck = false;
            }
            
            upGradeMonsterInfo.RoundMonster();
            upGradeMonsterInfo.FindAndMakeMonster();
        }

        if(nextMonsterLeftCheck)
        {
            upGradeMonsterInfo.interporlateNum -= Time.deltaTime;
            if (upGradeMonsterInfo.interporlateNum < -1)
            {
                upGradeMonsterInfo.interporlateNum = -1;
                nextMonsterLeftCheck = false;
            }
            
            upGradeMonsterInfo.RoundMonster();
            upGradeMonsterInfo.FindAndMakeMonster();
        }
    }

    public void Cancel()
    {
        bgmBar.value = bgmVolume;
        SettingWindowButton();
    }

    public void Save()
    {
        SettingWindowButton();
        bgmVolume = soundBgm.volume;
    }

    public void TestRight()
    {
        nextMonsterRightCheck = true;
    }

    public void TestLeft()
    {
        nextMonsterLeftCheck = true;
    }

    public void SettingWindowButton()
    {
        if(settingButton.activeSelf == false)
        {
            settingButton.SetActive(true);
        }
        else
        {
            settingButton.SetActive(false);
        }

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            upGradeInputManger.mouseCheck = false;
        }
        else
        {
            Time.timeScale = 1;
            upGradeInputManger.mouseCheck = true;
        }
    }


    public void UpGradeWindow()
    {
        if (upGradeWindow.activeSelf == true)
        {
            upGradeWindow.SetActive(false);
            upGradeInputManger.mouseCheck = true;
        }
        else
        {
            upGradeWindow.SetActive(true);
            upGradeInputManger.mouseCheck = false;
        }
    }
}
