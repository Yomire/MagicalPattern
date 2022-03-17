using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEventScript : MonoBehaviour
{
    public EndlessStage ES;

    public void CountEvent()
    {
        ES.CountMethod();
    }
    public void LevelCountEvent()
    {
        ES.LevelCountMethod();
    }
    public void LevelChoiceEvent()
    {
        ES.LevelChoiceMethod();
    }
    public void ReChoiceEvent()
    {
        ES.ReChoiceMethod();
    }
}
