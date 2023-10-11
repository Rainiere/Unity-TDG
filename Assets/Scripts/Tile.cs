using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // SerializeField linkt aan Unity
    // private/public bool
    [SerializeField] private bool buildable;
    public bool getBuildable()
    {
        return buildable;
    }
}