using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public List<AudioClip> soundEffects;
    public AudioSource soundBgm;
    public Slider soundEffectBar;
    public Slider bgmBar;
    public float bgmVolume;
    public float effectVolume;
    public ButtonManger buttonManger;

    public bool check;

    private void Start()
    {
        soundBgm = GameObject.FindGameObjectWithTag("GameManger").GetComponent<AudioSource>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        bgmVolume = 1f;
        check = true;
    }

    void Update()
    {
        if(check)
        {

        }
        soundBgm.volume = bgmBar.value;

        for (int i = 0; i < soundEffects.Count; i++)
        {
            //soundEffects[i].
        }
    }

    public void Cancel()
    {
        soundBgm.volume = bgmVolume;
        bgmBar.value = bgmVolume;
        buttonManger.SettingButton();
    }

    public void Save()
    {
        buttonManger.SettingButton();
        bgmVolume = soundBgm.volume;
    }
}
