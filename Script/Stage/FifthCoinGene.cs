using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthCoinGene : MonoBehaviour
{    
    public void CoinGene()
    {
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = this.gameObject.transform.position;
        obj.transform.rotation = this.gameObject.transform.rotation;
        obj.SetActive(true);
    }
}
