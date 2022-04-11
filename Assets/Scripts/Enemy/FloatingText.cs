using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public Camera myCamera;

    public float floatingTextDestroyTimer = 2f;
    public Vector3 offSet = new Vector3(0, 4, 0);
    public Vector3 randomTextPosition = new Vector3(1f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, floatingTextDestroyTimer);

        transform.localPosition += offSet;

        transform.localPosition += new Vector3(Random.Range(-randomTextPosition.x, randomTextPosition.x),
            Random.Range(-randomTextPosition.y, randomTextPosition.y),
            Random.Range(-randomTextPosition.z, randomTextPosition.z));

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
