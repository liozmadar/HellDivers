using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFireMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletTimer = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (bulletTimer < 0)
        {
            RayCastbulletShooter();          
        }
    }
    void RayCastbulletShooter()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
               
                // Vector3 hitPosition = hit.point;
                //              
                Vector3 hitPosition = new Vector3(hit.point.x,transform.position.y ,hit.point.z);
                //
                GameObject bulletTemp = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bulletTemp.transform.LookAt(hitPosition);

                bulletTimer = 0.2f;
            }
        }
    }
}
