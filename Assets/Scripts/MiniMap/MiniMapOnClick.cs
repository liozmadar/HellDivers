using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapOnClick : MonoBehaviour
{
    public Image openMiniMap;
    private bool clickOpenAndClose;
    
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
        }
        else if (clickOpenAndClose)
        {
            openMiniMap.gameObject.SetActive(false);
            clickOpenAndClose = false;
        }
    }
}
