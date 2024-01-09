using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UIScript : MonoBehaviour
{
    //[SerializeField] private GameObject GameplayUI;
    //                         private bool GaUIActive = true;
    [SerializeField] private GameObject StoreUI;
                             private bool StUIActive = false;


    //public void ToggleGameplayUI()
    //{
    //    GameplayUI.SetActive(GaUIActive);
    //    GaUIActive = !GaUIActive;
    //}

    public void ToggleStoreUI()
    {
        StUIActive = !StUIActive;
        StoreUI.SetActive(StUIActive);
        
        Time.timeScale = StUIActive ? 0 : 1;
    }
}
