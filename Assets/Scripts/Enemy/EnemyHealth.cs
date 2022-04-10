using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public GameObject floatingTextPrefab;
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

            if (currentHealth > 0)
            {
                FloatingText();
            }
            
            if (currentHealth < 0 && !monsterDeath)
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
            }
        }
    }
    void FloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = currentHealth.ToString();
    }
    void StartSinking()
    {
        isSinking = true; 
    }
}
