using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool isGrounded = false;
    public bool moveToPointA = false;
    public bool moveToPointB = false;

    private float runningSpeed = 2f;
    public bool isRunning = false;
    private float walkingSpeed = 1f;
    public bool isWalking = false;
    public bool isBattleReady = false;
    public bool attackSwing = false;

    public Animator playerAnimator;
    public float playerDPS = 1f;
    public float playerLevel = 1;

    private BattleManager battleManager;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();

        battleManager = GameObject.FindObjectOfType<BattleManager>().GetComponent<BattleManager>();
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
        else if (moveToPointB == true)
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
    }
    
    private void syncAnimations()
    {
        playerAnimator.SetBool("isRunning",isRunning);
        playerAnimator.SetBool("isWalking", isWalking);
        playerAnimator.SetBool("isBattleReady", isBattleReady);
        
        
        //playerAnimator.SetBool("attackSwing", attackSwing);
    }
    public bool swingDB = false;
    public void attack()
    {
        if (swingDB == false && battleManager.monsterCurrentHP >= 1)
        {
            swingDB = true;
            playerAnimator.Play("player_attackSwing");
            Invoke("attackSuccess",1f);
        }
        else
        {
           
        }
    }

    public void attackSuccess()
    {
        battleManager.healthBarSlider.transform.localScale -= new Vector3((playerDPS/battleManager.monsterMaxHP),0f,0f);
        battleManager.monsterCurrentHP -= playerDPS;
        swingDB = false;
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
            collision.gameObject.SetActive(false);
        }
        if (collision.collider.tag == "collision_PointB")
        {
            moveToPointB = false; // Reached Point A
            isRunning = false;
            isWalking = false;
            isBattleReady = true;
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
