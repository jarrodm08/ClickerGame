using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded = false;
    public bool moveToPointA = false;
    public bool movetoPointB = false;

    private float runningSpeed = 2f;
    public bool isRunning = false;
    private float walkingSpeed = 1f;
    public bool isWalking = false;

    public Animator playerAnimator;

   
    

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        syncAnimations();
        movePlayer();
    }


    public bool moveDB = false;
    public void movePlayer()
    {
        if (moveToPointA == true)
        {
            if (isRunning == true)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.fixedDeltaTime * runningSpeed);
            }
            else if (isWalking == true)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.fixedDeltaTime * walkingSpeed);
            }
        }
        else if (movetoPointB == true)
        {
            Debug.Log("moving to point b");
        }
    }

    private void syncAnimations()
    {
        playerAnimator.SetBool("isRunning",isRunning);
        playerAnimator.SetBool("isWalking", isWalking);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "collision_Ground")
        {
            Debug.Log("Collided with groud collider");
            isGrounded = true;
        }
        if (collision.collider.tag == "collision_PointA")
        {
            moveToPointA = false; // Reached Point A
            isRunning = false;
            isWalking = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "collision_Ground")
        {
            isGrounded = false;
        }
    }
}
