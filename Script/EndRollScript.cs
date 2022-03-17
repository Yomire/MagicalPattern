using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 30;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 730f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;
    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;
    public string Flag;
    // Update is called once per frame
    void Update()
    {
        if(Flag == "EndRoll")
        {
            //　エンドロールが終了した時
            if (isStopEndRoll)
            {
                endRollCoroutine = StartCoroutine(GoToNextScene());
            }
            else
            {
                //　エンドロール用テキストがリミットを越えるまで動かす
                if (transform.position.y <= limitPosition)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
                }
                else
                {
                    isStopEndRoll = true;
                }
            }
        }        
    }

    IEnumerator GoToNextScene()
    {
        //　n秒間待つ
        yield return new WaitForSeconds(2f);
        if(Flag == "EndRoll")
        {
            StopCoroutine(endRollCoroutine);
            FadeManager.Instance.LoadScene("Thanks", 1f);
            Flag = "Next";
        }        
        /*
        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endRollCoroutine);
            FadeManager.Instance.LoadScene("HomeVer3", 1f);
        }
        */
        yield return null;
    }

    public void EndRollMethod()
    {
        Flag = "EndRoll";
    }
}