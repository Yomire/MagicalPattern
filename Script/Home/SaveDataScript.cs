using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveDataMagicalPattern
{
    public int EndlessScore1st, EndlessScore2nd, EndlessScore3rd;
}
public class SaveDataScript : MonoBehaviour
{
    void Start()
    {
        SaveDataMagicalPattern saveData = Load();
        Debug.Log(saveData.EndlessScore1st);
    }
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
        saveData.EndlessScore1st = 0;
        saveData.EndlessScore2nd = 0;
        saveData.EndlessScore3rd = 0;
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
}
