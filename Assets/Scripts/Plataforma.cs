using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject platform;


    public Transform minPosition;
    public Transform maxPosition;

    public float velocity;

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            MovePlatform();       
        }
    }

    private void MovePlatform()
    {
        if (platform.transform.position.y >= maxPosition.transform.position.y && velocity > 0)
        {
            velocity = velocity * -1;
        }

        if (platform.transform.position.y <= minPosition.transform.position.y && velocity < 0)
        {
            velocity = velocity * -1;
        }
        platform.transform.Translate(Vector3.up * Time.deltaTime * velocity);
    }
}
