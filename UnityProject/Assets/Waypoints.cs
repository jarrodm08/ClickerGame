using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    // Game States
    public bool isGrounded = false;
    public bool isBattleReady = false;

    //Animation States
    public Animator playerAnimations;

    public bool isIdle = true;
    public bool isRunning = false;

    //----------------------------





    public bool startRunning; 

    

    void Start()
    {

    }

    void Update()
    {
        animationUpdate();
        animationControl();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "collision_Ground")
        {
            isGrounded = true;
        }

        if (collision.collider.tag == "collision_Monster")
        {
            isBattleReady = true;
            battleAnimation();
        }
    }

    void animationUpdate()
    {
        playerAnimations.SetBool("isGrounded", isGrounded);
        playerAnimations.SetBool("isBattleReady", isBattleReady);


        playerAnimations.SetBool("isRunning", isRunning);
        playerAnimations.SetBool("isIdle", isIdle);  
    }

    void animationControl()
    {
        if (isGrounded == true)
        {
            if (isIdle == true && isRunning == false)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    isRunning = true;
                    isIdle = false;

                    //Begin running animation
                    playerAnimations.SetBool("isRunning", isRunning);
                }
            }

            if(isRunning == true && isBattleReady == false)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
            }

        }
    }
    int atkState = 0;
    void battleAnimation()
    {
        isRunning = false;
       

        if(atkState == 0)
        {
            atkState = 1;
            playerAnimations.SetInteger("atkState", atkState);
            InvokeRepeating("battleAnimation", 6f, 6f);
        }
        else
        {
            atkState = 0;
        }

        


    }

    //gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right* Time.fixedDeltaTime);
}
