using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawnPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mountains")
        {
            Debug.Log("Mountains");
            gameObject.SetActive(false);          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mountains")
        {
            
        }    
    }
}
