using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;



public class T1Stower : Basis
// als dit niet werkt private wordt protected
{
    [SerializeField] private STowerSO[] STowerLevels;

    
    //Private  betekent dat het niet aangepast kan worden vanuit andere scripts
    //(Maar nog wel aangepast kan worden in Unity als je SerializeField er voor hebt)
    // bool staat voor Boolean, een variabele die alleen true of false kan zijn
    // StartWave is de naam van de variabel die wij willen gebruiken.
    private bool StartWave = false;

    //Float staat voor getallen die een comma waarden kunnen hebben, zoals 1.5, 3.14, waarbij int(integer) alleen hele getallen kunnen zijn, zoals 1, 3.
    private float PersonalFireRate = 0.1f;


    // Update is called once per frame
    // Update wordt automatisc elke frame uitgevoerd.
    void Update()
    {
        //Enemy hier staat voor een GameAsset die wij willen returnen.
        // TargetFirstEnemy is een functie
        Enemy EnemyToTarget = TargetFirstEnemy();
        //!= betekent niet gelijk aan, waarbij null een nul-waarden is, oftewel niets.
        // If statement kijkt of er bepaalden voorwaarden worden voldaan voordat de functie uitgevoerd wordt.
        if (EnemyToTarget != null)
        {
            if (canFire) { DoDamage(EnemyToTarget);
                canFire = false;
                PersonalFireRate = FireRate;
            }
        }
        // > betekent groter dan
        if (PersonalFireRate > 0)
        {
            // -= trekt af, Time.deltaTime is het tijdverstrek.
            PersonalFireRate -= Time.deltaTime;
        }
        if (PersonalFireRate <= 0)
        {
            canFire = true;
        }
    }
    // Void betekent dat het niets returnt, maar iets uitvoert.
    public void DoDamage(Enemy enemy)
    {
       enemy.TakeDamage(Damage);
    }
    public override void setStats()
    {
     if(UpgradeLevel >= STowerLevels.Length)
        {
            print("Unable to upgrade, placeholder");
            return;
        }
        BaseStats(STowerLevels[UpgradeLevel]);
    }
}
