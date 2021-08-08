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
    public UpGradeInputManger upGradeInputManger;

    public bool check;

    private void Start()
    {
        soundBgm = GameObject.FindGameObjectWithTag("GameManger").GetComponent<AudioSource>();
        upGradeInputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<UpGradeInputManger>();
        bgmVolume = 1f;
        check = true;
    }

    void Update()
    {
        if (check)
        {

        }
        soundBgm.volume = bgmBar.value;
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

    public void SettingWindowButton()
    {
        if(settingButton.activeSelf == false)
        {
            settingButton.SetActive(true);
            upGradeInputManger.mouseCheck = false;
        }
        else
        {
            settingButton.SetActive(false);
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
