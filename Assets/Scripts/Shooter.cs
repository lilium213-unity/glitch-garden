using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject projectileSpawner;

    //Animation Event
    void Attack()
    {
        Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity);
    }
}
