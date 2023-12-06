using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerLevens : MonoBehaviour
{
    //Variabelen van player stats
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerMaxHealth;

    [SerializeField] private int playerGold;
    [SerializeField] private int playerMaxGold = 9999;
    //Unity import voor de UI.
    [SerializeField] TMP_Text Health;
    [SerializeField] TMP_Text Gold;

    // Functie die de health van de player update.
    public void TakeDamage(int damage) {
        playerHealth -= damage;
        if(playerHealth <= 0) {
            gameOver();            
        }
    }
    //Functie die de gold van de player update.
    public void SetGold(int gold) { playerGold += gold; }
    // Functie die regelt wat er gebeurt als de player 0 HP heeft.
    void gameOver()
    {
        SceneManager.LoadScene(0);
    }
 

    // Update functie om de UI constant aan te passen.
    void Update()
    {
        //Health.text = playerHealth.ToString();
        //Gold.text = playerGold.ToString();
    }

    public int getPlayerGold()
    {
        return playerGold;
    }
    public void setPlayerGold(int TowerCost)
    {
        playerGold -= TowerCost;
    }
}
