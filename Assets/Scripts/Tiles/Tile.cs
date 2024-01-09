using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;
//    private float sphereCastRadius = 2.0f;
        
    //Variabele om te declareren of er op een tile een toren neergezet mag worden of niet.
    [SerializeField] private bool buildable;
    //Functie om in een ander script aan te roepen of er op de Tile gebouwt mag worden of niet.
    public bool getBuildable()
    {
        return buildable;
    }

    public void setBuildable(bool boolus)
    {
        buildable = boolus;
    }

    public Basis GetTower()
    {
        //Raycast doet het niet, somehow, zoek uit hoe
        //Visualizeer de RayCast
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.magenta, 40f);
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitInfo) && hitInfo.transform.CompareTag("Tower"))
        {   
            return hitInfo.transform.GetComponent<Basis>();

        } else { return null; }
    }
}