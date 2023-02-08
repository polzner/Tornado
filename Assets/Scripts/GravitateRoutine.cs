using System;
using UnityEngine;

[Serializable]
public class GravitateRoutine
{
    public GameObject GravitatingObject;
    public Coroutine Routine { get; private set; }

    public GravitateRoutine(GameObject gravitatingObject, Coroutine gravitatingRoutine)
    {
        GravitatingObject = gravitatingObject;
        Routine = gravitatingRoutine;
    }
}