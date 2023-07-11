using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // first, create 2 array to store the spraw point and the array to store the enemies
    public Transform[] spawnPoints;
    public GameObject[] enemies;

    private float spawnTime; // to tell us when is the time to spawn next enemy, if it's 2, enemy will spaen every 2 sec
    public float startSpawnTime; // reset the time btw spawn
    // In order to increase your game difficulties, we need to set a descreasing time so the spawn time
    // will get smaller and smaller each time, we also need to set a min spawn time so the game is 
    // still playable
    public float decrease;
    public float minSpawnTime;
    public Player player;
       

    // Update is called once per frame
    // sprawn random enemy from random sprawn point
    void Update()
    {
        // check if the time <= 0, if so, sprawn an enemy
        if (player != null)
        {
            if (spawnTime <= 0)
            {
                // choose the random sprawn point
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                // choose the random enemy;
                GameObject newEnemy = enemies[Random.Range(0, enemies.Length)];
                // then sprawn the new enemy at the chosen sprawn point
                // Instantiate(newEnemy, whereToSprawn, noRotationInYThisCase)
                Instantiate(newEnemy, randomPoint.position, Quaternion.identity);
                if (startSpawnTime > minSpawnTime)
                {
                    startSpawnTime -= decrease;
                }
                spawnTime = startSpawnTime;

                
                
            }
            else
            {
               
               spawnTime -= Time.deltaTime;
                
                
            }
        }
        
    }
}
