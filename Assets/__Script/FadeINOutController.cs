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

    private void Start()
    {
        
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
        img.sprite = imgs[imgNum];
        img.color = new Color(1, 1, 1, 1);
    }

    IEnumerator FadeImage()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
        }

        checkEnd = false;
        imgNum++;
        timer = 0;

        yield return null;
    }
}
