using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetManager _TM;
    public TargetSize myTargetSize;
    public PatrolType myPatrol;
    //float scaleFactor = 1;

    public float mySpeed = 1f;
    float baseSpeed = 2f;

    //int baseHealth;     
    public int health;
    public int myScore;


    public Transform moveToPos; //Needed for all patrols
    Transform startPos;         //Needed for loop patrol movement
    Transform endPos;           //Needed for loop patrol movement

    Vector3 size1 = new Vector3(0.2f, 1, 1);    //Size variables to change the size of the targets
    Vector3 size2 = new Vector3(0.2f, 2, 2);
    Vector3 size3 = new Vector3(0.2f, 3, 3);

    void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        StartCoroutine(Move());

        Establish();

        SetupAi();
    }

    /// <summary>
    /// Holds the switch information
    /// </summary>
    private void Establish()
    {
        switch (myTargetSize)
        {
            case TargetSize.Small:
                transform.localScale = size1;
                mySpeed = baseSpeed * 3;
                myPatrol = PatrolType.Random;
                health = 1;
                myScore = 100;
                break;
            case TargetSize.Medium:
                transform.localScale = size2;
                mySpeed = baseSpeed * 2;
                myPatrol = PatrolType.Random;
                health = 2;
                myScore = 50;
                break;
            case TargetSize.Large:
                transform.localScale = size3;
                mySpeed = baseSpeed;
                myPatrol = PatrolType.Random;
                health = 3;
                myScore = 25;
                break;
        }
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

        if (Input.GetKeyDown(KeyCode.R))
            ChangeTargetSize();      
    }


    public void Hit(int _damage)
    {
        health -= _damage;
        
        //If target's health is less than 0, AddScore and then destroy target
        if (health <= 0)
        {
            GameManager.INSTANCE.AddScore(myScore);
            Die();
        }

    }

    public void Die()
    {
        GameManager.INSTANCE.AddScore(100);
        TargetManager.INSTANCE.TargetDied(this);
        StopAllCoroutines();
        //Destory(this.gameObject); //HELP
        UnityEngine.Object.Destroy(this.gameObject);
    }

    void ChangeTargetSize()
    {
        float rnd = Random.Range(1, 4);
        if(rnd == 1)
        {
            myTargetSize = TargetSize.Small;
            Establish();
            transform.localScale = size1;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            
        }
        if (rnd == 2)
        {
            myTargetSize = TargetSize.Medium;
            Establish();
            transform.localScale = size2;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (rnd == 3)
        {
            myTargetSize = TargetSize.Large;
            Establish();
            transform.localScale = size3;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

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
        if (health > 0) Hit(1);
        //Destroy the gameObject if the health is < or = to 0
        else
        {
            Destroy(gameObject);
        } 

    }
}
