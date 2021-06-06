using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject opponentTank;
    public GameObject player;
    GameObject[] spawnPoint;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float lastSpawnTime;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(opponentTank, spawnPoint[point].transform.position, Quaternion.identity);
        UpdateSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            Spawn();
        }
    }
}
