using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    private bool isDead;
    public float health;
    private float lerpTimer; 
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    private PlayerMovment playerMovement;
    private RayFireMouse BulletRayCastShooter;
    public Rigidbody rb;

    public Image frontHealtBar;
    public Image backHealtBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerMovement = GetComponent<PlayerMovment>();
        BulletRayCastShooter = GameObject.Find("BulletRayCastShooter").GetComponent<RayFireMouse>();      
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealth();
        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(Random.Range(5, 10));
        }
       
    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(Random.Range(5, 10));
        }
    }   
    public void UpdateHealth()
    {
        float fillF = frontHealtBar.fillAmount;
        float fillB = backHealtBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealtBar.fillAmount = hFraction;
            backHealtBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float precentComplete = lerpTimer / chipSpeed;
            precentComplete = precentComplete * precentComplete;
            backHealtBar.fillAmount = Mathf.Lerp(fillB, hFraction, precentComplete);
        }
        if (fillF < hFraction)
        {
            backHealtBar.fillAmount = hFraction;
            backHealtBar.color = Color.green;          
            lerpTimer += Time.deltaTime;
            float precentComplete = lerpTimer / chipSpeed;
            precentComplete = precentComplete * precentComplete;
            frontHealtBar.fillAmount = Mathf.Lerp(fillF, backHealtBar.fillAmount, precentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
            playerMovement.enabled = false;
            BulletRayCastShooter.enabled = false;     
            rb.constraints = RigidbodyConstraints.FreezeAll;  
        }
    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
}
