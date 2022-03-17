using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationCol : MonoBehaviour
{
    public string flag = "Null";

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (flag == "PatternText")
        {
            if (trcol.gameObject.tag == "Pause")
            {
                //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                if (receivers != null)
                {
                    //すべてのMessageReceivedに"test"イベントを送信する
                    foreach (var receiver in receivers)
                    {
                        receiver.OnSendFungusMessage("PatternText");
                    }
                }
            }
        }
        if (flag == "PatternText2")
        {
            if (trcol.gameObject.tag == "Pause")
            {
                //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                if (receivers != null)
                {
                    //すべてのMessageReceivedに"test"イベントを送信する
                    foreach (var receiver in receivers)
                    {
                        receiver.OnSendFungusMessage("PatternText2");
                    }

                    Invoke("ThisDisableMethod", 0.1f);
                }
            }
        }
    }

    public void ThisDisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
