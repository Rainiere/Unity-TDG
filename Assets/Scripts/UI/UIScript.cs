using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject GameplayUI;
                             private bool GaUIActive = true;
    [SerializeField] private GameObject StoreUI;
                             private bool StUIActive = false;


    public void ToggleGameplayUI()
    {
        Time.timeScale = 0;
        print("Toggle Gameplay UI fired!");
        GameplayUI.SetActive(GaUIActive);
        GaUIActive = !GaUIActive;
    }

    public void ToggleStoreUI()
    {
        print("Toggle store UI fired!");
        StoreUI.SetActive(StUIActive);
        StUIActive = !StUIActive;
        Time.timeScale = 1;
    }
}
