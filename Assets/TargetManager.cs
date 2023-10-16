using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void SpawnTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
       {

        int rnd = Random.Range(0, targetTypes.Length);
        GameObject target = Instantiate(targetTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);

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
}
