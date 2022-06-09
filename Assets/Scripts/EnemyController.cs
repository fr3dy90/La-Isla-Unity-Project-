using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class EnemyController : MonoBehaviour
{
    public PlayerMovement movement;
    public Transform jugador;
    public float rangeDetection;
    public float distanceAttack;
    public float rangeAtack;
    public float attackRate;
    float waitTime;

    public Animator animComtroller;

    private void Start()
    {
        movement.GetComponent<PlayerMovement>();
    }

    private void Update()
    { 
        float distance = Vector3.Distance(transform.position, jugador.position);

        if (distance <= rangeDetection)
        {
            Rotar();
            movement.Move(0, 1);
            animComtroller.SetFloat("SpeedMovemt", 1);
        }

        if (distance <= rangeAtack)
        {
            if (waitTime >= attackRate)
            {
                waitTime = 0;
                Attack();
            }
            waitTime += Time.deltaTime;
        }
    }

    void Rotar()
    {
        Vector3 desireDirection = jugador.position - transform.position;
        desireDirection.y = 0;
        
        if (Vector3.Dot(transform.TransformDirection(Vector3.forward).normalized, desireDirection.normalized) < .99f)
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

    void Attack()
    {
        
    }
}
