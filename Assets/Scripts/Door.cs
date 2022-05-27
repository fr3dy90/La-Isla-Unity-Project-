using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public int batteryCount;        
    public void OnOpenDoor() 
    {
        anim.SetTrigger("OpenDoor");           
    } 
}
