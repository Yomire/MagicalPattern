using UnityEngine;
using System.IO;

public class JsonData : MonoBehaviour
{
    public static void Save<T>(T o, string path)
    {
        string str = JsonUtility.ToJson(o);
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + "/" + path + ".json", false);
        streamWriter.Write(str);
        streamWriter.Flush();
        streamWriter.Close();

    }

    public static T Load<T>(string path)
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + path + ".json");
        string getone = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<T>(getone);
    }
}
