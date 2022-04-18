using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public Animator anim;
    public float moveSpeed;
    public Rigidbody rb;

    public float hoz;
    public float ver;
    

    // Start is called before the first frame update
    void Start()
    {
        moveJoystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveJoystick();
        Animatingg();
    }
    void MoveJoystick()
    {
        hoz = moveJoystick.Horizontal;
        ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        transform.Translate(direction * moveSpeed, Space.World);
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }
   
    public void Animatingg()
    {
        anim.SetBool("Walking", IsMovingg());
    }
    public bool IsMovingg()
    {
        return hoz != 0f || ver != 0f;
    }
}
