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
        scripts.Add("���� ������ ������� ���� �ò���");
        scripts.Add("� �غ� �ؾߵ�");
        scripts.Add("���� �׷� �Բ� �ο��� ģ������ ����� ����?");
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
        scripts.Add("�̷� ����� �͹��Ⱦ�");
        scripts.Add("� �����ؼ� �ѾƳ�������");
        spcriptText.text = scripts[spcriptNum];
        gameObject.SetActive(true);
    }

    public void FinalTalk()
    {
        scripts.Clear();
        textNum = 1;
        spcriptNum = 0;
        scripts.Add("���߾�! ���� �������ݿ� ����� �غ� ����");
        spcriptText.text = scripts[spcriptNum];
        gameObject.SetActive(true);
        sceneCheck = true;
    }
}
