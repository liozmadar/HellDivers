using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    public GameObject replayYesOrNotImage;
    public PauseMenu resumeGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReplayButtonAsk()
    {
        replayYesOrNotImage.SetActive(true);
    }
    public void NoButton()
    {
        replayYesOrNotImage.SetActive(false);
    }
    public void YesButton()
    {
        SceneManager.LoadScene(1);
        resumeGame.ResumeGame();
    }
}
