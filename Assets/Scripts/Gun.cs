using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject pref_Bullet;
    public Transform spawnPoint;
    public float force;
    public int magazineMax = 5;
    float actualMagazine;

    private void Start()
    {
        actualMagazine = magazineMax;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && actualMagazine > 0)
        {
            GameObject go = Instantiate(pref_Bullet, spawnPoint.position, spawnPoint.rotation);
            go.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * force, ForceMode.Impulse);
            Destroy(go, 2f);
            actualMagazine--;
        }

        

        void Reload()
        {
            actualMagazine = magazineMax;
        }
    }
}
