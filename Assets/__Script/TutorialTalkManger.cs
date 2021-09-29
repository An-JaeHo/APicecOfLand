using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTalkManger : MonoBehaviour
{
    private List< string> scripts;
    public Text spcriptText;
    private int spcriptNum;

    void Start()
    {
        spcriptNum = 0;
        scripts = new List<string>();


        scripts.Add("조금 있으면 생쥐들이 몰려 올꺼야");
        scripts.Add("어서 준비 해야되");

        scripts.Add("먼저 기초 자원부터 준비를 해보자");

        scripts.Add("좋아 그럼 함께 싸워줄 친구들을 만들어 볼까?");
        scripts.Add("이런 쥐들이 와버렸어");
        scripts.Add("어서 공격해서 쫓아내버리자");

        spcriptText.text = scripts[spcriptNum];
    }

    public void NextScriptButton()
    {
        spcriptNum++;

        if(spcriptNum < 2)
        {
            spcriptText.text = scripts[spcriptNum];
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}
