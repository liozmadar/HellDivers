using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool addBulletSpread = true;
    public Vector3 bulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    public ParticleSystem shootingSystem;
    public Transform bulletSpawnPoint;
    public ParticleSystem impactParticaleStstem;
    public TrailRenderer bulletTrail;
    public float shootDelay = 0.5f;
    public LayerMask mask;
    //
    public Animator anim;
    public float lastShootTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        if (lastShootTime + shootDelay < Time.deltaTime)
        {
            anim.SetBool("Shoot", true);
            shootingSystem.Play();
            Vector3 direction = GetDirection();

            if (Physics.Raycast(bulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, mask))                
            {
                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine((string)SpawnTrail(trail, hit));
                lastShootTime = Time.deltaTime;
            }
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 directoin = transform.forward;
        if (addBulletSpread)
        {
            directoin += new Vector3(
                Random.Range(-bulletSpreadVariance.x, bulletSpreadVariance.x),
                Random.Range(-bulletSpreadVariance.y, bulletSpreadVariance.y),
                Random.Range(-bulletSpreadVariance.z, bulletSpreadVariance.z)
                );
            directoin.Normalize();
        }
        return directoin;
    }
    private IEnumerable SpawnTrail(TrailRenderer trail,RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }
        anim.SetBool("IsShooting", false);
        trail.transform.position = hit.point;
        Instantiate(impactParticaleStstem, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(trail.gameObject, trail.time);
    }
}
