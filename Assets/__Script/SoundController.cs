using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip audio;
}

public class SoundController : MonoBehaviour
{
    [SerializeField] static public AudioClip[] Sounds;

    public static SoundController instance;

    public SettingController setting;

    private void Start()
    {
        instance = this;
        object[] loadedSound = Resources.LoadAll("Sound", typeof(AudioClip));

        Sounds = new AudioClip[loadedSound.Length];

        for (int i = 0; i < loadedSound.Length; i++)
        {
            Sounds[i] = (AudioClip)loadedSound[i];
        }

        for (int i=0; i< Sounds.Length;i++)
        {
            setting.soundEffects.Add(Sounds[i]);
        }
    }

    static public AudioClip FindAndPlayAudio(string code)
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            if(Sounds[i].name == code)
            {
                return Sounds[i];
            }
        }

        return null;
    }
}
