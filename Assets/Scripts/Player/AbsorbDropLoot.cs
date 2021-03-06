using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbsorbDropLoot : MonoBehaviour
{
    public Animator anim;
    public GameObject torretSpawn;

    public int dropLootNumber;

    public PlayerHealth heal;
    public float healAmount = 10f;
    public float bossHealAmount = 20f;

    public Image TurretImage;
    public ThrowTurretFromHand callTheSciptThatThrow;
    public PlayerMovment playerMove;
    public PlayerMoveJoystick playerJoystickMove;
    public PlayerShotJoystick playerShot;

    [Header("TurretButtonFill")]
    public Image turretButton;
    public float turretMaxTimer = 10f;
    public float turretCurrentTimer;
    public float turretFillTimer;

    private bool movmentActive;
    private bool movmentJoystickActive;

    // Start is called before the first frame update
    void Start()
    {
        heal = GetComponent<PlayerHealth>();
        // torretText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //   HealMySelf();

        SummonTorret();
        //
        turretFillTimer += Time.deltaTime / 20;
        turretCurrentTimer = Mathf.Clamp(turretCurrentTimer, 0, turretMaxTimer);
        turretButton.fillAmount = turretFillTimer;
        turretButton.color = Color.Lerp(Color.red, Color.green, turretFillTimer);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropLoot")
        {
            //   dropLootNumber++;

            heal.RestoreHealth(healAmount);
        }
        else if (other.gameObject.tag == "BossDropLoot")
        {
            //   dropLootNumber += 5;

            heal.RestoreHealth(bossHealAmount);
        }
    }
    /* void HealMySelf()
     {
         if (dropLootNumber >= 5)
         {
             heal.RestoreHealth(healAmount);
             dropLootNumber -= 5;
         }
     }*/
    public void SummonTorret()
    {
        if (turretFillTimer >= 1)
        {
            turretButton.color = Color.green;
        }

        if (turretFillTimer <= 1)
        {
            turretButton.color = Color.red;
        }
    }
    void TurretDelay()
    {
        callTheSciptThatThrow.ThrowTheTurret();
    }
    void PlayerMoveAndShoot()
    {
        playerShot.enabled = true;
        if (movmentJoystickActive)
        {
            playerJoystickMove.enabled = true;
        }
        if (movmentActive)
        {
            playerMove.enabled = true;
        }
    }
    public void OnClickButtonTurret()
    {
        if (turretFillTimer >= 1)
        {
            anim.SetTrigger("TurretSummon");

            Invoke("TurretDelay", 1.5f);
            if (playerMove.enabled)
            {
                playerMove.enabled = false;
                movmentActive = true;
            }
            if (playerJoystickMove.enabled)
            {
                playerJoystickMove.enabled = false;
                movmentJoystickActive = true;
            }
            playerShot.enabled = false;

            Invoke("PlayerMoveAndShoot", 1.5f);

            turretFillTimer = 0f;
        }
    }
}
