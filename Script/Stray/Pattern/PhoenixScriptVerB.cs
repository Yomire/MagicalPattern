using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoenixScriptVerB : MonoBehaviour
{
    public float RotateZ = 1.0f;
    private Rigidbody2D rb;
    public GameObject player;
    public Vector2 prev;
    public float speed = 4;
    private Animator ani;
    public Image SPGage;
    public string flag = "On";
    public Text PatternName1, PatternName2, PatternName3;

    void OnEnable()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("EnableBool", true);
        ani.SetBool("DisableBool", false);
    }
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, RotateZ);
        //Move();
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
    public void CloseMethod()
    {
        ani.SetBool("EnableBool", false);
        ani.SetBool("DisableBool", true);
    }
    public void CloseStart()
    {
        if (SPGage.fillAmount <= 0)
        {
            CloseMethod();
            Invoke("DisableMethod", 3.0f);
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
        if (PatternName3.text == "◇フェニックス")
        {
            PatternName3.text = "";
        }
        if (PatternName2.text == "◇フェニックス")
        {
            PatternName2.text = "";
        }
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
}
