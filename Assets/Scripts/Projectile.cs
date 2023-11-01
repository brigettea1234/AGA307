using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : GameBehaviour
{
    public bool canDestroy;         
    public bool isExplosive;
    public GameObject explosion;
    
    void Start()
    {
        //Destroy projectile after 5 seconds
        StartCoroutine(WaitToTurnOnDestroy());
        Destroy(this.gameObject, 5);
    }

    /// <summary>
    /// Waits 0.3 seconds before destroying the target
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitToTurnOnDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        canDestroy = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if we hit the object tagged Target
        if (collision.gameObject.CompareTag("Target"))
        {
            //Change the colour of the target
            collision.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            ////Destroy the target after 1 second
            //Destroy(collision.gameObject, 1);
            ////Destroy this object
            //Destroy(this.gameObject);

        }
        else
        {
            if(canDestroy)
            {
                if(isExplosive)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }

        }
    }
}
