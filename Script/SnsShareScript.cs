using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine;
using NatSuite.Sharing;

public class SnsShareScript : MonoBehaviour
{
    public Camera ArCam;
    public string fileName;
    public int SampleScore = 12345;
    public ScoreManager ScoreS;
    /*
    void Start()
    {
        PNGDelete();
    }
    */
    public void CaptchaScreen()
    {
        //Debug.Log("Snapshot");
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(screenShot.width, screenShot.height, 24);
        RenderTexture prev = ArCam.targetTexture;
        ArCam.targetTexture = rt;
        ArCam.Render();
        ArCam.targetTexture = prev;
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        UnityEngine.Object.Destroy(screenShot);

        fileName = "cap_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";

        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName, bytes);
        Invoke("ShareMethod", 0.1f);

        SampleScore = ScoreS.score;
    }
    public void PNGDelete()
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            File.Delete(Application.persistentDataPath + "/" + fileName);
        }
    }
    public void ShareMethod()
    {
        //  SNSへのシェア
        var payload = new SharePayload();
        payload.AddText("今日のスコア\nScore:" + SampleScore + "\n#MagicalPattern #gameapp #indiegame");
        payload.AddMedia(Application.persistentDataPath + "/" + fileName);
        var success = payload.Commit();
        Invoke("PNGDelete", 1f);
    }
}
