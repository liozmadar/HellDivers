using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    public Transform lookAtPlayer;   
    NavMeshAgent nav;
    //  
    // Start is called before the first frame update
    void Start()
    {
        lookAtPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(lookAtPlayer.position);

        float Distance = Vector3.Distance(lookAtPlayer.transform.position, gameObject.transform.position);            
    }
}
