using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletSpawnShooter : MonoBehaviour
{
    public Transform bullet;
    private int bulletCount = 30;
    private int currentBulletCount;
    

    public Button reloadButton;
    public TextMeshProUGUI reloadText;
    

    // Start is called before the first frame update
    void Start()
    {
        currentBulletCount = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        reloadText.text = currentBulletCount.ToString() + "/30";
    }
    public void BulletShooter()
    {
        if (currentBulletCount > 0)
        {
            float randomShoot = Random.Range(-3, 3);

            Transform newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.Rotate(Vector3.up * randomShoot, Space.Self);

            currentBulletCount--;
        }    
    }
    public void ReloadButtonClick()
    {
        if (currentBulletCount < 30)
        {
            currentBulletCount = 30;
        }
    }
}
