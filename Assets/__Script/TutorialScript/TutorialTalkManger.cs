using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTalkManger : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject settingButton;
    public Text spcriptText;
    public TutorialTileManger tile;
    public TutorialInputManger inputManger;
    public GameObject dimmedCover;

    [Header("Build Tutorial Obj")]
    public GameObject outPutUi;
    public GameObject consumeUi;
    public GameObject areaUi;
    public GameObject makeAreaButton;

    [Header("SupplyAndBarrack Tutorial Obj")]
    public GameObject supplyObj;

    [Header("Move Tutorial Obj")]
    public GameObject attackUi;
    public GameObject DefendUi;
    public bool moveCheck;

    [Header("Set in ViualStudio")]
    public int spcriptNum;
    public int textNum;
    public bool sceneCheck;
    public bool talkCheck;
    public int stopTalkNum;
    public PlayerInfo player;
    public SaveMgr save;
    public bool firstTalk;

    public bool buildCheck;
    public bool barrackCheck;


    private List< string> scripts;

    void Start()
    {
        spcriptNum = 0;
        stopTalkNum = 999;
        scripts = new List<string>();
        moveCheck = false;
        textNum = 4;
        scripts.Add("환영합니다. 제빵사님​");
        scripts.Add("현재 약탈을 일 삼는 우주 쥐들이 공격해오고 있습니다.​");
        scripts.Add("성을 점령 당하면 모든 케이크 지역이 붕괴되니 ​ 케이크 성을 보호해야 합니다.​");
        scripts.Add("우선 저희 건물부터 소개 해드리겠습니다.​");
        tile.StartTile();
        sceneCheck = false;
        spcriptText.text = scripts[spcriptNum];
        talkCheck = false;
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
    }

    public void NextScriptButton()
    {
        if (spcriptNum!= stopTalkNum)
        {
            spcriptNum++;

            if (spcriptNum < textNum)
            {
                spcriptText.text = scripts[spcriptNum];

                if(buildCheck)
                {
                    if(spcriptNum == 3)
                    {
                        outPutUi.transform.SetSiblingIndex(3);
                        consumeUi.transform.SetAsLastSibling();
                    }
                    else if(spcriptNum == 4)
                    {
                        consumeUi.transform.SetSiblingIndex(3);
                        makeAreaButton.transform.SetAsLastSibling();
                        makeAreaButton.GetComponent<Button>().interactable = true;
                    }
                }

                if(barrackCheck)
                {
                    if(spcriptNum == 2)
                    {
                        dimmedCover.SetActive(true);
                        dimmedCover.transform.SetParent(supplyObj.transform);
                        dimmedCover.transform.SetSiblingIndex(5);
                        stopTalkNum = 6;
                    }
                    else if (spcriptNum == 6)
                    {
                        dimmedCover.transform.SetParent(transform.parent);
                        supplyObj.transform.GetChild(5).SetSiblingIndex(3);
                        stopTalkNum = 6;

                        for (int i = 0; i < tile.tileList.Count; i++)
                        {
                            if(tile.tileList[i].parent.name == "144")
                            {
                                tile.tileList[i].GetComponent<BoxCollider2D>().enabled = true;
                                tile.tileList[i].GetComponent<SpriteRenderer>().sortingOrder = 1002;
                            }
                        }
                        dimmedCover.transform.SetSiblingIndex(5);
                    }
                }

                if(moveCheck)
                {
                    if(stopTalkNum == 2)
                    {
                        dimmedCover.transform.SetParent(supplyObj.transform);
                        dimmedCover.transform.SetSiblingIndex(3);
                        stopTalkNum = 5;
                    }
                }

            }
            else
            {
                inputManger.talk = false;

                if (firstTalk)
                {
                    if (spcriptNum == 4)
                    {
                        BulidTalk();
                        firstTalk = false;
                    }
                }

                if (sceneCheck)
                {
                    player.ResetGame();
                    save.Save();
                    SceneMgr.GoUpGradeScene();
                }
            }
        }
    }

    public void BulidTalk()
    {
        scripts.Clear();
        buildCheck = true;
        textNum = 5;
        dimmedCover.SetActive(true);
        tile.tutorialLand.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1002;
        spcriptNum = 0;
        stopTalkNum = 1;
        scripts.Add("비어있는 타일을 터치 해보세요.​");
        scripts.Add("우유 생산소를 터치하세요.");
        scripts.Add("생산량을 확인 할 수 있어요.​");
        scripts.Add("소모 되는 자원을 확인 할 수 있어요.​");
        scripts.Add("건설을 눌러보세요.");
        spcriptText.text = scripts[spcriptNum];
    }

    public void SupplyAndBarrackTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 9;
        spcriptNum = 0;
        buildCheck = false;
        stopTalkNum = 2;
        barrackCheck = true;
        scripts.Add("생산 건물이 건설 되었습니다!");
        scripts.Add("다음은 제빵사님의 자원 상태를 알아보겠습니다.​");
        scripts.Add("왼쪽에 있는 숫자는 성주님이 보유하고 있는​자원량입니다.​");
        scripts.Add("오른쪽에 있는 숫자는 성주님이 턴이 지날 때마다 얻을 수 있는 자원 입니다.​");
        scripts.Add("생산 자원을 올릴 수록 생산량이 늘어나지만​ 건설 할 때 보유 자원을 소모합니다.​");
        scripts.Add("하나의 자원이라도 -150이 된다면 패배하게 됩니다.​");
        scripts.Add("배우신대로 해당 타일에 오븐을 건설해보세요!​");
        scripts.Add("우선 오븐을 터치해보세요!​");
        scripts.Add("유닛을 생산해보세요!​");
        spcriptText.text = scripts[spcriptNum];
    }

    public void MoveTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 6;
        spcriptNum = 0;
        buildCheck = false;
        barrackCheck = false;
        moveCheck = true;
        stopTalkNum = 0;
        inputManger.buttonManger.button.GetComponent<Button>().interactable = true;

        scripts.Add("턴을 넘겨보세요!");
        scripts.Add("공격 턴이 시작되었습니다.적군이 공격해옵니다.대비하세요.");
        scripts.Add("공격턴에서는 더 이상 유닛 생산과 건물 건설이 불가능합니다.");
        scripts.Add("공격 턴이 0이되면 휴식 턴이 돌아옵니다!");
        scripts.Add("공격 턴이 0이 되기 전에 모든 적군과 모든 적기지를 처치해야 합니다.");
        scripts.Add("공격 턴이 0이 되기 전에 모든 적군과 모든 적기지를 처치하지 못하면 패배하게 됩니다.");
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
