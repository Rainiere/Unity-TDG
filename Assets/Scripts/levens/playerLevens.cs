using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerLevens : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerMaxHealth;

    [SerializeField] private int playerGold;
    [SerializeField] private int playerMaxGold = 9999;

    public void TakeDamage(int damage) {
        playerHealth -= damage;
        if(playerHealth <= 0) {
            gameOver();            
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
