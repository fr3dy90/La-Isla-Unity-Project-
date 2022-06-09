using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{
    [Header("Rotacion de la camara")]
    public Camera camaraPersonaje;
    private Vector2 mouseMovement;
    private float rotacionCamaraX;
    public float sencibilidadDelRaton;

    [Header("movement Controller")]
    public MovementController movement;    


    private void Update()
    {
        //Capturar el movimiento del mouse
        mouseMovement = new Vector2(Input.GetAxis("Mouse X")*sencibilidadDelRaton, Input.GetAxis("Mouse Y")*sencibilidadDelRaton);

        //Almacenar el movimiento del mouse
        rotacionCamaraX -= mouseMovement.y;

        //Limitar la rotacion de la camara en el eje x
        rotacionCamaraX = Mathf.Clamp(rotacionCamaraX, -40, 40);

        //Rotar la camara del personaje en base al movimiento acomulado
        camaraPersonaje.transform.localRotation = Quaternion.Euler(rotacionCamaraX, 0, 0);

        movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
