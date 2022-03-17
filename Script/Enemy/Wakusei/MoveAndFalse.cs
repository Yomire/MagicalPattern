using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFalse : MonoBehaviour
{
    public float SpeedX = 0.0f, SpeedY = 0.0f;
    public Rigidbody2D rb;
    public HGHScript HS;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(SpeedX, SpeedY);
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "EnemyFalse")
        {
            this.gameObject.SetActive(false);
        }
        if (trcol.gameObject.tag == "HugeFalse")
        {
            if(HS != null)
            {
                HS.CloseAniMethod();
            }            
        }
    }
}
