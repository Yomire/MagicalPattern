using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class FillButton : MonoBehaviour
{
    public Info1 info;
    public Image fillImage, AlphaImage;
    public string flag = "null", flagScene;
    float red, green, blue, alpha;
    bool isCalledOnce = false;
    public AudioSource SESource;
    public AudioClip EpisodeSound, EnterSound, ErrorSound;
    public Text EnterText, TotalExpText;
    public GameObject ExplainObj, KeyPUI, KeyQPUI, FishPUI, FishQPUI, GekiPUI, GekiQPUI, ShieldPUI, ShieldQPUI, ResonancePUI, ResonanceQPUI, ButterflyPUI, ButterflyQPUI, 
        HummerPUI, HummerQPUI, CoinPUI, CoinQPUI, PhoenixPUI, PhoenixQPUI, SlowPUI, SlowQPUI, BladePUI, BladeQPUI, BoomerangPUI, BoomerangQPUI, 
        ThunderPUI, ThunderQPUI, MagnetPUI, MagnetQPUI, ArcherPUI, ArcherQPUI, BombPUI, BombQPUI, RevolvingEdgePUI, RevolvingEdgeQPUI, ScythePUI, ScytheQPUI, 
        TanglerPUI, TanglerQPUI, StarPUI, StarQPUI;
    public Animator ExplainAnim;
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        //Debug.Log(info.TotalExp);
        fillImage.fillAmount = 0;
        red = AlphaImage.color.r;
        green = AlphaImage.color.g;
        blue = AlphaImage.color.b;
        alpha = AlphaImage.color.a;
        ExplainAnim.SetBool("ENullBool", false);
        ExplainAnim.SetBool("BulletEBool", false);
        ExplainAnim.SetBool("KeyEBool", false);
        ExplainAnim.SetBool("FishEBool", false);
        ExplainAnim.SetBool("GekiEBool", false);
        ExplainAnim.SetBool("ShieldEBool", false);
        ExplainAnim.SetBool("ResonanceEBool", false);
        ExplainAnim.SetBool("ButterflyEBool", false);
        ExplainAnim.SetBool("HummerEBool", false);
        ExplainAnim.SetBool("CoinEBool", false);
        ExplainAnim.SetBool("PhoenixEBool", false);
        ExplainAnim.SetBool("SlowEBool", false);
        ExplainAnim.SetBool("BladeEBool", false);
        ExplainAnim.SetBool("BoomerangEBool", false);
        ExplainAnim.SetBool("ThunderEBool", false);
        ExplainAnim.SetBool("MagnetEBool", false);
        ExplainAnim.SetBool("ArcherEBool", false);
        ExplainAnim.SetBool("BombEBool", false);
        ExplainAnim.SetBool("RevolvingEdgeEBool", false);
        ExplainAnim.SetBool("ScytheEBool", false);
        ExplainAnim.SetBool("TanglerEBool", false);
        ExplainAnim.SetBool("StarEBool", false);
        if (info.KeyPFlag == "On")
        {
            KeyPUI.SetActive(true);
            KeyQPUI.SetActive(false);
        }
        if (info.KeyPFlag != "On")
        {
            KeyPUI.SetActive(false);
            KeyQPUI.SetActive(true);
        }
        if (info.FishPFlag == "On")
        {
            FishPUI.SetActive(true);
            FishQPUI.SetActive(false);
        }
        if (info.FishPFlag != "On")
        {
            FishPUI.SetActive(false);
            FishQPUI.SetActive(true);
        }
        if (info.GekiPFlag == "On")
        {
            GekiPUI.SetActive(true);
            GekiQPUI.SetActive(false);
        }
        if (info.GekiPFlag != "On")
        {
            GekiPUI.SetActive(false);
            GekiQPUI.SetActive(true);
        }
        if (info.ShieldPFlag == "On")
        {
            ShieldPUI.SetActive(true);
            ShieldQPUI.SetActive(false);
        }
        if (info.ShieldPFlag != "On")
        {
            ShieldPUI.SetActive(false);
            ShieldQPUI.SetActive(true);
        }
        if (info.ResonancePFlag == "On")
        {
            ResonancePUI.SetActive(true);
            ResonanceQPUI.SetActive(false);
        }
        if (info.ResonancePFlag != "On")
        {
            ResonancePUI.SetActive(false);
            ResonanceQPUI.SetActive(true);
        }
        if (info.ButterflyPFlag == "On")
        {
            ButterflyPUI.SetActive(true);
            ButterflyQPUI.SetActive(false);
        }
        if (info.ButterflyPFlag != "On")
        {
            ButterflyPUI.SetActive(false);
            ButterflyQPUI.SetActive(true);
        }
        if (info.HummerPFlag == "On")
        {
            HummerPUI.SetActive(true);
            HummerQPUI.SetActive(false);
        }
        if (info.HummerPFlag != "On")
        {
            HummerPUI.SetActive(false);
            HummerQPUI.SetActive(true);
        }
        if (info.CoinPFlag == "On")
        {
            CoinPUI.SetActive(true);
            CoinQPUI.SetActive(false);
        }
        if (info.CoinPFlag != "On")
        {
            CoinPUI.SetActive(false);
            CoinQPUI.SetActive(true);
        }
        if (info.PhoenixPFlag == "On")
        {
            PhoenixPUI.SetActive(true);
            PhoenixQPUI.SetActive(false);
        }
        if (info.PhoenixPFlag != "On")
        {
            PhoenixPUI.SetActive(false);
            PhoenixQPUI.SetActive(true);
        }
        if (info.SlowPFlag == "On")
        {
            SlowPUI.SetActive(true);
            SlowQPUI.SetActive(false);
        }
        if (info.SlowPFlag != "On")
        {
            SlowPUI.SetActive(false);
            SlowQPUI.SetActive(true);
        }
        if (info.BladePFlag == "On")
        {
            BladePUI.SetActive(true);
            BladeQPUI.SetActive(false);
        }
        if (info.BladePFlag != "On")
        {
            BladePUI.SetActive(false);
            BladeQPUI.SetActive(true);
        }
        if (info.BoomerangPFlag == "On")
        {
            BoomerangPUI.SetActive(true);
            BoomerangQPUI.SetActive(false);
        }
        if (info.BoomerangPFlag != "On")
        {
            BoomerangPUI.SetActive(false);
            BoomerangQPUI.SetActive(true);
        }
        if (info.ThunderPFlag == "On")
        {
            ThunderPUI.SetActive(true);
            ThunderQPUI.SetActive(false);
        }
        if (info.ThunderPFlag != "On")
        {
            ThunderPUI.SetActive(false);
            ThunderQPUI.SetActive(true);
        }
        if (info.MagnetPFlag == "On")
        {
            MagnetPUI.SetActive(true);
            MagnetQPUI.SetActive(false);
        }
        if (info.MagnetPFlag != "On")
        {
            MagnetPUI.SetActive(false);
            MagnetQPUI.SetActive(true);
        }
        if (info.ArcherPFlag == "On")
        {
            ArcherPUI.SetActive(true);
            ArcherQPUI.SetActive(false);
        }
        if (info.ArcherPFlag != "On")
        {
            ArcherPUI.SetActive(false);
            ArcherQPUI.SetActive(true);
        }
        if (info.BombPFlag == "On")
        {
            BombPUI.SetActive(true);
            BombQPUI.SetActive(false);
        }
        if (info.BombPFlag != "On")
        {
            BombPUI.SetActive(false);
            BombQPUI.SetActive(true);
        }
        if (info.RevolvingEdgePFlag == "On")
        {
            RevolvingEdgePUI.SetActive(true);
            RevolvingEdgeQPUI.SetActive(false);
        }
        if (info.RevolvingEdgePFlag != "On")
        {
            RevolvingEdgePUI.SetActive(false);
            RevolvingEdgeQPUI.SetActive(true);
        }
        if (info.ScythePFlag == "On")
        {
            ScythePUI.SetActive(true);
            ScytheQPUI.SetActive(false);
        }
        if (info.ScythePFlag != "On")
        {
            ScythePUI.SetActive(false);
            ScytheQPUI.SetActive(true);
        }
        if (info.TanglerPFlag == "On")
        {
            TanglerPUI.SetActive(true);
            TanglerQPUI.SetActive(false);
        }
        if (info.TanglerPFlag != "On")
        {
            TanglerPUI.SetActive(false);
            TanglerQPUI.SetActive(true);
        }
        if (info.StarPFlag == "On")
        {
            StarPUI.SetActive(true);
            StarQPUI.SetActive(false);
        }
        if (info.StarPFlag != "On")
        {
            StarPUI.SetActive(false);
            StarQPUI.SetActive(true);
        }
    }

    void Update()
    {
        if (flag == "Minus")
        {
            fillImage.fillAmount -= 0.1f;
            AlphaImage.color = new Color(red, green, blue, alpha);
            alpha += 0.01f;
        }
        if (flag == "Puls")
        {
            fillImage.fillAmount += 0.1f;

            AlphaImage.color = new Color(red, green, blue, alpha);
            alpha -= 0.01f;
        }
        if(fillImage.fillAmount == 1f)
        {
            flag = "SceneTransition";
            /*AlphaImage.color = new Color(red, green, blue, alpha);
            alpha -= 0.01f;*/
            if(flagScene == "0")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("TutorialConversation", 1f);
                    SESource.PlayOneShot(EnterSound);
                }                    
            }
            if (flagScene == "1")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode1", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "2")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode2", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "3")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode3", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "4")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode4", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "5")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode5", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "6")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode6", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "7")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode7", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "8")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode8", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "9")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("Episode9", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "Endless")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("EndlessVer1", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "Checkmate")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    FadeManager.Instance.LoadScene("CheckMate", 1f);
                    SESource.PlayOneShot(EnterSound);
                }
            }
            if (flagScene == "Bullet")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", true);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Key")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", true);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Fish")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", true);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Geki")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", true);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Shield")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", true);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Resonance")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", true);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Butterfly")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", true);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Hummer")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", true);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Coin")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", true);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Phoenix")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", true);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "Slow")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", true);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if(flagScene == "NotYetSlow")
            {
                if (!isCalledOnce)
                {
                    if(info.TotalExp >= 10000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 10000;                        
                        info.SlowPFlag = "On";
                        EnterText.text = "Slow";
                        JsonData.Save(info, "scoreData");
                        SlowPUI.SetActive(true);
                        SlowQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 10000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Blade")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", true);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetBlade")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 50000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 50000;
                        info.BladePFlag = "On";
                        EnterText.text = "Blade";
                        JsonData.Save(info, "scoreData");
                        BladePUI.SetActive(true);
                        BladeQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 50000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Boomerang")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", true);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetBoomerang")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 100000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 100000;
                        info.BoomerangPFlag = "On";
                        EnterText.text = "Boomerang";
                        JsonData.Save(info, "scoreData");
                        BoomerangPUI.SetActive(true);
                        BoomerangQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 100000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Thunder")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", true);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetThunder")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 300000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 300000;
                        info.ThunderPFlag = "On";
                        EnterText.text = "Thunder";
                        JsonData.Save(info, "scoreData");
                        ThunderPUI.SetActive(true);
                        ThunderQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 300000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Magnet")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", true);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetMagnet")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 300000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 300000;
                        info.MagnetPFlag = "On";
                        EnterText.text = "Magnet";
                        JsonData.Save(info, "scoreData");
                        MagnetPUI.SetActive(true);
                        MagnetQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 300000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Archer")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", true);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetArcher")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.ArcherPFlag = "On";
                        EnterText.text = "Archer";
                        JsonData.Save(info, "scoreData");
                        ArcherPUI.SetActive(true);
                        ArcherQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "Bomb")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", true);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetBomb")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.BombPFlag = "On";
                        EnterText.text = "Bomb";
                        JsonData.Save(info, "scoreData");
                        BombPUI.SetActive(true);
                        BombQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }                    
                }
            }
            if (flagScene == "RevolvingEdge")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", true);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetRevolvingEdge")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.RevolvingEdgePFlag = "On";
                        EnterText.text = "RevolvingEdge";
                        JsonData.Save(info, "scoreData");
                        RevolvingEdgePUI.SetActive(true);
                        RevolvingEdgeQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }
                }
            }
            if (flagScene == "Scythe")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", true);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetScythe")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.ScythePFlag = "On";
                        EnterText.text = "Scythe";
                        JsonData.Save(info, "scoreData");
                        ScythePUI.SetActive(true);
                        ScytheQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }
                }
            }
            if (flagScene == "Tangler")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", true);
                    ExplainAnim.SetBool("StarEBool", false);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetTangler")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.TanglerPFlag = "On";
                        EnterText.text = "Tangler";
                        JsonData.Save(info, "scoreData");
                        TanglerPUI.SetActive(true);
                        TanglerQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }
                }
            }
            if (flagScene == "Star")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.PlayOneShot(EnterSound);
                    ExplainObj.SetActive(true);
                    ExplainAnim.SetBool("ENullBool", false);
                    ExplainAnim.SetBool("BulletEBool", false);
                    ExplainAnim.SetBool("KeyEBool", false);
                    ExplainAnim.SetBool("FishEBool", false);
                    ExplainAnim.SetBool("GekiEBool", false);
                    ExplainAnim.SetBool("ShieldEBool", false);
                    ExplainAnim.SetBool("ResonanceEBool", false);
                    ExplainAnim.SetBool("ButterflyEBool", false);
                    ExplainAnim.SetBool("HummerEBool", false);
                    ExplainAnim.SetBool("CoinEBool", false);
                    ExplainAnim.SetBool("PhoenixEBool", false);
                    ExplainAnim.SetBool("SlowEBool", false);
                    ExplainAnim.SetBool("BladeEBool", false);
                    ExplainAnim.SetBool("BoomerangEBool", false);
                    ExplainAnim.SetBool("ThunderEBool", false);
                    ExplainAnim.SetBool("MagnetEBool", false);
                    ExplainAnim.SetBool("ArcherEBool", false);
                    ExplainAnim.SetBool("BombEBool", false);
                    ExplainAnim.SetBool("RevolvingEdgeEBool", false);
                    ExplainAnim.SetBool("ScytheEBool", false);
                    ExplainAnim.SetBool("TanglerEBool", false);
                    ExplainAnim.SetBool("StarEBool", true);
                    Invoke("FillReset", 1f);
                }
            }
            if (flagScene == "NotYetStar")
            {
                if (!isCalledOnce)
                {
                    if (info.TotalExp >= 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(EnterSound);
                        info.TotalExp -= 500000;
                        info.StarPFlag = "On";
                        EnterText.text = "Star";
                        JsonData.Save(info, "scoreData");
                        StarPUI.SetActive(true);
                        StarQPUI.SetActive(false);
                        Invoke("ExpTextUpdate", 0.1f);
                        Invoke("FillReset", 1f);
                    }
                    if (info.TotalExp < 500000)
                    {
                        isCalledOnce = true;
                        SESource.PlayOneShot(ErrorSound);
                        Invoke("FillReset", 1f);
                    }
                }
            }
        }
        if (fillImage.fillAmount <= 0f)
        {
            flag = "null";
        }
    }

    public void FillPuls()
    {
        if(flagScene != "NotYet")
        {
            flag = "Puls";
        }
        if (flagScene == "NotYet")
        {
            SESource.PlayOneShot(ErrorSound);
        }
    }
    public void FillMinus()
    {
        if(flag != "SceneTransition")
        {
            flag = "Minus";
        }        
    }
    public void FillReset()
    {
        fillImage.fillAmount = 0;
        flag = "Minus";
        isCalledOnce = false;
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Untagged")
        {
            flagScene = "NotYet";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode0")
        {
            flagScene = "0";
            //SESource.PlayOneShot(EpisodeSound);
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode1")
        {
            flagScene = "1";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode2")
        {
            flagScene = "2";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode3")
        {
            flagScene = "3";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode4")
        {
            flagScene = "4";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode5")
        {
            flagScene = "5";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode6")
        {
            flagScene = "6";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode7")
        {
            flagScene = "7";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode8")
        {
            flagScene = "8";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Episode9")
        {
            flagScene = "9";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Endless")
        {
            flagScene = "Endless";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "Checkmate")
        {
            flagScene = "Checkmate";
            EnterText.text = "Enter";
        }
        if (trcol.gameObject.tag == "BulletPattern")
        {
            flagScene = "Bullet";
            EnterText.text = "Bullet";
        }
        if (trcol.gameObject.tag == "KeyPattern")
        {
            if(info.KeyPFlag == "On")
            {
                flagScene = "Key";
                EnterText.text = "Key";
            }
            if (info.KeyPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "FishPattern")
        {
            if (info.FishPFlag == "On")
            {
                flagScene = "Fish";
                EnterText.text = "Fish";
            }
            if (info.FishPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "GekiPattern")
        {
            if (info.GekiPFlag == "On")
            {
                flagScene = "Geki";
                EnterText.text = "Geki";
            }
            if (info.GekiPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ShieldPattern")
        {
            if (info.ShieldPFlag == "On")
            {
                flagScene = "Shield";
                EnterText.text = "Shield";
            }
            if (info.ShieldPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ResonancePattern")
        {
            if (info.ResonancePFlag == "On")
            {
                flagScene = "Resonance";
                EnterText.text = "Resonance";
            }
            if (info.ResonancePFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ButterflyPattern")
        {
            if (info.ButterflyPFlag == "On")
            {
                flagScene = "Butterfly";
                EnterText.text = "Butterfly";
            }
            if (info.ButterflyPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "HummerPattern")
        {
            if (info.HummerPFlag == "On")
            {
                flagScene = "Hummer";
                EnterText.text = "Hammer";
            }
            if (info.HummerPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "CoinPattern")
        {
            if (info.CoinPFlag == "On")
            {
                flagScene = "Coin";
                EnterText.text = "Coin";
            }
            if (info.CoinPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "PhoenixPattern")
        {
            if (info.PhoenixPFlag == "On")
            {
                flagScene = "Phoenix";
                EnterText.text = "Phoenix";
            }
            if (info.PhoenixPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "SlowPattern")
        {
            if (info.SlowPFlag == "On")
            {
                flagScene = "Slow";
                EnterText.text = "Slow";
            }
            if (info.SlowPFlag != "On")
            {
                flagScene = "NotYetSlow";
                EnterText.text = "-10000Exp";
            }
        }
        if (trcol.gameObject.tag == "BladePattern")
        {
            if (info.BladePFlag == "On")
            {
                flagScene = "Blade";
                EnterText.text = "Blade";
            }
            if (info.BladePFlag != "On")
            {
                flagScene = "NotYetBlade";
                EnterText.text = "-50000Exp";
            }
        }
        if (trcol.gameObject.tag == "BoomerangPattern")
        {
            if (info.BoomerangPFlag == "On")
            {
                flagScene = "Boomerang";
                EnterText.text = "Boomerang";
            }
            if (info.BoomerangPFlag != "On")
            {
                flagScene = "NotYetBoomerang";
                EnterText.text = "-100000Exp";
            }
        }
        if (trcol.gameObject.tag == "ThunderPattern")
        {
            if (info.ThunderPFlag == "On")
            {
                flagScene = "Thunder";
                EnterText.text = "Thunder";
            }
            if (info.ThunderPFlag != "On")
            {
                flagScene = "NotYetThunder";
                EnterText.text = "-300000Exp";
            }
        }
        if (trcol.gameObject.tag == "MagnetPattern")
        {
            if (info.MagnetPFlag == "On")
            {
                flagScene = "Magnet";
                EnterText.text = "Magnet";
            }
            if (info.MagnetPFlag != "On")
            {
                flagScene = "NotYetMagnet";
                EnterText.text = "-300000Exp";
            }
        }
        if (trcol.gameObject.tag == "ArcherPattern")
        {
            if (info.ArcherPFlag == "On")
            {
                flagScene = "Archer";
                EnterText.text = "Archer";
            }
            if (info.ArcherPFlag != "On")
            {
                flagScene = "NotYetArcher";
                EnterText.text = "-500000Exp";
            }
        }
        if (trcol.gameObject.tag == "BombPattern")
        {
            if (info.BombPFlag == "On")
            {
                flagScene = "Bomb";
                EnterText.text = "Bomb";
            }
            if (info.BombPFlag != "On")
            {
                flagScene = "NotYetBomb";
                EnterText.text = "-500000Exp";
            }
        }
        if (trcol.gameObject.tag == "RevolvingEdgePattern")
        {
            if (info.RevolvingEdgePFlag == "On")
            {
                flagScene = "RevolvingEdge";
                EnterText.text = "RevolvingEdge";
            }
            if (info.RevolvingEdgePFlag != "On")
            {
                flagScene = "NotYetRevolvingEdge";
                EnterText.text = "-500000Exp";
            }
        }
        if (trcol.gameObject.tag == "ScythePattern")
        {
            if (info.ScythePFlag == "On")
            {
                flagScene = "Scythe";
                EnterText.text = "Scythe";
            }
            if (info.ScythePFlag != "On")
            {
                flagScene = "NotYetScythe";
                EnterText.text = "-500000Exp";
            }
        }
        if (trcol.gameObject.tag == "TanglerPattern")
        {
            if (info.TanglerPFlag == "On")
            {
                flagScene = "Tangler";
                EnterText.text = "Tangler";
            }
            if (info.TanglerPFlag != "On")
            {
                flagScene = "NotYetTangler";
                EnterText.text = "-500000Exp";
            }
        }
        if (trcol.gameObject.tag == "StarPattern")
        {
            if (info.StarPFlag == "On")
            {
                flagScene = "Star";
                EnterText.text = "Star";
            }
            if (info.StarPFlag != "On")
            {
                flagScene = "NotYetStar";
                EnterText.text = "-500000Exp";
            }
        }
    }
    public void ExpTextUpdate()
    {
        TotalExpText.text = "  Total Exp :" + info.TotalExp;
    }
}
