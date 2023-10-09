using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTriggerPad : MonoBehaviour
{
    public GameObject triggeredObject;

    private void OnTriggerStay(Collider other)
    {
        //When the player is in the trigger zone, raycast to the sphere and change a property while the raycast hit returns true


        //When the player presses E, change another proprty of the sphere
    }
}
