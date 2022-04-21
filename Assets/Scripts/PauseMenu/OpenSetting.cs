using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSetting : MonoBehaviour
{
    public GameObject settingsMenu;
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
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
