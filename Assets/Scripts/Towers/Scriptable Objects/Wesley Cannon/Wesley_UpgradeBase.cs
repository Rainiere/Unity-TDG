using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wesley_UpgradeBase : ScriptableObject
{
    [SerializeField] public int Damage;
    [SerializeField] public float FireRate;
    [SerializeField] public int Range;
    [SerializeField] public int ExplosionRadius;
    [SerializeField] public bool Camouflage;
    [SerializeField] public int GoldValue;

}
