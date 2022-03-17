using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Info1
{
    public int EScore1st, EScore2nd, EScore3rd, TotalExp;
    public string KeyPFlag, FishPFlag, GekiPFlag, ShieldPFlag, ResonancePFlag, ButterflyPFlag,
        HummerPFlag, CoinPFlag, PhoenixPFlag, SlowPFlag, BladePFlag, BoomerangPFlag, ThunderPFlag,
        MagnetPFlag, ArcherPFlag, BombPFlag, RevolvingEdgePFlag, ScythePFlag, TanglerPFlag, StarPFlag, 
        RemoveAdsFlag, StoryFlag, EndlessFlag, CheckmateFlag, 
        Epi2Flag, Epi3Flag, Epi4Flag, Epi5Flag, Epi6Flag, Epi7Flag, Epi8Flag, Epi9Flag;
    public float BGMVolume = 0.2f, SEVolume = 0.2f;
}
public class EndlessScoreVer2 : MonoBehaviour
{
    public Text E1stScoreText, E2ndScoreText, E3rdScoreText, TotalExpText, 
        StoryText, EndlessText, CheckmateText;
    public Info1 info;
    public Slider BGMValue, SEValue;
    public AudioSource SEASource;
    public GameObject StoryNullBObj, EndlessNullBObj, CheckmateNullBObj, 
        Epi2BObj, Epi3BObj, Epi4BObj, Epi5BObj, Epi6BObj, Epi7BObj, Epi8BObj, Epi9BObj;
    public Collider2D Epi2Col, Epi3Col, Epi4Col, Epi5Col, Epi6Col, Epi7Col, Epi8Col, Epi9Col, 
        Epi2UnTagCol, Epi3UnTagCol, Epi4UnTagCol, Epi5UnTagCol, Epi6UnTagCol, Epi7UnTagCol, Epi8UnTagCol, Epi9UnTagCol;
    public Image Epi2BImage, Epi3BImage, Epi4BImage, Epi5BImage, Epi6BImage, Epi7BImage, Epi8BImage, Epi9BImage;
    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        E1stScoreText.text = "  st :" + info.EScore1st;
        E2ndScoreText.text = "  nd :" + info.EScore2nd;
        E3rdScoreText.text = "  rd :" + info.EScore3rd;
        TotalExpText.text = "  Total Exp :" + info.TotalExp;
        BGMValue.value = info.BGMVolume;
        SEValue.value = info.SEVolume;
        if(info.StoryFlag != "On")
        {
            StoryText.color = new Color32(30, 230, 230, 80);
            StoryNullBObj.SetActive(true);
        }
        else if (info.StoryFlag == "On")
        {
            StoryText.color = new Color32(30, 230, 230, 255);
            StoryNullBObj.SetActive(false);
        }
        if (info.EndlessFlag != "On")
        {
            EndlessText.color = new Color32(30, 230, 230, 80);
            EndlessNullBObj.SetActive(true);
        }
        else if (info.EndlessFlag == "On")
        {
            EndlessText.color = new Color32(30, 230, 230, 255);
            EndlessNullBObj.SetActive(false);
        }
        if (info.CheckmateFlag != "On")
        {
            CheckmateText.color = new Color32(30, 230, 230, 80);
            CheckmateNullBObj.SetActive(true);
        }
        else if (info.CheckmateFlag == "On")
        {
            CheckmateText.color = new Color32(30, 230, 230, 255);
            CheckmateNullBObj.SetActive(false);
        }
        if (info.Epi2Flag != "On")
        {
            Epi2BImage.color = new Color32(45, 204, 255, 10);
            Epi2Col.enabled = false;
            Epi2UnTagCol.enabled = true;
            Epi2BObj.SetActive(false);
        }
        else if (info.Epi2Flag == "On")
        {
            Epi2BImage.color = new Color32(45, 204, 255, 255);
            Epi2Col.enabled = true;
            Epi2UnTagCol.enabled = false;
            Epi2BObj.SetActive(true);
        }
        if (info.Epi3Flag != "On")
        {
            Epi3BImage.color = new Color32(45, 204, 255, 10);
            Epi3Col.enabled = false;
            Epi3UnTagCol.enabled = true;
            Epi3BObj.SetActive(false);
        }
        else if (info.Epi3Flag == "On")
        {
            Epi3BImage.color = new Color32(45, 204, 255, 255);
            Epi3Col.enabled = true;
            Epi3UnTagCol.enabled = false;
            Epi3BObj.SetActive(true);
        }
        if (info.Epi4Flag != "On")
        {
            Epi4BImage.color = new Color32(45, 204, 255, 10);
            Epi4Col.enabled = false;
            Epi4UnTagCol.enabled = true;
            Epi4BObj.SetActive(false);
        }
        else if (info.Epi4Flag == "On")
        {
            Epi4BImage.color = new Color32(45, 204, 255, 255);
            Epi4Col.enabled = true;
            Epi4UnTagCol.enabled = false;
            Epi4BObj.SetActive(true);
        }
        if (info.Epi5Flag != "On")
        {
            Epi5BImage.color = new Color32(45, 204, 255, 10);
            Epi5Col.enabled = false;
            Epi5UnTagCol.enabled = true;
            Epi5BObj.SetActive(false);
        }
        else if (info.Epi5Flag == "On")
        {
            Epi5BImage.color = new Color32(45, 204, 255, 255);
            Epi5Col.enabled = true;
            Epi5UnTagCol.enabled = false;
            Epi5BObj.SetActive(true);
        }
        if (info.Epi6Flag != "On")
        {
            Epi6BImage.color = new Color32(45, 204, 255, 10);
            Epi6Col.enabled = false;
            Epi6UnTagCol.enabled = true;
            Epi6BObj.SetActive(false);
        }
        else if (info.Epi6Flag == "On")
        {
            Epi6BImage.color = new Color32(45, 204, 255, 255);
            Epi6Col.enabled = true;
            Epi6UnTagCol.enabled = false;
            Epi6BObj.SetActive(true);
        }
        if (info.Epi7Flag != "On")
        {
            Epi7BImage.color = new Color32(45, 204, 255, 10);
            Epi7Col.enabled = false;
            Epi7UnTagCol.enabled = true;
            Epi7BObj.SetActive(false);
        }
        else if (info.Epi7Flag == "On")
        {
            Epi7BImage.color = new Color32(45, 204, 255, 255);
            Epi7Col.enabled = true;
            Epi7UnTagCol.enabled = false;
            Epi7BObj.SetActive(true);
        }
        if (info.Epi8Flag != "On")
        {
            Epi8BImage.color = new Color32(45, 204, 255, 10);
            Epi8Col.enabled = false;
            Epi8UnTagCol.enabled = true;
            Epi8BObj.SetActive(false);
        }
        else if (info.Epi8Flag == "On")
        {
            Epi8BImage.color = new Color32(45, 204, 255, 255);
            Epi8Col.enabled = true;
            Epi8UnTagCol.enabled = false;
            Epi8BObj.SetActive(true);
        }
        if (info.Epi9Flag != "On")
        {
            Epi9BImage.color = new Color32(45, 204, 255, 10);
            Epi9Col.enabled = false;
            Epi9UnTagCol.enabled = true;
            Epi9BObj.SetActive(false);
        }
        else if (info.Epi9Flag == "On")
        {
            Epi9BImage.color = new Color32(45, 204, 255, 255);
            Epi9Col.enabled = true;
            Epi9UnTagCol.enabled = false;
            Epi9BObj.SetActive(true);
        }
    }
    public void BGMValueMethod()
    {
        info.BGMVolume = BGMValue.value;
    }
    public void SEValueMethod()
    {
        info.SEVolume = SEValue.value;
    }
    public void SaveMethod()
    {
        SEASource.volume = info.SEVolume;
        JsonData.Save(info, "scoreData");
    }
    public void DefaultVolume()
    {
        BGMValue.value = 0.2f;
        SEValue.value = 0.2f;
        info.BGMVolume = 0.2f;
        info.SEVolume = 0.2f;
    }
    public void RemoveAdsMethod()
    {
        info.RemoveAdsFlag = "On";
        JsonData.Save(info, "scoreData");
    }
}
