using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class EnemyController : MonoBehaviour
{
    PlayerMovement playerMovement;
    public float walkTime;
    public float walkT;
    float angle = 90;
    float root;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkT >= walkTime)
        {
            walkT = 0;
            TurnPlayer();
        }

        walkT += Time.deltaTime;
        playerMovement.Move(0, 1);

    }

    void TurnPlayer()
    {
        root = root + angle;
        if (root >= 360)
        {
            root = 0;
        }
        playerMovement.controller.transform.rotation = Quaternion.Euler(0,root,0);
    }
}
