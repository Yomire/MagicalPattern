using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Fungus;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    //public static TutorialManager instance;
    public Info1 info;
    //public int DisableCount, Count;
    public AudioSource BGMASours;
    public float span = 3f;
    public GameObject MonaHintUp, MonaHintDown, ObstacleBottom, ObstacleUpper, EnemyObj1, EnemyObj2, EnemyObj3, EnemyObj4, EnemyObj5, EnemyObj6, 
        TouchBarrierObj, FingerObj, StopColObj;
    public string Flag;
    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        BGMASours.volume = info.BGMVolume;
        Flag = "Start";
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(span);
            //Debug.LogFormat("{0}秒経過", span);
            if(Flag == "Start")
            {
                MonaHintUp.SetActive(true);
                ObstacleBottom.SetActive(true);
                Invoke("DownHintFlag", 0.1f);
            }
            if(Flag == "DownHint")
            {
                if(ObstacleBottom.activeSelf == false)
                {
                    MonaHintUp.SetActive(false);
                    MonaHintDown.SetActive(true);
                    ObstacleUpper.SetActive(true);
                    Invoke("ConversationFlag", 0.1f);
                }
            }
            if (Flag == "Conversation")
            {
                if (ObstacleUpper.activeSelf == false)
                {                    
                    //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                    MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                    //取得できた場合
                    if (receivers != null)
                    {
                        //すべてのMessageReceivedに"test"イベントを送信する
                        foreach (var receiver in receivers)
                        {
                            receiver.OnSendFungusMessage("Block1");
                            MonaHintDown.SetActive(false);
                            EnemyObj1.SetActive(true);
                            EnemyObj2.SetActive(true);
                            EnemyObj3.SetActive(true);
                            Invoke("ConversationFlag2", 0.1f);
                        }
                    }
                }
            }
            if (Flag == "Conversation2")
            {
                if (EnemyObj1.activeSelf == false && EnemyObj2.activeSelf == false && EnemyObj3.activeSelf == false && EnemyObj4.activeSelf == false && EnemyObj5.activeSelf == false && EnemyObj6.activeSelf == false)
                {
                    //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                    MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                    //取得できた場合
                    if (receivers != null)
                    {
                        //すべてのMessageReceivedに"test"イベントを送信する
                        foreach (var receiver in receivers)
                        {
                            receiver.OnSendFungusMessage("Block4");
                            Flag = "Conversation3";
                        }
                    }
                }
            }
        }
    }
    public void DownHintFlag()
    {
        Flag = "DownHint";
    }
    public void ConversationFlag()
    {
        Flag = "Conversation";
    }
    public void ConversationFlag2()
    {
        Flag = "Conversation2";
    }
    public void FingerActive()
    {
        FingerObj.SetActive(true);
        TouchBarrierObj.SetActive(false);
    }
    public void SceneEnd()
    {
        FadeManager.Instance.LoadScene("TutorialConversation2", 0.5f);
    }
    public void StopColDisable()
    {
        StopColObj.SetActive(false);
    }
}
