using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Messaging;

public class FireBase : MonoBehaviour
{
    //private FirebaseApp app;
    
    //void Start()
    //{
    //    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
    //    {
    //        if (task.Result == DependencyStatus.Available)
    //        {
    //            app = FirebaseApp.DefaultInstance;
    //            FirebaseMessaging.TokenReceived += OnTokenReceived;
    //            FirebaseMessaging.MessageReceived += OnMessageReceived;
    //        }
    //        else
    //        {
    //            Debug.LogError("fuck : " + task.Result);
    //        }
    //    });
    //}

    //void OnTokenReceived(object sender, TokenReceivedEventArgs e)
    //{
    //    if(e !=null)
    //    {
    //        Debug.LogFormat("[FIREBASE] Token : {0}", e.Token);
    //    }
    //}

    //void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    //{
    //    if(e != null && e.Message != null && e.Message.Notification != null)
    //    {
    //        Debug.LogFormat("[FIREBASE] Form : {0}, Title : {1}, Text : {2}",
    //            e.Message.From,
    //            e.Message.Notification.Title,
    //            e.Message.Notification.Body);
    //    }
    //}
}
