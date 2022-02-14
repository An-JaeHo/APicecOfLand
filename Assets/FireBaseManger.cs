using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class FireBaseManger : MonoBehaviour
{
     FirebaseApp app;

   
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                app = FirebaseApp.DefaultInstance;

                LogEvent("Test Log");
                LogEvent("Test Log 2","IntParam",111);
                LogEvent("Test Log 3", "FloatParam",2.22f);
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies" + task.Result);
            }
        });
    }

    public void LogEvent(string eventName)
    {
        FirebaseAnalytics.LogEvent(eventName);
    }

    public void LogEvent(string eventName, string paramName, int paramValue)
    {
        FirebaseAnalytics.LogEvent(eventName,paramName, paramValue);
    }

    public void LogEvent(string eventName, string paramName,float paramValue)
    {
        FirebaseAnalytics.LogEvent(eventName, paramName, paramValue);
    }

    public void LogEvent(string eventName, string paramName , string paramValue)
    {
        FirebaseAnalytics.LogEvent(eventName, paramName, paramValue);
    }

    public void LogEvent(string eventName, params Parameter[] paramArray)
    {
        FirebaseAnalytics.LogEvent(eventName, paramArray);
    }
}
