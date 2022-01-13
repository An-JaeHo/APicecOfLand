using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlipCard : MonoBehaviour
{
    public float x, y, z;

    public GameObject cardBack;

    public bool cardBackIsActive;

    public int timer;

    [Header("낮을수록 빠르게 플립, 원래스피드 0.01f")]
    public float spinSpeed= 0.01f;

    void Start()
    {
        cardBackIsActive = false;
        StartFlip();
    }


    public void StartFlip()
    {
        StartCoroutine(CalculateFilp());
    }

     void Flip()
    {
        if(cardBackIsActive == true)
        {
            cardBack.SetActive(false);
            cardBackIsActive = false;
        }
        else
        {
            cardBack.SetActive(true);
            cardBackIsActive = true;
        }
    }

    IEnumerator CalculateFilp()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(spinSpeed);
            transform.Rotate(new Vector3(x, y, z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                Flip();
            }
        }

        timer = 0;
    }
}
