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

    private float spawnTimer = 5f;
    private float reSpawnTimer = 10f;
    private float bossSpawnerTimer = 30f;
    private float reBossSpawnerTimer = 20f;
    private float SpawnSpeedTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        Instantiate(enemyPrefab, enemySpawnPoints[0].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemySpawnPoints[1].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemySpawnPoints[2].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemySpawnPoints[3].transform.position, Quaternion.identity);
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
            bossSpawnerTimer = reBossSpawnerTimer;
        }
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
        SpawnSpeedTimer += Time.deltaTime;
        SpawnTimer();
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
            reSpawnTimer = 5;   
        }
        else if (SpawnSpeedTimer > 60 && SpawnSpeedTimer < 90)
        {
            reSpawnTimer = 4;
        }
        else if (SpawnSpeedTimer > 90)
        {
            reSpawnTimer = 3;
        }
    }
}
