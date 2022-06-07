using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform objetoVacioCaja;
    public Transform objetoVacioArma;
    public LayerMask lm;
    public float rayDistance;
    public PlayerState playerState;

    private void Update()
    {
        if (Input.GetButtonDown("PickButton"))
        {
            if (objetoVacioCaja.childCount > 0)
            {
                objetoVacioCaja.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacioCaja.DetachChildren();
                if (objetoVacioArma.childCount > 0)
                {
                    objetoVacioArma.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward * rayDistance, Color.green);
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out RaycastHit hit, rayDistance, lm)) 
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.parent = objetoVacioCaja;
                    hit.transform.localPosition = Vector3.zero;
                    hit.transform.localRotation = Quaternion.identity;
                    if (objetoVacioArma.childCount > 0)
                    {
                        objetoVacioArma.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

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
            other.transform.parent = objetoVacioArma;
            other.transform.localRotation = Quaternion.identity;
            other.transform.localPosition = Vector3.zero;
            if (objetoVacioCaja.childCount > 0)
            {
                other.gameObject.SetActive(false);
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
