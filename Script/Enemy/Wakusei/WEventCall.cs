using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEventCall : MonoBehaviour
{
    public WakuseiScript WS;

    // Start is called before the first frame update
    public void EventMethod()
    {
        WS.WAniEventMethod();
    }
    public void EventMethod2()
    {
        WS.WAniRandomMethod();
    }

    public void BurnMethod()
    {
        WS.BurnMethod();
    }
}
