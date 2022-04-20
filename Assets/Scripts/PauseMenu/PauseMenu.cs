using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool clickPause = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        if (clickPause)
        {
            Time.timeScale = 0;
            clickPause = false;
        }
        else if (!clickPause)
        {
            ResumeGame();
            clickPause = true;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
