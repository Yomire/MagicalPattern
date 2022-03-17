using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsLoadScript : MonoBehaviour
{
    private string adUnitId;
    private RewardedAd rewardedAd;
    public GameControlScript GameConS;
    public ScoreManager ScoreManagerS;
    public GameObject AdsFailedObj, AdsFailedObjEnglish, PanelObj;
    public Animator PanelAnim;
    public string Flag, FailedFlag, EpiFlag;
    public ContinueButton CBSContinue, CBSExpDouble;
    void Start()
    {
        //アプリ起動時に一度必ず実行（他のスクリプトで実行していたら不要）
        MobileAds.Initialize(initStatus => { });
        //広告をロード
        RequestReward();
        this.rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoRewardedFailed;
        // 広告リクエストが正常に読み込まれたときに呼び出されます
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
    }
    private void RequestReward()
    {
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";  //本番
        //adUnitId = "ca-app-pub-3940256099942544/5224354917";  //テスト
#elif UNITY_IOS
        //adUnitId = "ca-app-pub-3940256099942544/1712485313";  //本番
        adUnitId = "ca-app-pub-3940256099942544/1712485313";  //テスト
#endif
        this.rewardedAd = new RewardedAd(adUnitId);
        //動画の視聴が完了したら「HandleUserEarnedReward」を呼ぶ
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }
    public void ShowReawrd()
    {
        if (FailedFlag != "On")
        {
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
                //Debug.Log("show");
            }
        }
            
        if (FailedFlag == "On")
        {
            AdsReLoad();
            AdsFailedObj.SetActive(true);
            CBSContinue.FillReset();
            CBSExpDouble.FillReset();
        }
    }
    //動画の視聴が完了したら実行される（途中で閉じられた場合は呼ばれない）
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (Flag == "Continue")
        {
            ContinueMethod();
        }
        if (Flag == "ExpDouble")
        {
            if (EpiFlag != "On")
            {
                ExpDoubleMethod();
            }
            if (EpiFlag == "On")
            {
                ExpDoubleMethodEpi();
            }
        }
    }
    // ロード失敗時
    public void HandleRewardBasedVideoRewardedFailed(object sender, AdFailedToLoadEventArgs args)
    {        
        //Debug.Log("error");
        FailedFlag = "On";
    }
    // ロード成功時
    public void HandleRewardedAdLoaded(object sender, System.EventArgs args)
    {
        FailedFlag = "Off";
    }
    public void FlagContinue()
    {
        Flag = "Continue";
    }
    public void FlagExpDouble()
    {
        Flag = "ExpDouble";
    }
    public void AdsReLoad()
    {
        //アプリ起動時に一度必ず実行（他のスクリプトで実行していたら不要）
        MobileAds.Initialize(initStatus => { });
        //広告をロード
        RequestReward();
        this.rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoRewardedFailed;
        // 広告リクエストが正常に読み込まれたときに呼び出されます
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
    }

    public void ContinueMethod()
    {
        GameConS.ContinueMethod();
        //Debug.Log("報酬獲得！");
        PanelObj.SetActive(false);
    }
    public void ExpDoubleMethod()
    {
        ScoreManagerS.GetExpDouble();
        //ScoreManagerS.FlagChangeGetExp();
        PanelAnim.SetBool("ContinueBool", false);
        PanelAnim.SetBool("GetExpBool", false);
        PanelAnim.SetBool("GetExpEndBool", true);
    }
    public void ExpDoubleMethodEpi()
    {
        ScoreManagerS.GetExpDouble();
        //ScoreManagerS.FlagChangeGetExp();
        PanelAnim.SetBool("ContinueBool", false);
        PanelAnim.SetBool("GetExpBool", false);
        PanelAnim.SetBool("GetExpEndBool", false);
        PanelAnim.SetBool("GetExpEpiBool", true);
    }
    public void EpiFlagOn()
    {
        EpiFlag = "On";
    }
}
