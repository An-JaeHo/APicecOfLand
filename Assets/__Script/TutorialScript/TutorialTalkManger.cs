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
        textNum = 4;
        scripts.Add("��ũ��Ʈ 1-1");
        scripts.Add("��ũ��Ʈ 1-2");
        scripts.Add("��ũ��Ʈ 1-3");
        scripts.Add("��ũ��Ʈ 1-4");
        tile.StartTile();
        sceneCheck = false;
        spcriptText.text = scripts[spcriptNum];
        talkCheck = false;
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        save = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
    }

    public void NextScriptButton()
    {
        Debug.Log(stopTalkNum);
        Debug.Log(spcriptNum);
        if (spcriptNum!= stopTalkNum)
        {
            spcriptNum++;

            if (spcriptNum < textNum)
            {
                spcriptText.text = scripts[spcriptNum];
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
        stopTalkNum = 0;
        scripts.Add("��ũ��Ʈ 2-1");
        scripts.Add("��ũ��Ʈ 2-2");
        scripts.Add("��ũ��Ʈ 2-3");
        scripts.Add("��ũ��Ʈ 2-4");
        scripts.Add("��ũ��Ʈ 2-5");
        spcriptText.text = scripts[spcriptNum];
    }

    public void BarrackTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 4;
        spcriptNum = 0;
        scripts.Add("�� �Ʊ�� �������?");
        scripts.Add("�̹����� �� ����ϰ� ū ����Ĩ��Ű�� ��������");
        scripts.Add("�̹����� ���ʿ� ����Ĩ��Ű�� ���Ծ�");
        scripts.Add("�����ư�� ������ ����Ĩ��Ű�� �θ���");
        
        spcriptText.text = scripts[spcriptNum];
    }

    public void MoveTalk()
    {
        //inputManger.talk = true;
        scripts.Clear();
        textNum = 5;
        spcriptNum = 0;
        scripts.Add("�� ���� ģ���� �ҷ���!");
        scripts.Add("�̹����� ����Ĩ��Ű�� ��������?");
        scripts.Add("�����ϱ� �ٴڿ� ���� �޶�����?");
        scripts.Add("���� ��Ű���� �̵��� �� �ִ� ������ ��Ÿ���ž� ");
        scripts.Add("� ��������");
        spcriptText.text = scripts[spcriptNum];
    }

    public void NextTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 6;
        spcriptNum = 0;
        scripts.Add("�̷� ����� �͹��Ⱦ�");
        scripts.Add("� �����ؼ� �ѾƳ�������");
        scripts.Add("�Ʊ�� ���� ����Ĩ��Ű�� ��������");
        scripts.Add("�̹����� ���� ���߾�");
        scripts.Add("�̰� �����Ҽ� �ִ� ������ �����ִ� �ž�");
        scripts.Add("� ������ �㸦 ���Ƴ���");
        spcriptText.text = scripts[spcriptNum];
    }

    public void FinalTalk()
    {
        inputManger.talk = true;
        scripts.Clear();
        textNum = 7;
        spcriptNum = 0;
        scripts.Add("�� ���� �� ���ּ��� �ı�����");
        scripts.Add("�׷��� ������ �� �㰡 ���ò���");
        scripts.Add("���ּ� ���� �ö󰣴ٸ� �ı��Ҽ� ��������");
        scripts.Add("� ��������");
        scripts.Add("���߾�! �츮�� �㸦 �����ƾ�!");
        scripts.Add("�� ����� �ٽ� �ò���");
        scripts.Add("���� �������ݿ� ����� �غ� ����");
        spcriptText.text = scripts[spcriptNum];
        sceneCheck = true;
    }
}
