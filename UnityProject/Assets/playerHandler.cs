using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{
    public bool isGrounded = false;
    public bool isBattleReady = false;


    public bool isRunning = false;
    public bool battleStanceActive = false;

    public Animator playerAnimator;


    void Start()
    {
        //Transform monsterHealthBar = transform.parent.transform.Find("Healthbar").transform.Find("Bar") ;
        //monsterHealthBar.localScale = new Vector3(.5f, 1f);

        //SaveController.SaveData(true);
        

        //saveData savedData = SaveController.LoadData();
       // print(savedData);

    }

    void Update()
    {
        //playerAnimator.SetBool("isRunning", isRunning);
        //playerAnimator.SetBool("battleStanceActive", battleStanceActive);
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
