using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public Vector3 getPosition()
    {
        return transform.position + new Vector3(0,1,0);
    }
}
