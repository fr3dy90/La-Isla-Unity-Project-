using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyController : MonoBehaviour
{
    public MovementController movement;
    public Transform jugador;
    public float rangeOfDetection = 15f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.position);
        if(distance <= rangeOfDetection)
        {

        }

        //Vector3.Dot


    }

}
