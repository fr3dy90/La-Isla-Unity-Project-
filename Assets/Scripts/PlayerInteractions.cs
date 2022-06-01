using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform objetoVacio;
    public Transform gunPoint;
    public LayerMask lm;

    private void Update()
    {
        if (Input.GetButtonDown("PickButton"))
        {
            if (objetoVacio.childCount > 0)
            {
                objetoVacio.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                objetoVacio.DetachChildren();
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, 2f, lm))
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.parent = objetoVacio;
                    hit.transform.localPosition = Vector3.zero;
                    Debug.Log(hit.transform.name);
                }
            }
        }
    }


    public PlayerState playerState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta" && playerState.batteryCount >= other.GetComponentInParent<Door>().batterysNeed)
        {
            other.GetComponentInParent<Door>().OnOpenDoor();
        }

        if (other.tag == "Battery")
        {
            other.GetComponent<Battery>().OnGetBattery();
            playerState.batteryCount++;                                   
        }

        if (other.tag == "Gun")
        {
            other.transform.parent = gunPoint;
            other.transform.localRotation = Quaternion.identity;
            other.transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}
