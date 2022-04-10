using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    public GameObject sample;
    public GameObject[] sampleSpawnPoints;
    private int randomSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SampleSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SampleSpawning()
    {
        randomSpawnPoint = Random.Range(0, sampleSpawnPoints.Length);
        Instantiate(sample, sampleSpawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
    }
}
