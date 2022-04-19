using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapOnClick : MonoBehaviour
{
    public Camera MiniMapCamera;
    public Image openMiniMap;
    private bool clickOpenAndClose;
    public MiniMapCam MiniMapCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTheMiniMap()
    {
        if (!clickOpenAndClose)
        {
            openMiniMap.gameObject.SetActive(true);
            clickOpenAndClose = true;        
            
            MiniMapCam.miniMapCamDistance += 150f;
        }
        else if (clickOpenAndClose)
        {
            openMiniMap.gameObject.SetActive(false);
            clickOpenAndClose = false;

            MiniMapCam.miniMapCamDistance -= 150f;
        }
    }
}
