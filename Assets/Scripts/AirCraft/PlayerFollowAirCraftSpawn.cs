using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowAirCraftSpawn : MonoBehaviour
{
    public GameObject playerSpawnPanel;
    public PlayerFollowAirCraftSpawn player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LetGoOfThePlayer", 2);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();
    }
    void PlayerPosition()
    {
        transform.position = new Vector3(playerSpawnPanel.transform.position.x, playerSpawnPanel.transform.position.y , playerSpawnPanel.transform.position.z);
    }
    void LetGoOfThePlayer()
    {
        player.enabled = false;
    }
}
