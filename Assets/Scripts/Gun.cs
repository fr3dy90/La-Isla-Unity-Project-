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
    Transform camera;
    AudioSource gunSfx;

    private void Start()
    {
        actualBullets = maxBullets;
        shootLastTime = shootRate;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            if (shootRate >= shootLastTime)
            {
                shootLastTime = 0;
                Shoot();
            }
            shootLastTime += Time.deltaTime;
        }
    }

    public void SetCamera(Transform _camera)
    {
        camera = _camera; 
    }

    void Shoot()
    {
        if (camera != null)
        {
            if (actualBullets > 0)
            {
                actualBullets--;
                gunSfx.PlayOneShot(shootSound);

                if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, shootRate))
                {

                }
            }
            else
            {
                gunSfx.PlayOneShot(emptyShootSound);
            }
        }
    }
}
