using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float rotationSpeed;
    //
    Vector3 movement;
    public Rigidbody rb;
    private int floorMask;

    public float moveX;
    public float moveY;
   // private float camRayLength = 100f;
    // Start is called before the first frame update
    void Start()
    {
        floorMask = LayerMask.GetMask("GroundFloor");
    }    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Move();
       // Turning();
        Animating();
    }
    

    void Move()
    {
        movement.Set(moveX, 0f, moveY);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        Vector3 lookAtPosition = transform.position + movement;
        transform.LookAt(lookAtPosition);

    }
   /* void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay,out floorHit,camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }*/
    public void Animating()
    {     
        anim.SetBool("Walking", IsMoving());
    }
    public bool IsMoving()
    {
         return moveX != 0f || moveY != 0f;
    }
}
