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
        scripts.Add("���� ������ ����� ���� �ò���");
        scripts.Add("����� �츮 ����ũ���� �����ϱ� ����");
        scripts.Add("� �غ� �ؾߵ�!!!");
        scripts.Add("���� �׷� �Բ� �ο��� ģ������ �ҷ� ����?");
        scripts.Add("���� ���� ���̴� Ÿ���� ��������");
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
        
        scripts.Add("�� �߾�! �׷� ���� ���̴� ������ ��������");
        scripts.Add("���� â�� ������ ��Ÿ�� ���� ������?");
        scripts.Add("�װ� ������ ������ �Ǿ��ٴ� ���� �ǹ���");
        scripts.Add("�Ʒ��� �Ǽ� ��ư�� ������ ������ �Ǽ�����!");
        scripts.Add("������ �����Ȱ� ����!");
        scripts.Add("�׷����� ģ������ ����� �ְڴ� ������ ��������");
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
