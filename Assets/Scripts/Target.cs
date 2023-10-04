using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 5;
            
    private void OnCollisionEnter(Collision collision)
    {
        //Health will decrease by 1 on every collision. -- is the same as minus 1 
        if (health > 0) health--;
        //Destroy the gameObject if the health is < or = to 0
        else Destroy(gameObject);

    }
}
