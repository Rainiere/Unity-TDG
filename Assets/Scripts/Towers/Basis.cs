using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Basis : MonoBehaviour
{
    [SerializeField] protected int UpgradeLevel;
    [SerializeField] protected int Damage;
    [SerializeField] protected float FireRate;
    [SerializeField] protected int Range;
    [SerializeField] protected bool Camouflage;
    [SerializeField] protected int GoldValue;

    [SerializeField] private GameObject _AnimatorHolder;
    protected Animator _Animator;

    // LayerMask is een uniek iets uit Unity, waarbij je de Layers kunt aanroepen.
    protected LayerMask _layer;

    //Enumies is een enum(Alleen data, geen functies) bestand die wij hier aanroepen zodat die gebruikt kan worden
    // Het is gebruikelijk om een "Local variable" te beginnen met _, een local variable is een variabele die je aanmaakt om een variabele die in een ander
    // script aangemaakt wordt te kunnen gebruiken.
    private Enumies _targetConditions = Enumies.All;
    protected bool canFire = false;

    // Start wordt uitgevoerd zodra het script is geladen, voordat de eerste frame begint.
    void Start()
    {
        _layer = LayerMask.GetMask("Enemy");
        setStats();
        _Animator = _AnimatorHolder.GetComponent<Animator>();
    }

    void Update()
    {
        Enemy enemy = TargetFirstEnemy();
    }

    // [] Staat voor een array, een lijst variabele waar je meerdere dingen op kunt slaan, zoals een object(Variabele met meerdere variabelen daarin), string(tekst)
    // of getallen.
    private Enemy[] TargetAllEnemy()
    {
        //Collider is uniek vanuit Unity, dat naar collisions(botsingen) zoekt.
        Collider[] colls = Physics.OverlapSphere(transform.position, Range, _layer);
        List<Enemy> enemies = new List<Enemy>();

        if (colls.Length <= 0)
        {
            return enemies.ToArray();
        }


        //ForEach loopt door elke "hit" in de collider.
        foreach (Collider coll in colls)
        {
            Enemy enemy = coll.GetComponent<Enemy>();
            // || betkent "of", && betekent "en", == betekent "is gelijk aan?"
            if ((enemy.GetCamo() == false || Camouflage == true) && (enemy.GetEnumies() == _targetConditions || _targetConditions == Enumies.All))
            {
                 enemies.Add(enemy); 
            }
        }
        return enemies.ToArray();
    }

    // Protected is vergelijkbaar met private, maar met de extensie dat als iets afgeleid is van hetzelfde script dat je het nog wel kan aanpassen.
    protected Enemy TargetFirstEnemy() {
        Enemy[] enemies = TargetAllEnemy();
        if (enemies.Length == 1) { return enemies[0]; }
        // Vector2 gaat over coordinaten op de X en Y as, waarbij vector3 ook nog de Z as pakt.
        Vector2 currentFurthestEnemy = new(-1, Mathf.Infinity);
        Enemy enemyToTarget = null;

        foreach (Enemy enemy in enemies) {
            Vector2 currentEnemy = enemy.getDistance();
            if (currentEnemy.x > currentFurthestEnemy.x || (currentEnemy.x == currentFurthestEnemy.x && currentEnemy.y < currentFurthestEnemy.y))
            {
                currentFurthestEnemy = currentEnemy;
                enemyToTarget = enemy;
            }
        }
            return enemyToTarget;
    }

    public int getTowerCost()
    {
        return GoldValue;
    }

    protected void BaseStats(BaseUpgradeSystemSO Base)
    {
        Damage = Base.Damage;
        FireRate = Base.FireRate;
        Range = Base.Range;
        Camouflage = Base.Camouflage;
        GoldValue = Base.GoldValue;
        UpgradeLevel++;
    }

    public virtual void setStats()
    {

    }

    public Animator GetAnimator()
    {
        return _Animator;
    }
    // OnDrawGizmos() is een Unity functie om een visuele indicatie van de hiervoorgenoemde collider te krijgen.
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
