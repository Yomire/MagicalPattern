using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class DisableCounter : MonoBehaviour
{
    public float DCount = 0;
    
    public void CountMethod()
    {
        DCount += 1;
        if(DCount == 3)
        {
            //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
            MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
            if (receivers != null)
            {
                //すべてのMessageReceivedに"test"イベントを送信する
                foreach (var receiver in receivers)
                {
                    receiver.OnSendFungusMessage("Text2");
                }
            }
        }
        if (DCount == 6)
        {
            //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
            MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
            if (receivers != null)
            {
                //すべてのMessageReceivedに"test"イベントを送信する
                foreach (var receiver in receivers)
                {
                    receiver.OnSendFungusMessage("Text3");
                }
            }
        }
    }

    public void SceneNextMethodB()
    {
        FadeManager.Instance.LoadScene("HomeVer2", 0.5f);
    }
}
