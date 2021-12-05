using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTalkManger : MonoBehaviour
{
    private List< string> scripts;
    public Text spcriptText;
    public int spcriptNum;
    public int textNum;
    public TutorialTileManger tile;
    public TutorialInputManger inputManger;
    public bool check;
    public bool sceneCheck;
    public bool talkCheck;
    public int stopTalkNum;
    public GameObject dimmedCover;
    public PlayerInfo player;
    public SaveMgr save;

    void Start()
    {
        spcriptNum = 0;
        scripts = new List<string>();
        textNum = 5;
        scripts.Add("조금 있으면 쥐들이 몰려 올꺼야");
        scripts.Add("쥐들이 우리 케이크성을 공격하기 전에");
        scripts.Add("어서 준비 해야되!!!");
        scripts.Add("좋아 그럼 함께 싸워줄 친구들을 불러 볼까?");
        scripts.Add("먼저 저기 보이는 타일을 눌러보자");
        check = true;
        sceneCheck = false;
        spcriptText.text = scripts[spcriptNum];
        talkCheck = false;
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
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
            if (check)
            {
                tile.StartTile();
                check = false;
            }

            inputManger.talk = false;

            if (sceneCheck)
            {
                player.ResetGame();
                save.Save();
                SceneMgr.GoUpGradeScene();
            }
        }
    }

    public void BulidTalk()
    {
        scripts.Clear();
        textNum = 6;
        spcriptNum = 0;
        
        scripts.Add("잘 했어! 그럼 저기 보이는 오븐을 눌러보자");
        scripts.Add("왼쪽 창에 오븐이 나타난 것이 보이지?");
        scripts.Add("그건 오븐이 선택이 되었다는 것을 의미해");
        scripts.Add("아래쪽 건설 버튼을 눌러서 오븐을 건설하자!");
        scripts.Add("오븐이 생성된거 같아!");
        scripts.Add("그럼이제 친구들을 만들수 있겠다 오븐을 눌러보자");
        spcriptText.text = scripts[spcriptNum];
    }

    public void BarrackTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 4;
        spcriptNum = 0;
        scripts.Add("자 아까와 비슷하지?");
        scripts.Add("이번에는 저 대담하고 큰 초코칩쿠키를 눌러보자");
        scripts.Add("이번에도 왼쪽에 초코칩쿠키가 나왔어");
        scripts.Add("생산버튼을 눌러서 초코칩쿠키를 부르자");
        
        spcriptText.text = scripts[spcriptNum];
    }

    public void MoveTalk()
    {
        //inputManger.talk = true;
        scripts.Clear();
        textNum = 5;
        spcriptNum = 0;
        scripts.Add("와 드디어 친구를 불렀어!");
        scripts.Add("이번에는 초코칩쿠키를 눌러볼까?");
        scripts.Add("누르니깐 바닥에 색이 달라졌네?");
        scripts.Add("저건 쿠키들이 이동할 수 있는 범위를 나타낸거야 ");
        scripts.Add("어서 눌러보자");
        spcriptText.text = scripts[spcriptNum];
    }

    public void NextTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 6;
        spcriptNum = 0;
        scripts.Add("이런 쥐들이 와버렸어");
        scripts.Add("어서 공격해서 쫓아내버리자");
        scripts.Add("아까랑 같이 초코칩쿠키를 눌러보자");
        scripts.Add("이번에는 색이 변했어");
        scripts.Add("이건 공격할수 있는 범위를 보여주는 거야");
        scripts.Add("어서 눌러서 쥐를 몰아내자");
        spcriptText.text = scripts[spcriptNum];
    }

    public void FinalTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 7;
        spcriptNum = 0;
        scripts.Add("자 이제 저 우주선을 파괴하자");
        scripts.Add("그렇지 않으면 또 쥐가 나올꺼야");
        scripts.Add("우주선 위로 올라간다면 파괴할수 있을꺼야");
        scripts.Add("어서 움직이자");
        scripts.Add("잘했어! 우리가 쥐를 물리쳤어!");
        scripts.Add("곧 쥐들이 다시 올꺼야");
        scripts.Add("이제 다음공격에 대비해 준비를 하자");
        spcriptText.text = scripts[spcriptNum];
        sceneCheck = true;
    }
}
