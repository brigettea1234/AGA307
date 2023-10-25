using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetManager _TM;
    public TargetSize myTargetSize;
    float scaleFactor = 1;
    float moveDistance = 350;
    public float myDistance = 1;

    public float mySpeed = 1f;
    float baseSpeed = 2f;

    int baseHealth = 1;     //HEEEEEEELLLLLLLLPPPPPPPPPPP
    public int health;

    void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        StartCoroutine(Move());

        switch(myTargetSize)
        {
            case TargetSize.Small:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor;
                mySpeed = baseSpeed * 3;
                health = baseHealth;
                //myDistance = moveDistance;
                break;
            case TargetSize.Medium:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor * 2;
                mySpeed = baseSpeed * 2;
                health = baseHealth * 3;
                //myDistance = moveDistance * 2;
                break;
            case TargetSize.Large:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor * 3;
                mySpeed = baseSpeed;
                health = baseHealth * 5;
                //myDistance = moveDistance * 4;
                break;

        }
    }

    IEnumerator Move()
    {

        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * mySpeed);
            yield return null;
        }

        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Move());
    }

    //public int health = 5;

    private void OnCollisionEnter(Collision collision)
    {
        //Health will decrease by 1 on every collision. -- is the same as minus 1 
        if (health > 0) health--;
        //Destroy the gameObject if the health is < or = to 0
        else Destroy(gameObject);

    }
}
