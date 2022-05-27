using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform cameraPlayer;

    private void Update()
    {
        Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward, Color.green);       
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
