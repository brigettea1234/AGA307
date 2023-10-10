using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTriggerPad : MonoBehaviour
{
    public GameObject triggeredObject;
    int propertyNumber = 1;
    public bool inSphere;

    private void Update()
    {
       
        if(inSphere == true)
        {
            //When the player presses E, change int
            if (Input.GetKeyDown(KeyCode.E))
            {

                //print("e");
                //Plus 1
                //print("before add" + propertyNumber);

                propertyNumber = propertyNumber + 1;

                print(propertyNumber);
                //Loop til property 3. If property 5 is reached, cycle back to property 1 
                if (propertyNumber == 5)
                {
                    propertyNumber = 1;
                }


            }
       


        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        inSphere = true;

    }


    private void OnTriggerExit(Collider other)
    {
        inSphere = false;
    }

    public void PropertySwitch()
    {

        print("print" + propertyNumber);
        //Property labeled 1 will change the sphere to blue
        if(propertyNumber==1)
        {
            triggeredObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    
        //Property 2 will shrink the sphere
        if(propertyNumber==2)
        {
            triggeredObject.GetComponent<Renderer>().material.color = Color.green;
        }

        //Property 3 will increase the size of the sphere
        if(propertyNumber==3)
        {
            triggeredObject.transform.localScale = Vector3.one * 2f;
        }

        //Property 4 will revert the size of the sphere
        if(propertyNumber==4)
        {
            triggeredObject.transform.localScale = Vector3.one * 1f;
            triggeredObject.GetComponent<Renderer>().material.color = Color.white;
        }

    }


}
