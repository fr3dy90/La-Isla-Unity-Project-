using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    //Variable para hacer referencia al sonido
    public AudioSource source;
    public AudioClip soundFX;

    public void OnGetBattery()
    {
        gameObject.SetActive(false);
        //mover el sonido
        //Posicion de la bateria = posicion del transform que tiene este script
        source.transform.position = transform.position;

        //Reproducir el Sonido
        source.PlayOneShot(soundFX);
    }
}
