using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Basis : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float FireRate;
    [SerializeField] protected int Range;
    [SerializeField] protected bool Camouflage;
    [SerializeField] protected LayerMask _layer;

    private Enumies _targetConditions;
    protected bool canFire = true;

    void Start()
    {
        _layer = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        Enemy enemy = TargetFirstEnemy();
        //if (enemy != null) { Debug.Log(enemy);}
    }
    private Enemy[] TargetAllEnemy()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, Range, _layer);
        List<Enemy> enemies = new List<Enemy>();


        if (colls.Length <= 0)
        {
            return enemies.ToArray();
        }



        foreach (Collider coll in colls)
        {
            Enemy enemy = coll.GetComponent<Enemy>();


            if ((enemy.GetCamo() == false || Camouflage == true) && (enemy.GetEnumies() == _targetConditions || _targetConditions == Enumies.All))
            {
                 enemies.Add(enemy); 
            }
        }
        return enemies.ToArray();
    }

    protected Enemy TargetFirstEnemy() {
        Enemy[] enemies = TargetAllEnemy();
        
        if (enemies.Length == 1) { return enemies[0]; }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
