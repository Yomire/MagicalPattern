using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SceneControl : MonoBehaviour
{
    public Info1 info;
    public string Flag, OnceFlag;
    public GameObject Obj, RepeateBlockObj;
    public AudioSource SEASource;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        if(Flag == "Tutorial")
        {
            info.StoryFlag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi1")
        {
            info.Epi2Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi2")
        {
            info.Epi3Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi3")
        {
            info.Epi4Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi4")
        {
            info.Epi5Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi5")
        {
            info.Epi6Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi6")
        {
            info.Epi7Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi7")
        {
            info.Epi8Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi8")
        {
            info.Epi9Flag = "On";
            JsonData.Save(info, "scoreData");
        }
        if (Flag == "Epi9")
        {
            info.EndlessFlag = "On";
            info.CheckmateFlag = "On";
            JsonData.Save(info, "scoreData");
        }
        OnceFlag = null;
    }
    public void SceneNextMethod()
    {
        FadeManager.Instance.LoadScene("TutorialStage", 0.5f);
    }
    public void SceneNextMethod2()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
    }
    public void ObjActive()
    {
        if(Obj != null)
        {
            Obj.SetActive(true);
        }
    }
    public void SEMethod()
    {
        SEASource.Play();
    }
    public void Epi1After()
    {
        if (OnceFlag == null)
        {
            if (info.KeyPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.KeyPFlag != "On")
            {
                FadeManager.Instance.LoadScene("KeyPattern", 0.5f);
            }
            OnceFlag = "On";
        }        
    }
    public void KeyPatternGet()
    {
        if(OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.KeyPFlag = "On";
            JsonData.Save(info, "scoreData");
            //Debug.Log(info.KeyPFlag);
            OnceFlag = "On";
        }
    }
    public void Epi2After()
    {
        if (OnceFlag == null)
        {
            if (info.FishPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.FishPFlag != "On")
            {
                FadeManager.Instance.LoadScene("FishPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void FishPatternGet()
    {
        if (OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.FishPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }            
    }
    public void Epi3After()
    {
        if (OnceFlag == null)
        {
            if (info.GekiPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.GekiPFlag != "On")
            {
                FadeManager.Instance.LoadScene("GekiPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void GekiPatternGet()
    {
        if(OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.GekiPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }        
    }
    public void Epi4After()
    {
        if (OnceFlag == null)
        {
            if (info.ShieldPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.ShieldPFlag != "On")
            {
                FadeManager.Instance.LoadScene("ShieldPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void ShieldPatternGet()
    {
        if(OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.ShieldPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }        
    }
    public void Epi5After()
    {
        if (OnceFlag == null)
        {
            if (info.ResonancePFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.ButterflyPFlag != "On")
            {
                FadeManager.Instance.LoadScene("ButterflyPattern", 0.5f);
            }
            OnceFlag = "On";
        }                 
    }
    public void ResonancePatternGet()
    {
        if(OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.ResonancePFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }        
    }
    public void Epi6After()
    {
        if (OnceFlag == null)
        {
            if (info.ButterflyPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.ResonancePFlag != "On")
            {
                FadeManager.Instance.LoadScene("ResonancePattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void ButterflyPatternGet()
    {
        if (OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.ButterflyPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }           
    }
    public void Epi7After()
    {
        if (OnceFlag == null)
        {
            if (info.HummerPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.HummerPFlag != "On")
            {
                FadeManager.Instance.LoadScene("HammerPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void HammerPatternGet()
    {
        if (OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.HummerPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }            
    }
    public void Epi8After()
    {
        if (OnceFlag == null)
        {
            if (info.CoinPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.CoinPFlag != "On")
            {
                FadeManager.Instance.LoadScene("CoinPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void CoinPatternGet()
    {
        if (OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.CoinPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }            
    }
    public void Epi9After()
    {
        if (OnceFlag == null)
        {
            if (info.PhoenixPFlag == "On")
            {
                FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            }
            if (info.PhoenixPFlag != "On")
            {
                FadeManager.Instance.LoadScene("PhoenixPattern", 0.5f);
            }
            OnceFlag = "On";
        }            
    }
    public void PhoenixPatternGet()
    {
        if (OnceFlag == null)
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
            info.PhoenixPFlag = "On";
            JsonData.Save(info, "scoreData");
            OnceFlag = "On";
        }            
    }
}
