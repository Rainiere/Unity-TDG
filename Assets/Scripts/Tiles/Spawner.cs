using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
// Array van alle Waves in de TDG, met binnen in de Array een Array van elke enemy die in een Wave voorkomt.
public struct waves {
    [SerializeField] public Enemy[] enemyList;

};

public class Spawner : MonoBehaviour
{
    //Variabelen over alle Waves, de startpositie van de enemy, hoe lang het duurt voordat een Enemy spawnt nadat een enemy is gespawnt, en 
    // hoe lang het duurt voordat de volgende Wave start.
    //Laatste om bij te houden welke Wave het is, en om de Wave text in de UI aan te passen.
    [SerializeField] public waves[] waveArray;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int waveCount = 0;
    [SerializeField] TMP_Text Wave;
    [SerializeField] private GameObject StartWaveButton;
    // Variabelen om bij te houden hoeveel enemies er dood zijn en of de volgende wave gestart mag worden.
    private float waveTimer;
    private int deadEnemies;
    private bool startWave = false;
   //update functie om de waveCount omhoog te gooien, en dan de wave te beginnen.
    private void Update()
    {
        CheckEndOfWave();
    }

    public void BeginWave()
    {
        waveCount++;

        if (waveCount > waveArray.Length) { return; }
        StartCoroutine(spawnWave());
        deadEnemies = 0;
        StartWaveButton.SetActive(false);
    }

    private void CheckEndOfWave()
    {
        if (waveCount > waveArray.Length) { return; }
        if (waveCount == 0) { return; }
        // If-functie dat de volgende wave start wanneer alle enemies dood zijn.
        if (deadEnemies == waveArray[waveCount - 1].enemyList.Length)
        {
            StartWaveButton.SetActive(true);
        }
        Wave.text = waveCount.ToString();
    }

    //Functie die de deadEnemies omhoog gooit als er een vijand doodgaat.
    public void PingVanEnemy()
    {
        deadEnemies++;
    }
    //IEnumerator functie om tijd bij te houden om de volgende wave te kunnen starten.
    IEnumerator spawnWave()
    {

        for (int i = 0; i < waveArray[waveCount - 1].enemyList.Length; i++)
        {
            spawnEnemy(i);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }

    //Functie die de enemy spawnt en op de goede plek neerzet.
    void spawnEnemy(int i)
    {
      Enemy  enemy = Instantiate(waveArray[waveCount - 1].enemyList[i], spawnPos.position, spawnPos.rotation);
        enemy.transform.parent = transform;
        
    }
}
