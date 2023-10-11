using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basis : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private int Range;
    private LayerMask _layer;
    private Enumies[] _targetConditions;

    private void Start()
    {
        _layer = LayerMask.GetMask("Enemy");
    }

    private Enemy targetFirstEnemy()
    {
        Collider[] enemiesWithinRange = Physics.OverlapSphere(transform.position, Range, _layer);
        for (int i = 0; i < enemiesWithinRange.Length; i++)
        {
            for (int j = 0; j < enemiesWithinRange[i].GetComponent<Enemy>().GetEnumies().Length; j++)
            {
                if (enemiesWithinRange[i].GetComponent<Enemy>._enumies[j] == _targetConditions);
            }

        } return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
