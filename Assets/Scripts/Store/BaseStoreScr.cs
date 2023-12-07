using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseStoreScr : MonoBehaviour
{
    private Tile hitTarget;
    private bool PlacerActive = false;
    private Basis TowerToSelect;

    private playerLevens _player;


    [SerializeField] private Basis TowerToPlace;
    [SerializeField] private Basis NewTowerToPlace;
    [SerializeField] private Basis[] TowerList;
    [SerializeField] private BaseUpgradeSystemSO _upgradeSystemSO;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<playerLevens>();
    }

    // Update is called once per frame
    RaycastHit hitData;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { onClick(); }
    }

    private void onClick()
    {
        
            hitTarget = GetTile();
            if (hitTarget != null && hitTarget.getBuildable() == true)
            {
            print("Pew");
            int TowerCost = TowerToPlace.getTowerCost();

                int PlayerGold = _player.getPlayerGold();
                if (TowerCost <= PlayerGold)
                {
                    Instantiate(TowerToPlace, hitTarget.transform.position + new Vector3(0, 0, 0), TowerToPlace.transform.rotation);
                    _player.setPlayerGold(TowerCost);
                    hitTarget.setBuildable(false);

                }
                else { print("You suck Stefan"); }
            }
            //Controleren of een Tile buildable is, zo niet, GetTower()
            else if (hitTarget != null && hitTarget.getBuildable() == false)
            {
                TowerToSelect = hitTarget.GetTower();
                TowerToSelect.setStats();
        }
    }
    protected Tile GetTile()
    {
        //v Van Stefan
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo) && hitInfo.transform.CompareTag("Tile"))
        {
            return hitInfo.transform.GetComponent<Tile>();
        }
        return null;
    }

    #region UI

    [SerializeField] private GameObject GameplayUI;
    private bool GaUIActive = true;
    [SerializeField] private GameObject StoreUI;
     private bool StUIActive = false;


    public void ToggleGameplayUI()
    {
        GaUIActive = !GaUIActive;
        GameplayUI.SetActive(GaUIActive);

    }

    public void ToggleStoreUI()
    {
        StUIActive = !StUIActive;
        StoreUI.SetActive(StUIActive);
        if (StUIActive == true) { Time.timeScale = 0; }
        if (StUIActive == false) { Time.timeScale = 1; }
    
    }
    #endregion

   public void SetTowerToPlace(int i)
    {
        TowerToPlace = TowerList[i];
        print(TowerToPlace);
    }
}