using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler22 : MonoBehaviour
{
    public static ObjectPooler22 current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;

    public List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
