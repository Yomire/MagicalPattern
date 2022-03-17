using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Horizon = 0.1f;
    public float High = 0.1f;
    public float DestroyTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Horizon, -High);
    }
}
