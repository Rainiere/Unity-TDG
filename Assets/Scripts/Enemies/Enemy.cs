using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{ // Variabelen voor de stats van de vijanden
    [SerializeField] private int Speed;
    [SerializeField] private int Damage;
    [SerializeField] private int Health;
    [SerializeField] private bool Camouflage;

    [SerializeField] private int GoldValue;

    //Lijst van de targeting attributes  om enemies aan te kunnen vallen.
    [SerializeField] private Enumies _enumies;
    // Importeren van de playerLevens, Path, Waypoint, Spawner scripts.
    private playerLevens _player;
    private Path _Path;
    private Waypoint _currentWaypoint;
    private Waypoint _WaypointEnd;
    private Spawner _spawner;
    //Variabelen om de eerste vijand te berekenen binnenin de targetting area van towers.
    private int Checkpoints;
    float distanceTo_Waypoint;
    //Functie om vijanden sneller/langzamer te maken
    public void SetSpeed(int _Speed)
    {
        Speed = _Speed;
    }
    //Om de targetting attributes van enemies aan te vragen.
    public Enumies GetEnumies()
    {
        return _enumies;
    }
    //Apparte functie om de Camouflage enum aan te vragen.
    public bool GetCamo()
    {
        return Camouflage;
    }

    //Functie om te berekenen
    public Vector2 getDistance()
    {
        return new Vector2(Checkpoints, distanceTo_Waypoint);
    }
    //Functie om vijanden te draaien.
    void setupPath()
    {
        _Path = FindObjectOfType<Path>();
        _currentWaypoint = _Path.getFirst_Waypoint();
        transform.LookAt(_currentWaypoint.getPosition());
        _WaypointEnd = _Path.getLast_Waypoint();
    }
    //Functie waarin de enemy damage ontvant, inclusief wat er gebeurt als de enemy op of onder 0 health komt.
    public void TakeDamage(int damageToTake)
    {
        Health -= damageToTake;
        if(Health <= 0) { Death(); }
        
    }
    
    // Functie dat regelt wat er gebeurt als de enemy op of onder 0 health zit.
    void Death()
    {
        _player.SetGold(GoldValue);
        Destroy(gameObject);
        _spawner.PingVanEnemy();
    }

    // Functie dat regelt wat er met de enemy gebeurt als ze bij het einde komen.
    void FinishedPath()
    {
        Destroy(gameObject);
        _player.TakeDamage(Damage);
        _spawner.PingVanEnemy();
    }

    // Start functie die de variabelen waardes geven.
    void Start()
    {
        setupPath();
        _player = FindObjectOfType<playerLevens>();

        _spawner = FindObjectOfType<Spawner>();

    }

    //Update functie die het bewegen van de enemies regelt.
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