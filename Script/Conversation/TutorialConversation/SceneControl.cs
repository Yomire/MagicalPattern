using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SceneControl : MonoBehaviour
{
    public Info1 info;
    public string Flag;
    public GameObject Obj;
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
        if (info.KeyPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.KeyPFlag != "On")
        {
            FadeManager.Instance.LoadScene("KeyPattern", 0.5f);
        }
    }
    public void KeyPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.KeyPFlag = "On";
        JsonData.Save(info, "scoreData");
        //Debug.Log(info.KeyPFlag);
    }
    public void Epi2After()
    {
        if (info.FishPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.FishPFlag != "On")
        {
            FadeManager.Instance.LoadScene("FishPattern", 0.5f);
        }
    }
    public void FishPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.FishPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi3After()
    {
        if (info.GekiPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.GekiPFlag != "On")
        {
            FadeManager.Instance.LoadScene("GekiPattern", 0.5f);
        }
    }
    public void GekiPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.GekiPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi4After()
    {
        if (info.ShieldPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.ShieldPFlag != "On")
        {
            FadeManager.Instance.LoadScene("ShieldPattern", 0.5f);
        }
    }
    public void ShieldPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.ShieldPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi5After()
    {
        if (info.ResonancePFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.ResonancePFlag != "On")
        {
            FadeManager.Instance.LoadScene("ResonancePattern", 0.5f);
        }
    }
    public void ResonancePatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.ResonancePFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi6After()
    {
        if (info.ButterflyPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.ButterflyPFlag != "On")
        {
            FadeManager.Instance.LoadScene("ButterflyPattern", 0.5f);
        }
    }
    public void ButterflyPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.ButterflyPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi7After()
    {
        if (info.HummerPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.HummerPFlag != "On")
        {
            FadeManager.Instance.LoadScene("HammerPattern", 0.5f);
        }
    }
    public void HammerPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.HummerPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi8After()
    {
        if (info.CoinPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.CoinPFlag != "On")
        {
            FadeManager.Instance.LoadScene("CoinPattern", 0.5f);
        }
    }
    public void CoinPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.CoinPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
    public void Epi9After()
    {
        if (info.PhoenixPFlag == "On")
        {
            FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        }
        if (info.PhoenixPFlag != "On")
        {
            FadeManager.Instance.LoadScene("PhoenixPattern", 0.5f);
        }
    }
    public void PhoenixPatternGet()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
        info.PhoenixPFlag = "On";
        JsonData.Save(info, "scoreData");
    }
}
