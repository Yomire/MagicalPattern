using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TutorialEnemyB : MonoBehaviour
{
    public apPortrait TerrorApPortrait;
    public string flag = "Null";
    public float ScrollSpeed = 0.1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TerrorApPortrait.Initialize();
        TerrorApPortrait.Play("Idle", 1);
    }
    void Update()
    {
        if (flag == "scrol")
        {
            rb.velocity = Vector2.left * ScrollSpeed;
        }
    }
    public void FlagMethod()
    {
        flag = "scrol";
    }
}
