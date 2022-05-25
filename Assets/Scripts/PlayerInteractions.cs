using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerState playerState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta")
        {
            if (playerState.batteryCount >= 3)
            {
                other.GetComponentInParent<Door>().OnOpenDoor();
            }
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
