using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento del personaje")]
    public float speedMovement;
    public Vector3 direction;
    public CharacterController controller;

    [Header("Rotacion de la camara")]
    public Camera camaraPersonaje;
    public Vector2 mouseMovement;
    public float rotacionCamaraX;
    public float rotacionPersonajeY;
    public float sencibilidadDelRaton;

    [Header("Gravedad")]
    public Vector3 movementY;
    public float gravity = -9.8f;
    public float jumpHeight;

   

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
    }
                             
    public void Move( float horizontal, float vertical)
    {
        //Captura valores del analogo para el movimiento del enemigo
        direction.x = horizontal;
        direction.z = vertical;

        //Transformar la direccion a coordenadas del jugador
        direction = transform.TransformDirection(direction);

        //Mover el jugador en base a los inputs
        controller.Move(direction * Time.deltaTime * speedMovement);
    }

    public void RotarPersonaje(float rotacionPersonaje)
    {
        rotacionPersonaje *= sencibilidadDelRaton;
        mouseMovement.x = rotacionPersonaje;
        rotacionPersonajeY += mouseMovement.x;

        //Rotar el personaje en base al movimiento acomulado
        controller.transform.rotation = Quaternion.Euler(0, rotacionPersonajeY, 0);
    }

    public void RotarCamera(float rotacionCamera)
    {
        //Capturar el movimiento del mouse
        mouseMovement.y = rotacionCamera;

        //Almacenar el movimiento del mouse
        rotacionCamaraX -= mouseMovement.y;

        //Limitar la rotacion de la camara en el eje x
        rotacionCamaraX = Mathf.Clamp(rotacionCamaraX, -40, 40);

        //Rotar la camara del personaje en base al movimiento acomulado
        camaraPersonaje.transform.localRotation = Quaternion.Euler(rotacionCamaraX, 0, 0);
    }

    public void Jump()
    {
        //Si el personaje esta tocando el suelo y al precionar la tecla, calcular el salto del personaje
        if (controller.isGrounded)
        {
            movementY.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
}
