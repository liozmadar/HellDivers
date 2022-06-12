using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemyCanvas;
    public Image backhealthbar;
    public Image healthBar;
    public Animator anim;
    //
    private int enemyGetHit;
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

    public SpaceShip numberOfKills;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startHealth;
        nav = GetComponent<NavMeshAgent>();
        enemyMove = GetComponent<EnemyMovment>();
        enemyDmg = GetComponent<EnemyDmg>();
        rb = GetComponent<Rigidbody>();
        numberOfKills = GameObject.FindObjectOfType<SpaceShip>();
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
            if (!monsterDeath)
            {
                enemyCanvas.SetActive(true);
            }
               
            enemyGetHit = Random.Range(20, 30);
            if (other.gameObject.tag == "BulletMissile")
            {
                enemyGetHit = Random.Range(50, 100);
            }
            currentHealth -= enemyGetHit;
            Destroy(other.gameObject);
            if (startHealth == 300)
            {
                healthBar.fillAmount -= enemyGetHit / 300f;
            }
            if (startHealth == 100)
            {
                healthBar.fillAmount -= enemyGetHit / 100f;
            }
            

            if (currentHealth > 0)
            {
                Invoke("HideHealth", 3f);
            }
            
            if (currentHealth <= 0 && !monsterDeath)
            {
                numberOfKills.numberOfKills++;

                monsterDeath = true;
                anim.SetTrigger("MonsterDead");
                anim.SetTrigger("Die");
                nav.enabled = false;
                enemyMove.enabled = false;
                enemyDmg.enabled = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                gameObject.tag = "Untagged";

                Instantiate(dropLootSpawn, transform.position, Quaternion.identity);

                Invoke("StartSinking", 2f);
                Destroy(enemyCanvas);               
            }
        }
    }
    void HideHealth()
    {
        if (!monsterDeath)
        {
            enemyCanvas.SetActive(false);
        }     
    }
    void StartSinking()
    {
        isSinking = true;
        Invoke("DestroyMonsterAfterDeath", 2f);
    }
    void DestroyMonsterAfterDeath()
    {
        Destroy(gameObject);
    }
}
