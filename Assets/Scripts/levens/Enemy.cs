using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Speed;
    [SerializeField] private int Damage;
    [SerializeField] private int Health;
    [SerializeField] private bool Camouflage;


    [SerializeField] private Enumies _enumies;

    private playerLevens _player;
    private Path _Path;
    private Waypoint _currentWaypoint;
    private Waypoint _WaypointEnd;
    private Spawner _spawner;

    private int Checkpoints;
    float distanceTo_Waypoint;

    public void SetSpeed(int _Speed)
    {
        Speed = _Speed;
    }

    public Enumies GetEnumies()
    {
        return _enumies;
    }

    public bool GetCamo()
    {
        return Camouflage;
    }

    public Vector2 getDistance()
    {
        return new Vector2(Checkpoints, distanceTo_Waypoint);
    }

    void setupPath()
    {
        _Path = FindObjectOfType<Path>();
        _currentWaypoint = _Path.getFirst_Waypoint();
        transform.LookAt(_currentWaypoint.getPosition());
        _WaypointEnd = _Path.getLast_Waypoint();
    }
    // Start is called before the first frame update
    public void TakeDamage(int damageToTake)
    {
        Health -= damageToTake;
        if(Health <= 0) { Death(); }
        
    }
    
    void Death()
    {
        Destroy(gameObject);
        _spawner.PingVanEnemy();
    }
    void FinishedPath()
    {
        Destroy(gameObject);
        _player.TakeDamage(Damage);
        _spawner.PingVanEnemy();
    }

    void Start()
    {
        setupPath();
        _player = FindObjectOfType<playerLevens>();

        _spawner = FindObjectOfType<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceTo_Waypoint = Vector3.Distance(transform.position, _currentWaypoint.getPosition());

        if (distanceTo_Waypoint <= 1)
        {
            if (_currentWaypoint == _WaypointEnd)
            {
                FinishedPath();

                return;
            }
            _currentWaypoint = _Path.getNext_Waypoint(_currentWaypoint);
            transform.LookAt(_currentWaypoint.getPosition());
            Checkpoints++;

        }
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}

//    public float[] DistanceToEnd()
//    {
//        float distanceTo_Waypoint = Vector3.Distance(transform.position, _currentWaypoint.getPosition());
///*        float[] fArray = new float[Checkpoints, distanceTo_Waypoint];*/
//        Array fArray = new Array[Checkpoints, distanceTo_Waypoint];

//        /*float[] float = new float[];*/

//    }
//}
