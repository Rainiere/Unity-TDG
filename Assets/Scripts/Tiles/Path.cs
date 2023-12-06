using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //Array van alle Waypoint tiles in de game.
    [SerializeField] private Waypoint[] _Waypoints;
    // Variabelen van de eerste Waypoint tile, de laatste, en degene waar de enemy naar toe gaat.
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
}
