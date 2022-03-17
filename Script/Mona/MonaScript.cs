using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonaScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player, MonaObj, SphereObj;
    public Vector2 prev;
    public float speed = 4;
    private Animator ani;
    public ParticleSystem EnableSphirePar, SphirePar;
    public string flag = "On";
    void OnEnable()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("StopBool", false);
        //ani.SetBool("DisableBool", false);
    }
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }
    public void SphireStop()
    {
        ani.SetBool("StopBool", true);
    }
    public void MonaEnable()
    {
        EnableSphirePar.Play();
        SphirePar.Stop();
        //MonaObj.SetActive(true);
        ani.SetBool("StopBool", false);
        ani.Play("MonaIdle", 0, 0.0f);
    }
    public void SphireMode()
    {
        SphirePar.Play();
        ani.SetBool("StopBool", false);
        ani.Play("MonaIdle", 0, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(0.0f, 0.0f, RotateZ);

        if (flag == "Off")
        {
            rb.velocity = Vector3.zero;
        }
        if (flag == "On")
        {
            Move();
        }
    }
    void Move()
    {
        //ユーザの場所を特定
        Vector2 Predetor = player.transform.position;

        float x = Predetor.x;
        float y = Predetor.y;
        //追跡方向の決定
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        //ターゲット方向に力を加える
        rb.velocity = (direction * speed);
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Player")
        {
            flag = "Off";
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Player")
        {
            flag = "On";
        }
    }
    public void FlagOff()
    {
        flag = "Off";
    }
    public void FlagOn()
    {
        flag = "On";
    }
    public void AnimPauseMethod()
    {
        if(SphereObj != null)
        {
            ani.enabled = false;
            flag = "Off";
        }
    }
    public void AnimResumeMethod()
    {
        if (SphereObj != null)
        {
            ani.enabled = true;
            flag = "On";
        }
    }
}
