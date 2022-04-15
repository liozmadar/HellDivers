using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public bool endGameGoToSpaceShip;
    public GameObject player;
    public TakeThePlayerUp sphere;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShipOutOfFrame", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && endGameGoToSpaceShip)
        {          
            player.SetActive(false);
            sphere.playerWin = true;
        }
    }
    void ShipOutOfFrame()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
    }
}
