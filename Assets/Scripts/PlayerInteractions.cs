using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerState playerState;
    public Transform cameraPlayer;
    public float distance;
    public Transform pickPoint;
    public Transform gunPoint;
    public LayerMask lm;

    private void Update()
    {
        if (Input.GetButtonDown("PickButton"))
        {
            if (pickPoint.childCount > 0)
            {
                pickPoint.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                pickPoint.DetachChildren();
                gunPoint.gameObject.SetActive(true); 
            }
            else
            {
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out RaycastHit hit, distance, lm))
                {
                    if (hit.transform.tag == "Box")
                    {
                        hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                        hit.transform.parent = pickPoint;
                        hit.transform.localRotation = Quaternion.identity;
                        hit.transform.localPosition = Vector3.zero;
                        gunPoint.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (gunPoint.childCount > 0)
            {
                gunPoint.GetComponentInChildren<Gun>().canShoot = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta")
        {
            if (playerState.batteryCount >= other.GetComponentInParent<Door>().batteryCount)
            {
                other.GetComponentInParent<Door>().OnOpenDoor();
            }
        }

        if (other.tag == "Battery")
        {
            other.GetComponent<Battery>().OnGetBattery();
            playerState.batteryCount++;
        }

        if (other.tag == "Gun")
        {
            other.transform.parent = gunPoint;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            other.GetComponent<Gun>().SetCamera(cameraPlayer);
            if (pickPoint.childCount > 0)
            {
                gunPoint.gameObject.SetActive(false);                
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}



