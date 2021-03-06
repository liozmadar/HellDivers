using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShotJoystick : MonoBehaviour
{
    public Animator anim;
    public FixedJoystick lookJoystick;
    public PlayerMovment playerKeyMove;
    public PlayerMoveJoystick playerJoystickMove;
   
    public float lookSpeed;

    public BulletSpawnShooter bulletsShoot;
    private float shootTimer = 0.1f;

    public float LookHor;
    public float LookVer;


    private void Start()
    {
       // moveJoystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FixedJoystick>();
        lookJoystick = GameObject.FindGameObjectWithTag("LookJoystick").GetComponent<FixedJoystick>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootTimer -= Time.deltaTime;
       // MoveJoystick();
        LookJoystick();
    }
    public void LookJoystick()
    {
        if (lookJoystick.Horizontal !=0 && lookJoystick.Vertical !=0 || Input.GetKey(KeyCode.Y))
        {

            LookHor = lookJoystick.Horizontal;
            LookVer = lookJoystick.Vertical;
            Vector3 direction = new Vector3(LookHor, 0, LookVer).normalized;
            transform.Translate(direction * lookSpeed, Space.World);
            Vector3 lookAtPosition = transform.position + direction;
            transform.LookAt(lookAtPosition);

            if (playerKeyMove.IsMoving() || playerJoystickMove.IsMovingg())
            {               
                anim.SetBool("IdleShooting", false);
            }
            else
            {
                
                anim.SetBool("IdleShooting", true);
            }  
            if (shootTimer < 0)
            {
                bulletsShoot.BulletShooter();
                shootTimer = 0.15f;
            }       
        }
        else
        {
            anim.SetBool("IdleShooting", false);
        }
        
    }
   /* void MoveJoystick()
    {        
            float hoz = moveJoystick.Horizontal;
            float ver = moveJoystick.Vertical;
            Vector3 direction = new Vector3(hoz, 0, ver).normalized;
            transform.Translate(direction * moveSpeed, Space.World);
    }*/
}