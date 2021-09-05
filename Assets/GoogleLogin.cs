using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class GoogleLogin : MonoBehaviour
{
    public InputField ScoreInput;

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }


    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            
        });
    }


    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }


    public void ShowAchievementUI() => Social.ShowAchievementsUI();

    public void UnlockAchievement_1() => Social.ReportProgress(GPGSIds.achievement_one, 100, (bool success) => { });

    public void UnlockAchievement_2() => Social.ReportProgress(GPGSIds.achievement_two, 100, (bool success) => { });

    public void UnlockAchievement_3() => PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_three, 1, (bool success) => { });



    public void ShowLeaderboardUI() => Social.ShowLeaderboardUI();

    public void ShowLeaderboardUI_4() => ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard_four);

    public void AddLeaderboard_5() => Social.ReportScore(int.Parse(ScoreInput.text), GPGSIds.leaderboard_five, (bool success) => { });

}
