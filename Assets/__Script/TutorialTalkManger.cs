using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTalkManger : MonoBehaviour
{
    private List< string> scripts;
    public Text spcriptText;
    private int spcriptNum;
    public int textNum;
    public TutorialTileManger tile;
    public TutorialInputManger inputManger;
    public bool check;
    public bool sceneCheck;

    void Start()
    {
        spcriptNum = 0;
        scripts = new List<string>();
        textNum = 3;
        scripts.Add("조금 있으면 생쥐들이 몰려 올꺼야");
        scripts.Add("어서 준비 해야되");
        scripts.Add("좋아 그럼 함께 싸워줄 친구들을 만들어 볼까?");
        check = true;
        sceneCheck = false;
        spcriptText.text = scripts[spcriptNum];
    }

    public void NextScriptButton()
    {
        spcriptNum++;

        if(spcriptNum < textNum)
        {
            spcriptText.text = scripts[spcriptNum];
        }
        else
        {
            gameObject.SetActive(false);

            if(check)
            {
                tile.StartTile();
                check = false;
            }

            if(sceneCheck)
            {
                SceneMgr.GoUpGradeScene();
            }
        }
    }

    public void NextTalk()
    {
        scripts.Clear();
        textNum = 2;
        spcriptNum = 0;
        scripts.Add("이런 쥐들이 와버렸어");
        scripts.Add("어서 공격해서 쫓아내버리자");
        spcriptText.text = scripts[spcriptNum];
        gameObject.SetActive(true);
    }

    public void FinalTalk()
    {
        scripts.Clear();
        textNum = 1;
        spcriptNum = 0;
        scripts.Add("잘했어! 이제 다음공격에 대비해 준비를 하자");
        spcriptText.text = scripts[spcriptNum];
        gameObject.SetActive(true);
        sceneCheck = true;
    }
}
