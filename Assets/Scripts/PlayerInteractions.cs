using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform objetoVacio;
    public LayerMask lm;

    private void Update()
    {
        Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, 2f, lm))
        { 
            if (Input.GetButtonDown("PickButton"))
            {
                hit.transform.parent = objetoVacio;
                hit.transform.localPosition = Vector3.zero;
                Debug.Log(hit.transform.name);
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
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}
