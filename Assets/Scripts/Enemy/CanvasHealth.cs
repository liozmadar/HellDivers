using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
*/
        transform.eulerAngles = Camera.main.transform.eulerAngles;
    }
}
