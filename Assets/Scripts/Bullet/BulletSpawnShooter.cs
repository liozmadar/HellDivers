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
    public TextMeshProUGUI reloadTextAbove;

    public Animator anim;
    public PlayerMoveJoystick playerMoveJoystick;
    public PlayerMovment playerMove;
    private bool isReloadingNow = true;

    private bool reloadingText = true;
    

    // Start is called before the first frame update
    void Start()
    {
        currentBulletCount = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        reloadText.text = currentBulletCount.ToString() + "/30";
        if (currentBulletCount < 10 && reloadingText)
        {
            reloadTextAbove.text = "Reload!";           
        }
    }
    public void BulletShooter()
    {
        if (currentBulletCount > 0 && isReloadingNow)
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
            reloadingText = false;
            reloadTextAbove.text = "Reloading!";
            anim.SetTrigger("Reload");
          //  playerMoveJoystick.enabled = false;
          //  playerMove.enabled = false;

            isReloadingNow = false;
            Invoke("ReloadCoolDown", 2.2f);
        }
    }
    void ReloadCoolDown()
    {
        currentBulletCount = 30;
        reloadTextAbove.text = "";

      //  playerMoveJoystick.enabled = true;
      //  playerMove.enabled = true;

        isReloadingNow = true;
        reloadingText = true;
    }
}
