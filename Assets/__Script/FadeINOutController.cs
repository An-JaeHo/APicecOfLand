using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeINOutController : MonoBehaviour
{
    public List<Sprite> imgs;
    public Image img;
    public int imgNum;
    private bool checkEnd;
    private float timer;
    private bool checkTalkImg;
    
    public GameObject partOneTalk;
    public TutorialInputManger tutorialInput;

    private void Awake()
    {
        imgNum = 0;
        timer = 0;
        checkTalkImg = false;
        tutorialInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(!checkTalkImg)
        {
            if (imgNum != imgs.Count)
            {
                if (checkEnd)
                {
                    if (timer > 5f)
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
            else
            {
                partOneTalk.SetActive(true);
                checkTalkImg = true;
                timer = 0;
                tutorialInput.talkManger.firstTalk = true;
                img.GetComponent<Button>().enabled = false;
            }
        }
        else
        {
            if(tutorialInput.tileManger.cakeCastle != null)
            {
                float colorNum = (timer / 5f) * 255;

                tutorialInput.tileManger.cakeCastle.transform.GetChild(0).GetComponent<SpriteRenderer>().color 
                    = new Color(255f, 255f, 255f, colorNum / 255f);

                if(colorNum >=255)
                {
                    tutorialInput.tileManger.cakeCastle = null;
                }
            }
        }
    }

    public void OnButtonClick()
    {
        imgNum++;
        timer = 0;
        if (imgNum> 5)
        {
            img.gameObject.SetActive(false);
            tutorialInput.talk = true;
            tutorialInput.talkManger.tile.supplyManger.gameObject.SetActive(true);
            tutorialInput.talkManger.settingButton.SetActive(true);
            tutorialInput.talkManger.inputManger.buttonManger.button.SetActive(true);
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
