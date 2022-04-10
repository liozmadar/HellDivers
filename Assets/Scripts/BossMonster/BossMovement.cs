using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float risingSpeed = 5f;
    private bool isRising = true;
    private float risingStopTimer = 2f;
    public float what;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * risingSpeed * Time.deltaTime);
        Rising();
        risingStopTimer -= Time.deltaTime;
        if (risingStopTimer <= 0)
        {
            isRising = false;
        }
    }
    void Rising()
    {
        if (isRising)
        {
            transform.Translate(Vector3.up * risingSpeed * Time.deltaTime);
        }
    }
}
