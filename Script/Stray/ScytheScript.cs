using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheScript : MonoBehaviour
{
    public float SpeedX = 10f, RotateZ = 1.0f, speed = 2;
    private Rigidbody2D rb;
    public string flag = "Plus";
    public GameObject player;
    public Vector2 prev;

    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.Find("PlayerObject");
        flag = "Plus";
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, RotateZ);
        if (flag == "Plus")
        {
            rb.velocity = new Vector2(SpeedX, 0);
            Invoke("FlagMinus", 0.5f);
        }
        /*if (rb.velocity.x >= LimitNumber)
        {
            flag = "Minus";            
        }*/
        if (flag == "Minus")
        {
            Move();
        }
    }

    public void FlagMinus()
    {
        flag = "Minus";
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        //Debug.Log("testB");
        if (trcol.gameObject.tag == "Player")
        {
            //Debug.Log("testB");
            Disable();
        }
    }
    void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj16 = ObjectPooler16.current.GetPooledObject();
        if (obj16 == null) return;
        obj16.SetActive(true);
        obj16.transform.position = this.transform.position;

    }
    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
    private void OnDisable()
    {
        CancelInvoke();
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
}
