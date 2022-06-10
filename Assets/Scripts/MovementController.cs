using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController: MonoBehaviour
{
    [Header("Movimiento del personaje")]
    public float speedMovement;
    public Vector3 direction;
    public CharacterController controller;

    [Header("Gravedad")]
    public Vector3 movementY;
    public float gravity = -9.8f;
    public float jumpHeight;

    [Header("Rotacion")]
    public float rotacionPersonajeY;

    private void Update()
    {
        //Calcular gravedad en cada frame
        movementY.y += gravity * Time.deltaTime;

        //Mover el personaje en "Y" en base a la gravedad calculada
        controller.Move(movementY * Time.deltaTime);

        //Si esta tocando el suelo y el movimiento en Y es negativo resetar la gravedad
        if (controller.isGrounded && movementY.y < 0)
        {
            movementY.y = -2f;
        }

        //Si el personaje esta tocando el suelo y al precionar la tecla, calcular el salto del personaje
        if(controller.isGrounded && Input.GetButtonDown("Jump")) 
        {
            movementY.y = Mathf.Sqrt(jumpHeight * -2 * gravity);    
        }
    }

    public void Move(float vertical, float horizontal)
    {
        //Captura valores del analogo para el movimiento del enemigo
        direction.x = horizontal;
        direction.z = vertical;

        //Transformar la direccion a coordenadas del jugador
        direction = transform.TransformDirection(direction);

        //Mover el jugador en base a los inputs
        controller.Move(direction * Time.deltaTime * speedMovement);
    }

    public void Rotate(float rotateValue)
    {
        rotacionPersonajeY += rotateValue;

        //Rotar el personaje en base al movimiento acomulado
        controller.transform.rotation = Quaternion.Euler(0, rotacionPersonajeY, 0);
    }
}
