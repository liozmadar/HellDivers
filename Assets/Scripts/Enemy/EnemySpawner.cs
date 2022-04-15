using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject bossEnemyPrefab;
    public GameObject[] enemySpawnPoints;

    public float spawnTimer = 5f;
    public float reSpawnTimer = 5f;
    public float bossSpawnerTimer = 20f;
    public float reBossSpawnerTimer = 20f;
    private float SpawnSpeedTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        bossSpawnerTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {        
            EnemySpawn();
            spawnTimer = reSpawnTimer;
        }
        if (bossSpawnerTimer < 0)
        {
            BossEnemySpawn();
            bossSpawnerTimer = 20f;
        }
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
        SpawnSpeedTimer += Time.deltaTime;
        SpawnTimer();
        Debug.Log(reSpawnTimer);
    }
    void EnemySpawn()
    {
        if (playerHealth.health > 0)
        {
            int RandomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);
            Instantiate(enemyPrefab, enemySpawnPoints[RandomSpawnPoint].transform.position, Quaternion.identity);
        }
    }
    void BossEnemySpawn()
    {
        if (playerHealth.health > 0)
        {
            int RandomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);
            Instantiate(bossEnemyPrefab, enemySpawnPoints[RandomSpawnPoint].transform.position, Quaternion.identity);
        }
    }
    void SpawnTimer()
    {
        if (SpawnSpeedTimer > 30 && SpawnSpeedTimer < 60)
        {
            reSpawnTimer = 4;
        }
        else if (SpawnSpeedTimer > 60 && SpawnSpeedTimer < 90)
        {
            reSpawnTimer = 3;
        }
        else if (SpawnSpeedTimer > 90)
        {
            reSpawnTimer = 2;
        }
    }
}
