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
            Vector3 forwardEnemigo = transform.forward.normalized;
            Vector3 direccionAljugador = (jugador.transform.position - transform.position).normalized;
            float v3Dot = Vector3.Dot(forwardEnemigo, direccionAljugador);

            if (v3Dot < 0.95f)
            {
                Vector3 rigthEnemigo = transform.right.normalized;
                float v3DotRight = Vector3.Dot(rigthEnemigo, direccionAljugador);
                if (v3DotRight > 0)
                {
                    movement.Rotate(1);
                }
                else
                {
                    movement.Rotate(-1);
                }
            }
        }

        


    }

}
