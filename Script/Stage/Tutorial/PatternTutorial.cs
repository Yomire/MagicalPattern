using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class PatternTutorial : MonoBehaviour
{
    public GameObject FingerObj, ASObj;
    public string Flag;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(Flag == "Block2")
        {
            if (FingerObj.activeSelf)
            {
                if (collider.gameObject.tag == "PatternOn")
                {
                    //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                    MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                    //取得できた場合
                    if (receivers != null)
                    {
                        //すべてのMessageReceivedに"test"イベントを送信する
                        foreach (var receiver in receivers)
                        {
                            receiver.OnSendFungusMessage("Block2");
                            FingerObj.SetActive(false);
                        }
                    }
                }
            }
        }
        if (Flag == "Block3")
        {
            if (collider.gameObject.tag == "TutorialPattern")
            {
                //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                //取得できた場合
                if (receivers != null)
                {
                    //すべてのMessageReceivedに"test"イベントを送信する
                    foreach (var receiver in receivers)
                    {
                        ASObj.SetActive(true);
                        receiver.OnSendFungusMessage("Block3");
                        Invoke("DisableMethod", 0.1f);
                    }
                }
            }
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
    public void ASDisable()
    {
        ASObj.SetActive(false);
    }
}
