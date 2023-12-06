using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseUpgradeSystemSO : ScriptableObject
{
    [SerializeField] public int Damage;
    [SerializeField] public float FireRate;
    [SerializeField] public int Range;
    [SerializeField] public bool Camouflage;
    [SerializeField] public int GoldValue;

}
