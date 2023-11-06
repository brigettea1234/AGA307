using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public enum TargetSize {Small, Medium, Large}       //Add enums to GameBehaviour to keep tidy
public enum PatrolType {Random}

public class TargetManager : Singleton<TargetManager>
{
    public Transform[] spawnPoints;
    public string[] targetNames;
    public GameObject[] targetTypes;
    public List<GameObject> targets;

    public Difficulty difficulty;

   public void Start()
    {
        //SpawnAtRandom();
        StartCoroutine(SpawnTargetAtRandom());
        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            SpawnAtRandom();
        }
    }

    //Call this in the difficulty switch statement for mixed difficulty
    public void SpawnRandomTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
       {
        int rnd = Random.Range(0, targetTypes.Length);
        GameObject target = Instantiate(targetTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
        targets.Add(target);
       } 
       ShowTargetCount();
       
    }

    /// <summary>
    /// Difficulty switch statement to change difficulty
    /// </summary>
    public void SpawnTargets()
    {
        //Still getting random spawn points
        int rnd = Random.Range(0, spawnPoints.Length);

        //Reference the difficulty from the _GM script
        difficulty = _GM.difficulty;
        switch (difficulty)
        {
            //If easy difficulty is selected, spawn large targets at a random spawn point
            //targetTypes[2] referencing the targetTypes list
            case Difficulty.Easy:
                GameObject target = Instantiate(targetTypes[2], spawnPoints[rnd].position, spawnPoints[rnd].rotation);
                targets.Add(target);

                break;
            case Difficulty.Medium:
                GameObject target2 = Instantiate(targetTypes[1], spawnPoints[rnd].position, spawnPoints[rnd].rotation);
                targets.Add(target2);

                break;
            case Difficulty.Hard:
                GameObject target3 = Instantiate(targetTypes[0], spawnPoints[rnd].position, spawnPoints[rnd].rotation);
                targets.Add(target3);

                break;
            //Mixed difficulty uses the for loop to go through random targets
            case Difficulty.Mixed:

                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    int rndType = Random.Range(0, targetTypes.Length);
                    GameObject target4 = Instantiate(targetTypes[rndType], spawnPoints[i].position, spawnPoints[i].rotation);
                    targets.Add(target4);
                }
                break;
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

    IEnumerator SpawnTargetAtRandom()    //Delay
    {
        //Coroutine loop
        SpawnTargets();
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(SpawnTargetAtRandom());
        ShowTargetCount();
        
    }

    public void ShowTargetCount()
    {
        //print("Number of targets: " + targets.Count);
        _UI.UpdateTargetCount(targets.Count);
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    public void TargetDied(Target _target)
    {
        targets.Remove(_target.gameObject);
        //print(targets.Count);
        //targets.Add(target);
        ShowTargetCount();
    }
    
   
}
