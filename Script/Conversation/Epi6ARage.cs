using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Epi6ARage : MonoBehaviour
{
    public SceneControl SCS;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            ScreenShakeController.instance.StartShake(.1f, .1f);
        }
    }
    public void NextSceneMethod()
    {
        SCS.Epi6After();
    }
}
