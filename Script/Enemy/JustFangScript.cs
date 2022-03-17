using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class JustFangScript : MonoBehaviour
{
    public apPortrait JFApPortrait;
    public Collider2D FangCol;
    public float Disabletime = 1.0f;
    public float nowPosi;

    /*void OnAsyncPortraitIntialized(apPortrait portrait)
    {
        Debug.Log("Async");
        JFApPortrait.Play("JustFangEnable", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }*/

    private void OnEnable()
    {
        // すぐに初期化をするためにInitialize関数を呼び出して、Moveアニメーションを再生
        JFApPortrait.Initialize();
        Invoke("Disable", Disabletime);
        FangCol.enabled = false;
        JFApPortrait.Play("JustFangEnable", 1);
    }

    void Start()
    {
        nowPosi = this.transform.position.z;
        //JFApPortrait.Play("JustFangEnable", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, false);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, nowPosi + Mathf.PingPong(Time.time / -3, 0.3f));
        //JFApPortrait.Play("JustFangEnable", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }

    /*public void FalseFx()
    {
        //Debug.Log("false");
        gameObject.SetActive(false);
    }*/

    public void ColFx()
    {
        //Debug.Log("Col");
        FangCol.enabled = true;
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        JFApPortrait.StopLayer(1);
        CancelInvoke();
    }
}
