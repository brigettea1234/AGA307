using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize {Small, Medium, Large}
public enum PatrolType {Random}

public class TargetManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public string[] targetNames;
    public GameObject[] targetTypes;
    public List<GameObject> targets;

   public void Start()
    {
        SpawnAtRandom();
        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        SpawnAtRandom();

        if(Input.GetKeyDown(KeyCode.R))
            ChangeTargetSize();
    }

    void ChangeTargetSize()
    {
        
        //transform.localScale = Random.Range(0, targetTypes.Length);
    }

    public void SpawnTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
       {

        int rnd = Random.Range(0, targetTypes.Length);
        GameObject target = Instantiate(targetTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
        //targets.Add(target);

       } 
    }

    public void SpawnAtRandom()
    {
        int rndTarget = Random.Range(0, targetTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        GameObject target = Instantiate(targetTypes[rndTarget], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        targets.Add(target);
        ShowTargetCount();
    
    }

    public void ShowTargetCount()
    {
        print("Number of targets: " + targets.Count);
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
    
}
