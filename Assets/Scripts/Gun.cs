using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float shootRate;
    float shootLastTime;

    public float range;
    public bool canShoot;

    public int maxBullets;
    public int actualBullets;

    public Transform gunFlash;
    public AudioClip shootSound;
    public AudioClip emptyShootSound;
    public AudioClip reloadSound;
    Transform myCamera;
    AudioSource gunSfx;

    private void Start()
    {
        actualBullets = maxBullets;
        shootLastTime = shootRate;
        gunSfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            if (shootLastTime >= shootRate)
            {
                shootLastTime = 0;
                Shoot();
            }
        }
        shootLastTime += Time.deltaTime;
    }

    public void SetCamera(Transform _camera)
    {
        myCamera = _camera;
    }

    public void Shoot()
    {
        if (myCamera != null)
        {
            if (actualBullets > 0)
            {
                actualBullets--;
                gunSfx.PlayOneShot(shootSound);

                if (Physics.Raycast(myCamera.position, myCamera.forward, out RaycastHit hit, shootRate))
                {
                    if (hit.transform != null)
                    {
                        //Colocar Particulas
                        //Colocar Decal
                        //Preguntar por interaccion
                    }
                }
            }
            else
            {
                gunSfx.PlayOneShot(emptyShootSound);
            }
        }
    }
}