using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject pref_Bullet;
    public Transform spawnPoint;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(pref_Bullet, spawnPoint.position, spawnPoint.rotation);                   
        }
    }

}
