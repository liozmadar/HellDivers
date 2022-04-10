using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GroundFloor")
        {
            SpawnPlayer();
            Invoke("DestroyGameObject", 3);
        }
    }
    void SpawnPlayer()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
