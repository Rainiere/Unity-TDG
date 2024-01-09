using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ProjectilePool : MonoBehaviour
{
    private List<ProjectileBase> ProjectileList;

    //Functie die ontzichtbare projectiles spawnt om te gebruiken als de Tower een projectile afvuurt
    public void AddProjectile(ProjectileBase _projectile, int amount) 
    {
        ProjectileList = new List<ProjectileBase>();  
        for (int i = 0; i < amount; i++) {
            ProjectileBase projectile = Instantiate(_projectile);
            projectile.GameObject().SetActive(false);
            ProjectileList.Add(projectile);
            projectile.transform.parent = transform;
        }
    }
    
    // Functie die de projectile teruggeeft aan de Tower waar die vandaan kwam
    public ProjectileBase GetProjectile()
    {

        return null;
    } 

}
