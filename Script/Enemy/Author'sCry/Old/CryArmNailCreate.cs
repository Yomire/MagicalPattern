using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryArmNailCreate : MonoBehaviour
{
    public GameObject StartPos;
    private Rigidbody2D rb;
    public float Speed = 0.01f, EndPos_X, EndPos_XB;

    void OnEnable()
    {
        this.transform.position = StartPos.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x += Speed;    // x座標へ0.01加算
        //pos.y += 0.01f;    // y座標へ0.01加算
        //pos.z += 0.01f;    // z座標へ0.01加算

        myTransform.position = pos;  // 座標を設定
        /*if (rb != null)
        {
            rb.velocity = Vector2.right * Speed;
        }*/
        if (this.transform.localPosition.x >= EndPos_X)
        {
            Disable();
        }
        if (this.transform.localPosition.x <= EndPos_XB)
        {
            Disable();
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
