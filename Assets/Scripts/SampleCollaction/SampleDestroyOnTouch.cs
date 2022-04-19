using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SampleDestroyOnTouch : MonoBehaviour
{
    public CallTheSpaceShip callTheSpaceShip ;
    public TextMeshProUGUI missionText;
    // Start is called before the first frame update
    void Start()
    {
        callTheSpaceShip = FindObjectOfType<CallTheSpaceShip>();
        missionText = GameObject.Find("MissionText").GetComponent<TextMeshProUGUI>();
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
            missionText.text = "call the space ship !";
        }
    }
}
