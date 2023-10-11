using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    [SerializeField] private Waypoint[] _Waypoints;

    public Waypoint getFirst_Waypoint() { return _Waypoints[0]; }
    public Waypoint getLast_Waypoint() { return _Waypoints[_Waypoints.Length - 1]; }
    public Waypoint getNext_Waypoint(Waypoint current_Waypoint)
    {
        for (int i = 0; i < _Waypoints.Length; i++)
        {
            if (current_Waypoint == _Waypoints[i]) { return _Waypoints[i + 1]; }
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
