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

    private void Start()
    {
        instance = this;
    }
}
