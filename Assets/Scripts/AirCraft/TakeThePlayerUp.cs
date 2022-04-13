using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThePlayerUp : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject player;
    public float shipSphereTimer = 10f;

    public bool spaceShipIsCalled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShipSphereTimer();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = transform.position;
        }
    }
    void ShipSphereTimer()
    {
        shipSphereTimer -= Time.deltaTime;
        if (shipSphereTimer <= 0 && spaceShipIsCalled)
        {
            transform.position = new Vector3(spaceShip.transform.position.x, spaceShip.transform.position.y - 1, spaceShip.transform.position.z);          
        }
    }
    void GetIntoTheShip()
    {
       
    }
}
