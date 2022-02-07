using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;

public class GoogleManager : MonoBehaviour
{
    public Text LogText;

    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }


    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success) LogText.text = Social.localUser.id + " \n " + Social.localUser.userName;
            else LogText.text = "���� �α��� ����";
        });
    }


    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        LogText.text = "���� �α׾ƿ�";
    }
}
