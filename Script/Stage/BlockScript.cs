using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Horizon = 5.0f;
    public float High = 0.0f;
    public float DestroyTime = 30.0f;
    public GameObject EffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Horizon, High, 0);
        //rb.velocity = new Vector2(Horizon, High);
    }

    private void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Block")
        {
            Destroy(trcol.gameObject);
            Destroy(this.gameObject);
            //rb.isKinematic = true;
            //Debug.Log("Touch");
            Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
