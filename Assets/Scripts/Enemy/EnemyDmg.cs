using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    public Animator anim;

    public GameObject player;
    public PlayerHealth playerHealth;
    public float Damage = 10f;
    public float timeBetweenAttacks = 0.5f;

    private bool playerInRange;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();        
        }
    }
    void Attack()
    {
        timer = 0f;
        if (playerHealth.health > 0)
        {
            playerHealth.TakeDamage(Damage);
            anim.SetTrigger("Attack");
            anim.SetTrigger("Stab Attack");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
}
