using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTheSpaceShip : MonoBehaviour
{
    public GameObject spaceShip;
    private bool oneCallForTheSpaceShip = true;
    private Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
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
    }
}
