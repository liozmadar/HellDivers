using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlySpeed : MonoBehaviour
{
    public float bulletSpeed;
    private float timer = 3f;

    private float random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(-1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }

        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
