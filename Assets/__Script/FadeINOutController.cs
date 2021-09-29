using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeINOutController : MonoBehaviour
{
    public List<Sprite> imgs;
    public Image img;
    private bool checkEnd;
    public int imgNum;
    private float timer;

    private void Awake()
    {
        imgNum = 0;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (checkEnd)
        {
            if (timer > 3f)
            {
                StartCoroutine(FadeImage());
            }
        }
        else
        {
            img.color = new Color(1, 1, 1, 1);
            img.sprite = imgs[imgNum];
            checkEnd = true;
        }
        
    }

    public void OnButtonClick()
    {
        imgNum++;
        timer = 0;

        if (imgNum> 13)
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            
            img.sprite = imgs[imgNum];
            img.color = new Color(1, 1, 1, 1);
        }
        
    }

    IEnumerator FadeImage()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            img.color = new Color(1, 1, 1, i);
        }

        checkEnd = false;
        imgNum++;
        timer = 0;

        yield return null;
    }
}
