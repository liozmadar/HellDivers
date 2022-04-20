using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool clickPause = true;
    public Image pauseImage;
    public Sprite resumeSpriteImage;
    public Sprite pauseSpriteImage;
    public GameObject settingsButtonDisapper;
    public OpenSetting openSettings;
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
            pauseImage.sprite = resumeSpriteImage;
        }
        else if (!clickPause)
        {
            ResumeGame();
            clickPause = true;
            pauseImage.sprite = pauseSpriteImage;
            settingsButtonDisapper.SetActive(false);
            openSettings.settigsOpenClose = true;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
