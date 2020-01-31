using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    // Public //
    public GameObject eDialogue;
    public bool tutorialReady = false;
    public int tutorialIndex;
    public GameObject player;
    //---------//

    // Private//
    private string advisorName = "Timothy";
    private TextMeshProUGUI advisorNameText;
    private TextMeshProUGUI dialogueText;
    private GameObject continueDialogueBtn;
    //--------//

    void Start()
    {
        eDialogue = GameObject.FindObjectOfType<GameLoader>().eDialogue;

        //Setup Dialogue Stuff//
        advisorNameText = GameObject.FindObjectOfType<GameLoader>().advisorNameText;
        advisorNameText.text = advisorName + ":";
        dialogueText = GameObject.FindObjectOfType<GameLoader>().dialogueText;
        continueDialogueBtn = GameObject.FindObjectOfType<GameLoader>().continueDialogueBtn;
        continueDialogueBtn.GetComponent<Button>().onClick.AddListener(continueTutorial);
        //----------------//


        tutorialIndex = GameObject.FindObjectOfType<GameLoader>().GetComponent<SessionData>().tutorialIndex; // Load saved data containing tutorial stage
    }


    void Update()
    {
        tutorialState();
    }

    private bool tutorialDB = false;
    public void continueTutorial()
    {
        if (tutorialDB == false)
        {
            tutorialDB = true;
            tutorialIndex++; // Stopts previous stage check

            dialogueDB = false;
            toggleDialogue(true);
            

            continueDB = false;
            toggleContinue(true);

            //Close off debounce
            tutorialDB = false;
        }
    }

    //Visibility Toggles
    private bool dialogueDB = false;
    private void toggleDialogue(bool closeDB = false)
    {
        if (dialogueDB == false)
        {
            dialogueDB = true; // Sets Debounce

            if (eDialogue.activeSelf == true)
            {
                eDialogue.SetActive(false); // show dialogue
                Debug.Log("Hide dialogue");
            }
            else
            {
                eDialogue.SetActive(true); // show dialogue
                Debug.Log("Show dialogue ");
            }

            if (closeDB == true)
            {
                dialogueDB = false;
            }
        }
    }

    private bool continueDB = false;
    private void toggleContinue(bool closeDB = false)
    {
        if (continueDB == false)
        {
            continueDB = true;

            if (continueDialogueBtn.activeSelf == false)
            {
                continueDialogueBtn.SetActive(true);
            }
            else
            {
                continueDialogueBtn.SetActive(false);
            }

            if (closeDB == true)
            {
                continueDB = false;
            }
        }
    }

    private void tutorialState()
    {
        if (tutorialReady == true && GameObject.FindObjectOfType<Player>().isGrounded == true && tutorialDB != true)
        {
            if (tutorialIndex == 0)
            {
                dialogueText.text = "Welcome stranger! My name is " + advisorName + "."; // Set text to display
                toggleDialogue(); // Display the text
                //Allow player to continue tutorial, put inside an if statement to require a condition(s) to be met first
                toggleContinue(); 
            }
            else if (tutorialIndex == 1)
            {
                if (player.GetComponent<Player>().moveDB == false)
                {
                    player.GetComponent<Player>().moveDB = true;
                    player.GetComponent<Player>().moveToPointA = true;
                    player.GetComponent<Player>().isRunning = true; // *** Change to isWalking for slower movement/animation ****
                    //player.GetComponent<Player>().isWalking = true;
                }

                if (player.GetComponent<Player>().moveToPointA == false)
                {
                    dialogueText.text = "Aha! There you are! For a second I was worried you got lost...";
                    toggleDialogue();
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 2)
            {
                dialogueText.text = "Let's introduce you to some of the game's mechanics";
                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex ==3)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 4)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 5)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 6)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 7)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 8)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 9)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 10)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
        }
    }
}
