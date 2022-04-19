using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLootFollow : MonoBehaviour
{
    public GameObject player;
    public float minModifier = 20f;
    public float maxModifier = 30f;  

    private bool isFollowing;

    Vector3 _velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("DropLootTargetOnPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref _velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));        
        }      
    }
    public void StartFollowing()
    {
        isFollowing = true;
    }   
}
