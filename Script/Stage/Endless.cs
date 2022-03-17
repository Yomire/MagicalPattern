using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField] private float speed;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0);
        if (transform.position.x <= -8.99f)
        {
            transform.position = new Vector3(0, 0);
        }
    }
}
