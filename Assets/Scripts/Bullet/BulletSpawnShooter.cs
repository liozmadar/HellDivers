using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnShooter : MonoBehaviour
{
    public Transform bullet;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void BulletShooter()
    {
        float randomShoot = Random.Range(-1, 1);
        
        Transform newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.Rotate(Vector3.up * randomShoot, Space.Self);
    }
}
