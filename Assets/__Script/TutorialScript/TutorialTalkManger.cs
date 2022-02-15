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

    [Header("Final Talk")]
    public bool finalCheck;
    public TutorialInvenController tutorialInvenController;

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
    public bool enemyCheck;

    private FireBaseManger fireBaseManger;
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
        finalCheck = false;
        spcriptText.text = scripts[spcriptNum];
        talkCheck = false;
        enemyCheck = false;
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        fireBaseManger = GameObject.FindGameObjectWithTag("GameManger").GetComponent<FireBaseManger>();
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
                    if(spcriptNum == 1)
                    {
                        dimmedCover.transform.SetParent(supplyObj.transform);
                        dimmedCover.transform.SetSiblingIndex(5);
                        dimmedCover.SetActive(true);
                        stopTalkNum = 5;

                        for (int i = 0; i < tile.tileList.Count; i++)
                        {
                            if (tile.tileList[i].parent.name == "109" || tile.tileList[i].parent.name == "110" || tile.tileList[i].parent.name == "111" || tile.tileList[i].parent.name == "112" || tile.tileList[i].parent.name == "113" || tile.tileList[i].parent.name == "126" || tile.tileList[i].parent.name == "130" || tile.tileList[i].parent.name == "143" || tile.tileList[i].parent.name == "147" || tile.tileList[i].parent.name == "160" || tile.tileList[i].parent.name == "164" || tile.tileList[i].parent.name == "177" || tile.tileList[i].parent.name == "178" || tile.tileList[i].parent.name == "179" || tile.tileList[i].parent.name == "180" || tile.tileList[i].parent.name == "181")
                            {
                                tile.tileList[i].parent.gameObject.SetActive(true);
                            }
                        }

                        tile.enemyTile.transform.GetComponent<MakeArea>().InputAreaInfo("Area 23");
                    }

                    if(spcriptNum == 5)
                    {
                        dimmedCover.SetActive(false);
                        dimmedCover.transform.SetParent(transform.parent);
                        EnemyTalk();
                    }
                }

                if(enemyCheck)
                {
                    if(spcriptNum == 1)
                    {
                        tile.tutorialEnemy.GetComponent<TutorialEnemyManger>().SoldierAction();
                    }
                    else if (spcriptNum == 7)
                    {
                        inputManger.army.GetComponent<BoxCollider2D>().enabled = true;
                    }
                }

                if(finalCheck)
                {
                    if (spcriptNum == 1)
                    {
                        
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
                    fireBaseManger.LogEvent("tutirial_end");
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
        scripts.Add("왼쪽에 있는 숫자는 제빵사님이 보유하고 있는 ​자원량입니다.​");
        scripts.Add("오른쪽에 있는 숫자는 제빵사님이 턴이 지날 때마다 얻을 수 있는 자원량입니다.​");
        scripts.Add("생산 자원을 올릴 수록 생산량이 늘어나고​ 건설 할 때는 보유 자원을 소모합니다.​");
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

    public void EnemyTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 8;
        spcriptNum = 0;
        stopTalkNum = 1;
        moveCheck = false;
        enemyCheck = true;
        tile.SpawnEnemy();

        for (int i = 0; i < tile.tileList.Count; i++)
        {
            if(tile.tileList[i].parent.name == "127")
            {
                tile.tutorialEnemy.GetComponent<TutorialEnemyManger>().moveTile = tile.tileList[i].gameObject;
            }
        }

        //건물 부수는 파트
        scripts.Add("적 기지에서 우주 쥐가 출현했습니다.");
        scripts.Add("적군이 아군의 건물을 점령하게 되면 파괴 상태가 됩니다.");
        scripts.Add("파괴 상태가 된 건물은 건물 효과가 발동 되지 않습니다.");
        scripts.Add("파괴 상태의 건물은 휴식 턴에서 수리가 가능합니다.");
        scripts.Add("파괴 상태의 건물을 다음 턴에 수리하지 못하면 영구적으로 파괴됩니다.");
        scripts.Add("적군이 행동력을 모두 소모했습니다.");
        scripts.Add("이제는 반격 할 때 입니다.");
        scripts.Add("적군을 터치하여 공격해보세요.");
       
        spcriptText.text = scripts[spcriptNum];
    }

    public void FinalTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 13;
        spcriptNum = 0;
        stopTalkNum = 0;
        enemyCheck = false;
        finalCheck = true;
        // 유닛 이동 2 
        scripts.Add("아군을 터치 해보세요.");
        scripts.Add("유닛을 위로 이동시키세요.");
        // 카드 사용 8 
        scripts.Add("현재 턴에 모든 유닛의 공격 및 행동이 끝나면아이콘이 회색 상태가 되어 알려줍니다.");
        scripts.Add("적군을 처치하고 카드를 획득했습니다!");
        scripts.Add("하나의 스킬을 3개 모으면 상위 카드로 진화합니다.");
        scripts.Add("한 번에 5 종류 이상의 카드는 보유 할 수 없습니다!");
        scripts.Add("스킬 카드는 파란색은 아군 빨간색은 적군하얀색은 케이크에서 사용 가능합니다.");
        scripts.Add("스킬 카드를 드래그하여 원하는 유닛에 사용하세요.");
        //카드 사용후 11
        scripts.Add("아군의 이동횟수가 상승했습니다.");
        scripts.Add("적 기지를 파괴하세요!");
        scripts.Add("적 기지까지 파괴해야 패배하지 않습니다!");
        //이동 후 턴 on 13
        scripts.Add("모든 공격과 이동을 소모했습니다.");
        scripts.Add("턴을 넘겨야 행동력을 모두 회복합니다.");
        spcriptText.text = scripts[spcriptNum];
        sceneCheck = true;
    }
}
