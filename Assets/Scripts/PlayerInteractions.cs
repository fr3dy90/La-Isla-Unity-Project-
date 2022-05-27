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
        if (pickPoint.childCount == 0)
        {
            Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward * distance, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, distance, lm))
            {
                Debug.Log("Tengo Adelante: " + hit.transform.name);

                if (hit.transform.tag == "Box")
                {
                    //indicarle al jugador que puede tomar el objeto
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Debug.Log("Se emparenta el objeto");
                        hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                        hit.transform.parent = pickPoint;
                        hit.transform.localPosition = Vector3.zero;
                    }
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Soltar Objeto");
                pickPoint.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                pickPoint.transform.GetChild(0).transform.parent = null;
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
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}
