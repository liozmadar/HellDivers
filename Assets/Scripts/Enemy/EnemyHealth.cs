using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
   // public TextMeshProUGUI enemyFloatingText;
    public Image backhealthbar;
    public Image healthBar;
    public Animator anim;
    //
    public int enemyGetHit;
    private float sinkSpeed = 1f;
    public int startHealth = 100;
    public int currentHealth;
    public bool isSinking;
    public bool monsterDeath = false;

    NavMeshAgent nav;
    EnemyMovment enemyMove;
    EnemyDmg enemyDmg;
    public Rigidbody rb;

    public GameObject dropLootSpawn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startHealth;
        nav = GetComponent<NavMeshAgent>();
        enemyMove = GetComponent<EnemyMovment>();
        enemyDmg = GetComponent<EnemyDmg>();
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "BulletMissile")
        {
            enemyGetHit = Random.Range(10, 20);
            currentHealth -= enemyGetHit;
            Destroy(other.gameObject);
            healthBar.fillAmount -= enemyGetHit / 100f;
          //  enemyFloatingText.text = currentHealth.ToString();

            if (currentHealth > 0)
            {
                Invoke("EnemyTextRest", 2f);
            }
            
            if (currentHealth <= 0 && !monsterDeath)
            {
                monsterDeath = true;
                anim.SetTrigger("MonsterDead");
                nav.enabled = false;
                enemyMove.enabled = false;
                enemyDmg.enabled = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                gameObject.tag = "Untagged";

                Instantiate(dropLootSpawn, transform.position, Quaternion.identity);

                Invoke("StartSinking", 2f);
                Destroy(healthBar);
                Destroy(backhealthbar);
            }
        }
    }
    /*void EnemyTextRest()
    {
        enemyFloatingText.text = "";
    }*/
    void StartSinking()
    {
        isSinking = true; 
    }
}
