using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject MonaObj;
    public TutorialEnemyB EnemyScript;

    public void MonaActive()
    {
        MonaObj.SetActive(true);
    }

    /*public void TutorialSceneNext()
    {
        EnemyScript.FlagMethod();
        Invoke("SceneNextMethod", 1.0f);
    }*/
    public void SceneNextMethod()
    {
        FadeManager.Instance.LoadScene("TutorialStageVer2", 0.5f);
    }
    public void SceneNextMethod2()
    {
        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
    }
}
