using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GoogleLoginManger : MonoBehaviour
{
    [SerializeField] Text _status;

    void Awake()
    {
        //���� �� �ʱ�ȭ
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        //����뿡 �����
        PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform Ȱ��ȭ
        PlayGamesPlatform.Activate();
    }

    public void PlayLogin()
    {
        //���� ����ڰ� �����Ǿ����� Ȯ���մϴ�
        if (!Social.localUser.authenticated)
        {
            //���� Ȱ�� Social API ������ ���� ���� ����ڸ� �����ϰ� ���� ������ �����͸� �����ɴϴ�
            //ù��° ���� : �������� / �ι�° ���� : ���н� ���� �α�
            Social.localUser.Authenticate((bool isOk, string error) =>
            {
                if (isOk)
                    _status.text = Social.localUser.userName;
                else
                    _status.text = error;
            });
        }
    }

    public void PlayLogout()
    {
        //Social.Active : ���� Ȱ��ȭ�� �Ҽ� �÷���(���� ��Ȳ������ PlayGamesPlatform)�� ��ȯ
        PlayGamesPlatform platform = Social.Active as PlayGamesPlatform;
        platform.SignOut();
        _status.text = "Logout";
    }
}
