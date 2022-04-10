using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTurret : MonoBehaviour
{
    public Rigidbody rb;
    public float throwPower;
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurretSummonFromBall", 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * throwPower * Time.deltaTime;
    }
    void TurretSummonFromBall()
    {
        Instantiate(turret, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
