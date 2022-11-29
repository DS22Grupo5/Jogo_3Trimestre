using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;

    private float nextSpawn = 0f;
    public float nitaners = 0;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn){
            nitaners++;
                nextSpawn = Time.time + spawnRate;
                Instantiate(enemy,transform.position,enemy.transform.rotation);
        }
    }
}
