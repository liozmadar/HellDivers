using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    public bool endGameGoToSpaceShip;
    public GameObject player;
    public TakeThePlayerUp sphere;

    //win texts

    public TextMeshProUGUI numberOfKillsText;
    public TimeFromStartGame timePlayed;
    public TextMeshProUGUI howManyTimePlayedText;
    public TextMeshProUGUI youWinText;
    public int numberOfKills;
    public Button replayButtonIfWin;

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

            //win texts
            numberOfKillsText.text = "You Killed : " + numberOfKills.ToString() + " Enemies";
            howManyTimePlayedText.text = "You Played : " + timePlayed.intTimer + " Sec";
            youWinText.text = "You Win !";
            replayButtonIfWin.gameObject.SetActive(true);
        }
    }
    public void ReplayAfterWin()
    {
        SceneManager.LoadScene(1);
    }

    void ShipOutOfFrame()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
    }
}
