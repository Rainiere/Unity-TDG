using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Speed;
    [SerializeField] private int Damage;
    [SerializeField] private int Health;

    [SerializeField] private Enumies[] _enumies;

    private playerLevens _player;
    private Path _Path;
    private Waypoint _currentWaypoint;
    private Waypoint _WaypointEnd;
    private Spawner _spawner;

    public Enumies[] GetEnumies()
    {
        return _enumies;
    }

    void setupPath()
    {
        _Path = FindObjectOfType<Path>();
        _currentWaypoint = _Path.getFirst_Waypoint();
        transform.LookAt(_currentWaypoint.getPosition());
        _WaypointEnd = _Path.getLast_Waypoint();
    }
    // Start is called before the first frame update

    void Death()
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
        transform.Translate(Vector3.forward*Speed*Time.deltaTime);
        float distanceTo_Waypoint = Vector3.Distance(transform.position, _currentWaypoint.getPosition());
    
        if (distanceTo_Waypoint <= 1)
        {
            if(_currentWaypoint ==  _WaypointEnd)
            {
                Death();

                return;
            }
            _currentWaypoint = _Path.getNext_Waypoint(_currentWaypoint);
            transform.LookAt(_currentWaypoint.getPosition());
            
        }
    }
}
