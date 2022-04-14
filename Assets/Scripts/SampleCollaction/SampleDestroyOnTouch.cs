using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDestroyOnTouch : MonoBehaviour
{
    public CallTheSpaceShip callTheSpaceShip ;
    // Start is called before the first frame update
    void Start()
    {
        callTheSpaceShip = FindObjectOfType<CallTheSpaceShip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            callTheSpaceShip.tookTheSample = true;
        }
    }
}
