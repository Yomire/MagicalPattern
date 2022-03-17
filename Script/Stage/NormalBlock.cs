using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ScrollSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * ScrollSpeed;
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            /*GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);
            */

            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);

            this.gameObject.SetActive(false);
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            /*GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);*/

            this.gameObject.SetActive(false);
        }
    }
}
