using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThePlayerUp : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject player;
    private float shipSphereTimer = 5f;

    public bool spaceShipIsCalled = true;
    public TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShipSphereTimer();


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = transform.position;
            Debug.Log("111");
        }
    }
    void ShipSphereTimer()
    {
        shipSphereTimer -= Time.deltaTime;
        if (shipSphereTimer <= 0 && spaceShipIsCalled)
        {
            trailRenderer.enabled = false;
            transform.position = new Vector3(spaceShip.transform.position.x, spaceShip.transform.position.y - 1, spaceShip.transform.position.z);          
        }
    }
    void GetIntoTheShip()
    {
       
    }
}
