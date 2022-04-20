using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSetting : MonoBehaviour
{
    public GameObject settingsImage;
    public bool settigsOpenClose = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSettings()
    {
        if (settigsOpenClose)
        {
            settingsImage.SetActive(true);
            settigsOpenClose = false;
        }
        else if (!settigsOpenClose)
        {
            CloseSettings();
            settigsOpenClose = true;
        }
    }
    void CloseSettings()
    {
        settingsImage.SetActive(false);
    }
}
