using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolBlock : MonoBehaviour
{
    //private Rigidbody2D rb;
    public float ScrollSpeed = 0.1f;
    public GameObject LCObj;
    public string PauseFlag;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        LCObj = GameObject.Find("LevelControl");
    }
    void Update()
    {
        if(PauseFlag == "Off")
        {
            this.transform.Translate(ScrollSpeed, 0, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "JointRelease" || trcol.gameObject.tag == "AttackSPB")
        {
            if(LCObj != null)
            {
                LevelGenerateScript.instance.DisableCountMethod();
            }            
            Invoke("DisableMethod", 0.01f);
        }
        if (trcol.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
        }
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
