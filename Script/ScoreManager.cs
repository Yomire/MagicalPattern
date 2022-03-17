using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public int score = 0, GetExp, AddExp, GiveExp, TotalExpPoint;
    public Text scoreLabel, scoreLabel2, scoreLabel3, GetExpLabel, TotalExpLabel, scoreLabelSnap;
    public Info1 info;
    public string Flag;
    public AudioSource ScoreASource;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        Flag = "Null";
        AddExp = 0;
        scoreLabel.text = "SCORE：" + score;
        scoreLabelSnap.text = "SCORE：" + score;
        TotalExpPoint = info.TotalExp;
        TotalExpLabel.text = "Total Exp :" + info.TotalExp;
    }
    void FixedUpdate()
    {
        if(Flag == "GetExpFlag" && AddExp <= GetExp)
        {
            AddExp += 11;
            TotalExpPoint += 11;
            GiveExp -= 11;
            TotalExpLabel.text = "Total Exp :" + TotalExpPoint;            
            GetExpLabel.text = "Get Exp：" + GiveExp;
        }
        if(GiveExp <= 0)
        {
            if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
            {
                info = JsonData.Load<Info1>("scoreData");
            }
            ScoreASource.Stop();
            GiveExp = 0;
            Flag = "End";
            GetExpLabel.text = "Get Exp：" + 0;
            TotalExpLabel.text = "Total Exp :" + info.TotalExp;
        }
    }
    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE：" + score;
        scoreLabelSnap.text = "SCORE：" + score;
    }
    public void ResultMethod()
    {
        scoreLabel2.text = "SCORE：" + score;
        scoreLabel3.text = "SCORE：" + score;
        GetExpLabel.text = "Get Exp：" + score + "×2?";
        GetExp = score;
        GiveExp = score;
    }
    public void GetExpDouble()
    {
        //Debug.Log("Double");
        GetExp = GetExp * 2;
        //GetExpLabel.text = "Get Exp：" + GiveExp;
        //Invoke("ScoreSaveMethod", 0.1f);
        ScoreSaveMethod();
    }
    public void FlagChangeGetExp()
    {
        info.TotalExp = info.TotalExp + GetExp;
        GiveExp = GetExp;
        Flag = "GetExpFlag";
        ScoreASource.Play();
        Invoke("SaveMethod", 0.1f);
    }
    public void SaveMethod()
    {
        JsonData.Save(info, "scoreData");
        /*
        Debug.Log(info.EScore3rd);
        Debug.Log(info.EScore2nd);
        Debug.Log(info.EScore1st);
        */
    }
    public void ScoreSaveMethod()
    {
        //ResultMethod();
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");            
        }
        if (score >= info.EScore1st)
        {
            //Debug.Log("test");
            info.EScore3rd = info.EScore2nd;
            Invoke("ESRanking2ndSetMethodA", 0.01f);
            Invoke("ESRanking1stSetMethodA", 0.02f);
            Invoke("FlagChangeGetExp", 0.1f);
        }
        else if (score < info.EScore1st)
        {
            if (score >= info.EScore2nd)
            {
                //Debug.Log("test");
                info.EScore3rd = info.EScore2nd;
                Invoke("ESRanking2ndSetMethodB", 0.01f);
                Invoke("FlagChangeGetExp", 0.1f);
            }
            else if(score < info.EScore2nd)
            {
                if (score >= info.EScore3rd)
                {
                    //Debug.Log("test");
                    info.EScore3rd = score;
                    Invoke("FlagChangeGetExp", 0.1f);
                    //JsonData.Save(info, "scoreData");
                }
                else if (score < info.EScore3rd)
                {
                    //Debug.Log("test");
                    Invoke("FlagChangeGetExp", 0.1f);
                }
            }            
        }
    }
    public void ESRanking2ndSetMethodA()
    {
        info.EScore2nd = info.EScore1st;
    }
    public void ESRanking1stSetMethodA()
    {
        info.EScore1st = score;
        //JsonData.Save(info, "scoreData");
        //Invoke("SaveMethod", 0.1f);
    }
    public void ESRanking2ndSetMethodB()
    {
        info.EScore2nd = score;
        //JsonData.Save(info, "scoreData");
    }
    /*
    public void Save(SaveDataMagicalPattern saveData)
    {
#if UNITY_EDITOR
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

#elif UNITY_ANDROID
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.persistentDataPath + "/data/data/com.YOMIRE.MagicalPattern/files/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

#endif
    }
    public SaveDataMagicalPattern Load()
    {
#if UNITY_EDITOR
        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<SaveDataMagicalPattern>(datastr);
        }

        SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        return saveData;

#elif UNITY_ANDROID
        if (File.Exists(Application.persistentDataPath + "/data/data/com.YOMIRE.MagicalPattern/files/savedata.json"))
        {
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.persistentDataPath + "/data/data/com.YOMIRE.MagicalPattern/files/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<SaveDataMagicalPattern>(datastr);
        }

        SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        return saveData;

#endif
    }
    public void ScoreSaveMethod()
    {
        //Debug.Log("test");
        //SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        SaveDataMagicalPattern saveData = Load();
        if (score >= saveData.EndlessScore1st)
        {
            //Debug.Log("test2");
            saveData.EndlessScore3rd = saveData.EndlessScore2nd;
            Invoke("ESRankingSet2nd", 0.01f);
            Invoke("ESRankingSet1st", 0.02f);
            Save(saveData);
            //Debug.Log(saveData.EndlessScore1st);
        }
        else if (score <= saveData.EndlessScore1st)
        {
            if (score >= saveData.EndlessScore2nd)
            {
                saveData.EndlessScore3rd = saveData.EndlessScore2nd;
                Save(saveData);
                Invoke("ESRankingSet2ndB", 0.01f);
            }
            else if (score <= saveData.EndlessScore2nd)
            {
                if (score >= saveData.EndlessScore3rd)
                {
                    saveData.EndlessScore3rd = score;
                    Save(saveData);
                }
            }
        }
    }
    public void ESRankingSet2nd()
    {
        //SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        SaveDataMagicalPattern saveData = Load();
        saveData.EndlessScore2nd = saveData.EndlessScore1st;
        Save(saveData);
    }
    public void ESRankingSet1st()
    {
        //SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        SaveDataMagicalPattern saveData = Load();
        saveData.EndlessScore1st = score;
        Debug.Log(saveData.EndlessScore1st);
        Save(saveData);
    }
    public void ESRankingSet2ndB()
    {
        SaveDataMagicalPattern saveData = Load();
        //SaveDataMagicalPattern saveData = new SaveDataMagicalPattern();
        saveData.EndlessScore2nd = score;
        Save(saveData);
    }
    */
}
