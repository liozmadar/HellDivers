using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CallTheSpaceShip : MonoBehaviour
{
    public GameObject spaceShip;
    private bool oneCallForTheSpaceShip = true;
    private Vector3 currentPosition;

    public TakeThePlayerUp sphere;
    public SpaceShip ship;
    public TrailRenderer trailRendererFromTheShipSphere;

    public Button spaceShipButton;
    public bool tookTheSample;

    //calling the spaceShip text and timer
    private float spaceShipComing = 0;
    public int spaceShipComingInt = 10;
    public TextMeshProUGUI spaceShipComingText;
    public bool setShipComingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpaceShipButtonColor();
        SpaceShipIsComingTimer();
    }
    void SpaceShipButtonColor()
    {
        if (tookTheSample)
        {
            spaceShipButton.image.color = Color.green;
        }
    }

    public void SummonTheSpaceShip()
    {
        if (oneCallForTheSpaceShip && tookTheSample)
        {
            currentPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            Debug.Log(currentPosition);
        
            oneCallForTheSpaceShip = false;
            Invoke("Check", 10);

            setShipComingText = true;          
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
    void SpaceShipIsComingTimer()
    {
        if (setShipComingText)
        {
            spaceShipComing += Time.deltaTime;
            if (spaceShipComing >= 1)
            {
                spaceShipComingInt--;
                spaceShipComing = 0;
            }
            spaceShipComingText.text = spaceShipComingInt.ToString();
        }
        if (spaceShipComingInt < 0)
        {
            setShipComingText = false;
            spaceShipComingText.text = "";
        }
    }
}
