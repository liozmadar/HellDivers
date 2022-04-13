using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThePlayerUp : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject player;
    public TrailRenderer trailRenderer;

    private float shipSphereTimer = 5f;
    public float upSpeed = 1;

    public bool spaceShipIsCalled = true;
    public bool endGameGoUp = false;
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
            if (endGameGoUp)
            {
                player.transform.position = transform.position;

                transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
            }    
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
