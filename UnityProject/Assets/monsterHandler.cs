using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHandler : MonoBehaviour
{

    private bool isGrounded = false;
    public bool isBattleReady = false;
    public Animator monsterAnimator;

    public GameObject activeMonster;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            if (isBattleReady == false )
            {
                monsterAnimator.SetBool("isWalking", true);
                gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.fixedDeltaTime);
            }
            else
            {
                monsterAnimator.SetBool("isWalking", false);
            }
        }
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
        }
    }
}
