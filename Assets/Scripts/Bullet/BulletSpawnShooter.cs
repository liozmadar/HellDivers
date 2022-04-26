using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletSpawnShooter : MonoBehaviour
{
    public Transform bullet;
    private int bulletCount = 30;

    public Button reloadButton;
    public TextMeshProUGUI reloadText;

    // Start is called before the first frame update
    void Start()
    {
        reloadText = GameObject.Find("ReloadText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadText.text = bulletCount.ToString();
    }
    public void BulletShooter()
    {
        if (bulletCount > 0)
        {
            float randomShoot = Random.Range(-3, 3);

            Transform newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.Rotate(Vector3.up * randomShoot, Space.Self);
            bulletCount--;
        }    
    }
    public void ReloadButtonClick()
    {
        if (bulletCount < 30)
        {
            bulletCount = 30;
        }
    }
}
