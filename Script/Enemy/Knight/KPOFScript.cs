using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KPOFScript : MonoBehaviour
{
    public float StartPosX, StartPosY, ScrollSpeed = 7;
    public PlayableDirector POFPD;
    public Rigidbody2D rb;
    public string Flag;
    /*
    private void OnEnable()
    {
        this.transform.position = new Vector3(StartPosX, StartPosY, 0);
    }
    */
    void Update()
    {
        if(Flag == "Play")
        {
            //transform.Translate(-speed, 0, 0);
            rb.velocity = Vector2.left * ScrollSpeed;
        }
        if (this.transform.localPosition.x <= 0)
        {
            Flag = "Stop";
        }
    }
    public void FlagPlay()
    {
        Flag = "Play";
    }
}
