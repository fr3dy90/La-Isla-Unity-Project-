using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*
    1) Detectar el boton para disparar
    2) Crear un prefab para la municion
    3) Dar posicion y rotacion adecuadas
    4) Dar impulso
      */

    public GameObject pref_bullet;
    public Transform spawnPoint;
    public float force;



    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();    
        }
    }

    void Shoot()
    {
        GameObject go = Instantiate(pref_bullet, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(go.transform.forward * force, ForceMode.Impulse);
    }
}
