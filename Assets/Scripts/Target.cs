using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetManager _TM;
    public TargetSize myTargetSize;
    public PatrolType myPatrol;
    float scaleFactor = 1;
    float moveDistance = 350;
    public float myDistance = 1;

    public float mySpeed = 1f;
    float baseSpeed = 2f;

    int baseHealth = 1;     //HEEEEEEELLLLLLLLPPPPPPPPPPP
    public int health;

    public Transform moveToPos; //Needed for all patrols
    Transform startPos;         //Needed for loop patrol movement
    Transform endPos;           //Needed for loop patrol movement

    void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        StartCoroutine(Move());

        switch(myTargetSize)
        {
            case TargetSize.Small:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor;
                mySpeed = baseSpeed * 3;
                myPatrol = PatrolType.Random;
                health = baseHealth;
                //myDistance = moveDistance;
                break;
            case TargetSize.Medium:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor * 2;
                mySpeed = baseSpeed * 2;
                myPatrol = PatrolType.Random;
                health = baseHealth * 3;
                //myDistance = moveDistance * 2;
                break;
            case TargetSize.Large:
                transform.localScale = new Vector3(0.02f, 1f, 1f) * scaleFactor * 3;
                mySpeed = baseSpeed;
                myPatrol = PatrolType.Random;
                health = baseHealth * 5;
                //myDistance = moveDistance * 4;
                break;

        }

        SetupAi();
    }

     void SetupAi()
    {
        
        startPos = Instantiate(new GameObject(), transform.position, transform.rotation).transform;
        endPos = _TM.GetRandomSpawnPoint();
        moveToPos = endPos;
        //Starts coroutine loop
        StartCoroutine(Move());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            StopAllCoroutines();

        //if(Input.GetKeyDown(KeyCode.R))
            //ChangeTargetSize();
    }

    /*void ChangeTargetSize()
    {
        transform.localScale = Random.Range(0, 3);
    }*/

    IEnumerator Move()
    {

        switch (myPatrol)
        {
            case PatrolType.Random:
            moveToPos = _TM.GetRandomSpawnPoint();
                break;
        }

        transform.LookAt(moveToPos);
        //While our distance is greater than 0.3
        while (Vector3.Distance(transform.position, moveToPos.position) > 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            yield return null;
        }

        yield return new WaitForSeconds(3);
                
        StartCoroutine(Move());
        
        /*for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * mySpeed);
            yield return null;
        }

        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Move());*/
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
