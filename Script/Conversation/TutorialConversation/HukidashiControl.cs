using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HukidashiControl : MonoBehaviour
{
    public string flag = "Null";
    public GameObject HukidashiUp, HukidashiDown, EnemyObj, EnemyObj2, EnemyObj3;
    
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Player")
        {
            if(flag == "Up")
            {
                HukidashiUp.SetActive(true);
                HukidashiDown.SetActive(false);
            }
            if (flag == "Down")
            {
                HukidashiUp.SetActive(false);
                HukidashiDown.SetActive(true);
            }
            if (flag == "Null")
            {
                HukidashiUp.SetActive(false);
                HukidashiDown.SetActive(false);
            }
            if (flag == "Conversation1")
            {
                HukidashiUp.SetActive(false);
                HukidashiDown.SetActive(false);
                EnemyObj.SetActive(true);
                EnemyObj2.SetActive(true);
                EnemyObj3.SetActive(true);

                //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                if (receivers != null)
                {
                    //すべてのMessageReceivedに"test"イベントを送信する
                    foreach (var receiver in receivers)
                    {
                        receiver.OnSendFungusMessage("test");
                    }
                }
            }
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            this.gameObject.SetActive(false);
        }
    }
}
