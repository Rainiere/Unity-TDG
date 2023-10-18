using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class T1Stower : Basis
// als dit niet werkt private wordt protected
{
    // Update is called once per frame
    void Update()
    {
        Enemy EnemyToTarget = TargetFirstEnemy();
        if (EnemyToTarget != null)
        {
            if (canFire) { DoDamage(EnemyToTarget);
                canFire = false;
            }
            // Fire Rate met deltaTime aanpassen
            if(FireRate > 0)
            {
                FireRate -= Time.deltaTime;
            }
            FireRate-= Time.deltaTime
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0) { startWave = true; }
        }
    }

    public void DoDamage(Enemy enemy)
    {
       enemy.TakeDamage(Damage);
        // yield return new WaitForSeconds(FireRate);
    }

}
