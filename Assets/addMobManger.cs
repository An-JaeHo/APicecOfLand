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

    private bool supplyCheck;
    private int pureMilkSupply;
    private int pureFlourSupply;
    private int pureSugarSupply;
    private int sumMilkSupply;
    private int sumFlourSupply;
    private int sumSugarSupply;
    private float times;

    void Start()
    {
        var requestConfiguration = new RequestConfiguration
           .Builder()
           .SetTestDeviceIds(new List<string>() { "1DF7B7CC05014E8" }) // test Device ID
           .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);
        LoadRewardAd();
    }

    void Update()
    {
        if (supplyCheck)
        {
            times += Time.deltaTime;
            gameEndController.supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text 
                = ((int)Mathf.Lerp(pureMilkSupply, sumMilkSupply, times / 3)).ToString();

            gameEndController.supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text
                = ((int)Mathf.Lerp(pureSugarSupply, sumSugarSupply, times / 3)).ToString();

            gameEndController.supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text 
                = ((int)Mathf.Lerp(pureFlourSupply, sumFlourSupply, times / 3)).ToString();

            gameEndController.addButton.GetComponent<Button>().interactable = false;

            if (times / 3 >= 1)
            {
                gameEndController.saveMgr.playerSave.milk = sumMilkSupply;
                gameEndController.saveMgr.playerSave.sugar = sumSugarSupply;
                gameEndController.saveMgr.playerSave.flour = sumFlourSupply;
                supplyCheck = false;
            }
        }
        else
        {
            times = 0;
        }
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region ¹è³Ê ±¤°í
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



    #region Àü¸é ±¤°í
    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-4446231238185000/2516533927";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            LogText.text = "Àü¸é±¤°í ¼º°ø";
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion



    #region ¸®¿öµå ±¤°í
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

            pureMilkSupply = gameEndController.saveMgr.playerSave.milk;
            pureSugarSupply = gameEndController.saveMgr.playerSave.sugar;
            pureFlourSupply = gameEndController.saveMgr.playerSave.flour;

            sumMilkSupply = gameEndController.saveMgr.playerSave.milk + bonusCard.GetComponent<BonusCardController>().milk;
            sumSugarSupply = gameEndController.saveMgr.playerSave.sugar + bonusCard.GetComponent<BonusCardController>().sugar;
            sumFlourSupply = gameEndController.saveMgr.playerSave.flour + bonusCard.GetComponent<BonusCardController>().flour;
            supplyCheck = true;
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }
    #endregion
}
