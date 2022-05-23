using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al trigger");        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Se permanece adentro del trigger");        
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Salio del trigger");        
        
    }
}
