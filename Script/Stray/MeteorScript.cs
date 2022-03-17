using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float Speed = 1.0f;
    public float DisableTime = 5.0f;
    private Rigidbody2D rb;
    public GameObject BombPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * Speed;
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Joint")
        {
            MeteorDisablePar();
            this.gameObject.SetActive(false);
        }
    }
    public void MeteorDisablePar()
    {
        GameObject obj = ObjectPooler38.current.GetPooledObject();
        if (obj == null) return;
        //obj.transform.parent = ArrowPos.gameObject.transform;
        obj.transform.position = BombPos.transform.position;
        //obj.transform.rotation = ArrowPos.transform.rotation;
        obj.SetActive(true);
    }
}
