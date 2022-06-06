using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class EnemyController : MonoBehaviour
{
    public PlayerMovement movement;
    public Transform jugador;
    public float range;

    private void Start()
    {
        movement.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, jugador.position) <= range)
        {
            Rotar();
            movement.Move(0, 1);                
        }
    }

    void Rotar()
    {
        Vector3 desireDirection = jugador.position - transform.position;
        desireDirection.y = 0;
        
        if (Vector3.Dot(transform.TransformDirection(Vector3.forward).normalized, desireDirection.normalized) < .95f)
        {
            if (Vector3.Dot(transform.TransformDirection(Vector3.right).normalized, desireDirection.normalized) > 0)
            {
                movement.RotarPersonaje(1);
            }
            else 
            {
                movement.RotarPersonaje(-1);
            }
        }
    }
}
