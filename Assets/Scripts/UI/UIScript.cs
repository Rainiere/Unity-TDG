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
        GameplayUI.SetActive(GaUIActive);
        GaUIActive = !GaUIActive;
    }

    public void ToggleStoreUI()
    {
        StoreUI.SetActive(StUIActive);
        StUIActive = !StUIActive;
        Time.timeScale = 1;
    }
}
