using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorialPanel;
    public GameObject tutorialText;
    public GameObject dialogueButton;

    public Text displayText;

    public bool tutorialActive = false;
    public bool dialogueBtn = false;
    private bool continueDialogue = false;

    private bool startWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        displayText = tutorialText.GetComponent<Text>();
       if(tutorialActive == false)
        {
            tutorialActive = true;
            StartCoroutine(startTutorial());
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBtn == true)
        {
            dialogueButton.SetActive(true);
        }
        else
        {
            dialogueButton.SetActive(false);
        }

        if (player.GetComponent<playerHandler>().isGrounded == true && startWalk == true && player.GetComponent<playerHandler>().isBattleReady==false)
        {
            player.GetComponent<playerHandler>().isRunning = true;
            player.gameObject.GetComponent<Rigidbody2D>().MovePosition(player.transform.position + player.transform.right * Time.fixedDeltaTime);
        }
        else if(player.GetComponent<playerHandler>().isBattleReady == true)
        {
            player.GetComponent<playerHandler>().isRunning = false;
            player.GetComponent<playerHandler>().battleStanceActive = true;
        }

    }

    IEnumerator startTutorial()
    {
        string advisorName = "Tom";

        //Wait until player has fully loaded and colided with ground
        yield return new WaitUntil(() => player.GetComponent<playerHandler>().isGrounded == true);
        tutorialPanel.SetActive(true);
        displayText.text = "Welcome stranger! My name is " + advisorName + ".";
        dialogueBtn = true;
        yield return new WaitUntil(() => continueDialogue == true);

        //
        continueDialogue = false;
        dialogueBtn = false;
        displayText.text = "Let's get you acclimated to the mechanics. Click continue to spawn a new enemy";
        dialogueBtn = true;
        yield return new WaitUntil(() => continueDialogue == true);

       //Spawn Monster and wait for arrival
        continueDialogue = false;
        dialogueBtn = false;
        displayText.text = "Lets wait for him to arrive...";
        FindObjectOfType<MonsterSpawner>().spawnMonster();
        yield return new WaitUntil(() => FindObjectOfType<monsterHandler>().isBattleReady == true);
        dialogueBtn = true;
        yield return new WaitUntil(() => continueDialogue == true);

        //
        continueDialogue = false;
        dialogueBtn = false;
        displayText.text = "Wowza! He's a big one! Lets walk up to him and show him who's boss!";
        dialogueBtn = true;
        yield return new WaitUntil(() => continueDialogue == true);

        // Start walking upto monster
        continueDialogue = false;
        dialogueBtn = false;
        startWalk = true;
        yield return new WaitUntil(() => FindObjectOfType<playerHandler>().battleStanceActive == true);

        // Introduce enemy HP
        continueDialogue = false;
        dialogueBtn = false;
        displayText.text = "Great! Here is where we can find the monster's current HP.";
        dialogueBtn = true;
        yield return new WaitUntil(() => continueDialogue == true);
    }


    public void continueTutorial()
    {
        continueDialogue = true;
    }
}
