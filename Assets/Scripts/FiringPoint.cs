using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("Rigidbody Projectiles")]
    public GameObject projectileGreenOrb;
    public float projectileSpeed = 1000f;

    [Header("Raycast Projectiles")]
    public GameObject hitSparks;
    public LineRenderer laser;
    public GameObject raycastTriggerZone;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            FireRigidBody();

        if (Input.GetButtonDown("Fire2"))
            FireRaycast();

    }

    
    
    
    void FireRigidBody()
    {
        //Create a reference to hold our instantiated object
        GameObject projectileInstance;
        //Instantiate our projectile at this objects position and rotation
        projectileInstance = Instantiate(projectileGreenOrb, transform.position, transform.rotation);
        //Add force to the projectile
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

    }

    void FireRaycast()
    {
        //Create the ray
        Ray ray = new Ray(transform.position, transform.forward);
        //Create a reference to hold the info on what we hit
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);
            StopAllCoroutines();
            StartCoroutine(StopLaser());

            GameObject particles = Instantiate(hitSparks, hit.point, hit.transform.rotation);
            Destroy(particles, 1);

            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
            }

            //If the inSphere bool is true, then everything in the nest will occur 
            if(raycastTriggerZone.GetComponent<RaycastTriggerPad>().inSphere)
            {
                //When the raycast hits the game object tagged sphere
                if (hit.collider.CompareTag("Sphere"))
                {
                    //Referencing the function created in the raycast trigger pad script which will cycle through the property changes
                    raycastTriggerZone.GetComponent<RaycastTriggerPad>().PropertySwitch();
                }


            }
            
                


        }
    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        laser.gameObject.SetActive(false);
    }
}
