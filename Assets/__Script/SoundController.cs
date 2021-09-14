using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audio;
}

public class SoundController : MonoBehaviour
{
    [SerializeField] public Sound[] buildSounds;
    [SerializeField] public Sound[] bossSounds;
    [SerializeField] public Sound[] monsterSounds;
    [SerializeField] public Sound[] enemySounds;

    public static SoundController instance;

    public SettingController setting;

    private void Start()
    {
        instance = this;

        for(int i=0; i< buildSounds.Length;i++)
        {
            setting.soundEffects.Add(buildSounds[i].audio);
        }
        for (int i = 0; i < bossSounds.Length; i++)
        {
            setting.soundEffects.Add(bossSounds[i].audio);
        }
        for (int i = 0; i < monsterSounds.Length; i++)
        {
            setting.soundEffects.Add(monsterSounds[i].audio);
        }
        for (int i = 0; i < enemySounds.Length; i++)
        {
            setting.soundEffects.Add(enemySounds[i].audio);
        }
    }
}
