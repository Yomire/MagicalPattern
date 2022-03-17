using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System.IO;
public class IAPManager : MonoBehaviour
{
    private string moneysupport = "com.YOMIRE.MagicalPattern.MoneySupport", removeAds = "com.YOMIRE.MagicalPattern.removeads";
    public GameObject restoreButton, PurchasedObj;
    public Info1 info;
    public AudioSource SESource;
    public AudioClip ErrorSound, EnterSound;
    public EndlessScoreVer2 ScoreS;
    private void Awake()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        if (info.RemoveAdsFlag == "On")
        {
            PurchasedObj.SetActive(true);
        }
    }
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == moneysupport)
        {
            //Debug.Log("moneysupport");
        }
        if (product.definition.id == removeAds)
        {
            ScoreS.RemoveAdsMethod();
            //Debug.Log(info.SlowPFlag);
            PurchasedObj.SetActive(true);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failurReason)
    {
        Debug.Log(product.definition.id + "failed because" + failurReason);
    }

    public void ErrorSE()
    {
        SESource.PlayOneShot(ErrorSound);
    }
    public void EnterSE()
    {
        SESource.PlayOneShot(EnterSound);        
    }
    public void SaveMethod()
    {
        JsonData.Save(info, "scoreData");
    }
}
