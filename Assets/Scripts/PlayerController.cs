using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public Transform target;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        playerMovement.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerMovement.RotarCamera(Input.GetAxis("Mouse Y"));
        playerMovement.RotarPersonaje(Input.GetAxis("Mouse X"));

        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.Jump();
        }

        playerMovement.camaraPersonaje.transform.LookAt(target);
    }
}
