using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTheSpaceShip : MonoBehaviour
{
    public GameObject spaceShip;
    private bool oneCallForTheSpaceShip = true;
    private Vector3 currentPosition;

    public TakeThePlayerUp sphere;
    public SpaceShip ship;
    public TrailRenderer trailRendererFromTheShipSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SummonTheSpaceShip();      
    }

    void SummonTheSpaceShip()
    {
        if (Input.GetKey(KeyCode.K) && oneCallForTheSpaceShip)
        {
            currentPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            Debug.Log(currentPosition);
        
            oneCallForTheSpaceShip = false;
            Invoke("Check", 3);
        }      
    }
    void Check()
    {
        Debug.Log(currentPosition);
        spaceShip.transform.position = currentPosition;

        sphere.spaceShipIsCalled = false;
        sphere.endGameGoUp = true;
        ship.endGameGoToSpaceShip = true;
        trailRendererFromTheShipSphere.enabled = true;
    }
}
