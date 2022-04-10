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
    public float healAmount = 20f;

    public TextMeshProUGUI turretText;
    public Image TurretImage;


    public ThrowTurretFromHand callTheSciptThatThrow;
    public PlayerMovment playerMove;
    public PlayerShotJoystick playerShot;

    [Header("TurretButtonFill")]
    public Image turretButton;
    public float turretMaxTimer = 10f;
    public float turretCurrentTimer;
    public float turretFillTimer;

    // Start is called before the first frame update
    void Start()
    {
        heal = GetComponent<PlayerHealth>();
        // torretText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        HealMySelf();

        SummonTorret();
        //
        turretFillTimer += Time.deltaTime / 10;
        turretCurrentTimer = Mathf.Clamp(turretCurrentTimer, 0, turretMaxTimer);
        turretButton.fillAmount = turretFillTimer;
        turretButton.color = Color.Lerp(Color.red, Color.green, turretFillTimer);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropLoot")
        {
            dropLootNumber++;      
        }
        else if (other.gameObject.tag == "BossDropLoot")
        {
            dropLootNumber += 5;         
        }
    }
    void HealMySelf()
    {
        if (dropLootNumber >= 5)
        {
            heal.RestoreHealth(healAmount);
            dropLootNumber -= 5;
        }
    }
    public void SummonTorret()
    {

        if (turretFillTimer >= 1)
        {
            turretText.text = "Torret Ready!";
            turretButton.color = Color.green;
        }


        if (turretFillTimer <= 1)
        {
            turretText.text = "Torret Not Ready!";
            turretButton.color = Color.red;
        }

    }
    void TurretDelay()
    {
        callTheSciptThatThrow.ThrowTheTurret();
    }
    void PlayerMoveAndShoot()
    {
        playerMove.enabled = true;
        playerShot.enabled = true;
    }
    public void OnClickButtonTurret()
    {
        if (turretFillTimer >= 1)
        {
            anim.SetTrigger("TurretSummon");

            Invoke("TurretDelay", 2);

            playerMove.enabled = false;
            playerShot.enabled = false;

            Invoke("PlayerMoveAndShoot", 2);

            turretFillTimer = 0f;
        }
    }
}
