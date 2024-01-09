using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour 
{ 

     private Animator _Animator;

    public void TriggerType()
    {
        _Animator = GetComponent<Animator>();

    }

    public void BoolType()
    {

    }
}
