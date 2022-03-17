using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingCutterScript : MonoBehaviour
{
    public float RotateZ = 1.0f;
    private Rigidbody2D rb;
    public GameObject player;
    public Vector2 prev;
    public float speed = 4;
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, RotateZ);
        Move();
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
