using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretCoolDown : MonoBehaviour
{
    private float timer = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        TorretCoolDownDestroy();
    }
    void TorretCoolDownDestroy()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
