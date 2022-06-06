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
    public float inputMoveForward;
    public Animator animatorController;
    public float attackRate;
    float waitTime;

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
            inputMoveForward = 1;
        }
        else
        {
            inputMoveForward = 0;
        }

        if (distance <= rangeAtack)
        {
            if (waitTime >= attackRate)
            {
                waitTime = 0;
                Attack();
            }
            //animatorController.SetBool("Attack", false);
            waitTime += Time.deltaTime;
            inputMoveForward = 0;
        }

        movement.Move(0, inputMoveForward);                
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
        /*
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rangeAtack, Color.red);
        if (Physics.SphereCast(transform.position, 0.2f ,transform.TransformDirection(Vector3.forward), out RaycastHit hit, distanceAttack))
        {
            if (hit.transform.GetComponent<PlayerState>() != null)
            {
                PlayerState playerState = hit.transform.GetComponent<PlayerState>();
                
            }
        }
        */
        animatorController.SetBool("Attack", true);
        Invoke("ResetAttack", .5f);
    }

    private void ResetAttack()
    {
        animatorController.SetBool("Attack", false);        
    }
}
