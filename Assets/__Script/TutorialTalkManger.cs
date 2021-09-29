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


        scripts.Add("���� ������ ������� ���� �ò���");
        scripts.Add("� �غ� �ؾߵ�");

        scripts.Add("���� ���� �ڿ����� �غ� �غ���");

        scripts.Add("���� �׷� �Բ� �ο��� ģ������ ����� ����?");
        scripts.Add("�̷� ����� �͹��Ⱦ�");
        scripts.Add("� �����ؼ� �ѾƳ�������");

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
