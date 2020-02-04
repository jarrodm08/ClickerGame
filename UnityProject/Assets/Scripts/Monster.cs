using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool isGrounded = false;
    public float monsterSpeed = 1f;

    public bool moveToPointA = false;
    public bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveMonster(); 
    }

    public bool moveDB = false;
    public void moveMonster()
    {
        if (isGrounded == true)
        {
            if (moveToPointA == true)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.fixedDeltaTime * monsterSpeed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "collision_Ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "collision_PointB")
        {
            Debug.Log("PointBCOllider");
            moveToPointA = false;
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
