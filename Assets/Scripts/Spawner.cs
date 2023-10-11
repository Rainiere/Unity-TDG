using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public struct waves {
    [SerializeField] public Transform[] enemyList;

};

public class Spawner : MonoBehaviour
{
    [SerializeField] public waves[] waveArray;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int waveCount = 0;
    private float waveTimer;
    private int deadEnemies;
    private bool startWave = true;
   
    private void Update()
    {
        if (startWave)
        {
            waveCount++;

            if(waveCount > waveArray.Length) { return; }
                StartCoroutine(spawnWave());
                waveTimer = timeBetweenWaves;
                deadEnemies = 0;
                startWave = false;
        }

        // End of wave, start next wave
        if (deadEnemies == waveArray[waveCount - 1].enemyList.Length) 
        {
            waveTimer -= Time.deltaTime;
            if(waveTimer <= 0) { startWave = true;}
        }
    }
    public void PingVanEnemy()
    {
        deadEnemies++;
    }
    IEnumerator spawnWave()
    {

        for (int i = 0; i < waveArray[waveCount - 1].enemyList.Length; i++)
        {
            spawnEnemy(i);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }

    void spawnEnemy(int i)
    {
        Instantiate(waveArray[waveCount - 1].enemyList[i], spawnPos.position, spawnPos.rotation);
    }
}
