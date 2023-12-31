using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : GameBehaviour
{
    public GameObject triggeredObject;
    private void OnTriggerEnter(Collider other)
    {
        //Change the colour of the triggered object
        triggeredObject.GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnTriggerStay(Collider other)
    {
        //Increase the size of the triggered object by 0.01f
        triggeredObject.transform.localScale += Vector3.one * 0.01f;
        //Raise the triggered object on the y axis by 0.01f
        triggeredObject.transform.localPosition += Vector3.up * 0.01f;
    }

    private void OnTriggerExit(Collider other)
    {
        //Revert the size of the triggered object
        triggeredObject.transform.localScale = Vector3.one;
        //Revert the position of the triggered object
        triggeredObject.transform.localPosition = Vector3.one;
        //Revert the colour of the triggered object
        triggeredObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
