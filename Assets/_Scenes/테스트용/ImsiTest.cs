using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImsiTest : MonoBehaviour
{
    public GameObject cha;
    public AudioSource audioS;
    public AudioClip aud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTest()
    {
        cha.GetComponent<Animator>().SetTrigger("Attack");
        audioS.clip = aud;
        audioS.Play();
    }
}
