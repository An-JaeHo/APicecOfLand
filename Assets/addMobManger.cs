using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class addMobManger : MonoBehaviour
{
    public bool isTestMode;
    public Text LogText;
    public Button FrontAdsBtn, RewardAdsBtn;
    public GameEndController gameEndController;
    public GameObject bonusCard;


    void Start()
    {
        var requestConfiguration = new RequestConfiguration
           .Builder()
           .SetTestDeviceIds(new List<string>() { "1DF7B7CC05014E8" }) // test Device ID
           .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        LoadBannerAd();
        LoadFrontAd();
        LoadRewardAd();
    }

    void Update()
    {
        //FrontAdsBtn.interactable = frontAd.IsLoaded();
        RewardAdsBtn.interactable = rewardAd.IsLoaded();
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region ��� ����
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-4446231238185000/3038621567";
    BannerView bannerAd;


    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID,
            AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(false);
    }

    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
    }
    #endregion



    #region ���� ����
    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-4446231238185000/2516533927";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            LogText.text = "���鱤�� ����";
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion



    #region ������ ����
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-4446231238185000/6264207244";
    RewardedAd rewardAd;


    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());

        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            bonusCard.GetComponent<BonusCardController>().gameEndController.saveMgr.playerSave.milk += bonusCard.GetComponent<BonusCardController>().milk;

            bonusCard.GetComponent<BonusCardController>().gameEndController.saveMgr.playerSave.sugar += bonusCard.GetComponent<BonusCardController>().sugar;

            bonusCard.GetComponent<BonusCardController>().gameEndController.saveMgr.playerSave.flour += bonusCard.GetComponent<BonusCardController>().flour;

            gameEndController.supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = gameEndController.saveMgr.playerSave.milk.ToString();
            gameEndController.supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = gameEndController.saveMgr.playerSave.sugar.ToString();
            gameEndController.supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = gameEndController.saveMgr.playerSave.flour.ToString();
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }
    #endregion
}
