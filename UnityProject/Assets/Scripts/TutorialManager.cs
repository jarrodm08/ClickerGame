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


        tutorialIndex = GameObject.FindObjectOfType<GameLoader>().GetComponent<SessionData>().tutorialIndex;
    }


    void Update()
    {
       
        //Track and do stages of the tutorial
        tutorialState();
        //Tracks and handles visability control of the dialogue box
        //dialogueVisability();
        //Tracks and handles visability control of the continue dialogue button
        //continueDialogueVisibility();
    }



    // Tracks and handles visability control of the dialogue box
    private bool openDialogue = false;
    private void dialogueVisability()
    {
        if (openDialogue == true)
        {
            eDialogue.SetActive(true);
        }
        else
        {
            eDialogue.SetActive(false);
        }
    }

    // Tracks and handles visability control of the continue dialogue button
    private bool dialogueFinished = false;
    private void continueDialogueVisibility()
    {
        if (dialogueFinished == true)
        {
            continueDialogueBtn.SetActive(true);
        }
        else 
        {
            continueDialogueBtn.SetActive(false);
        }
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

                toggleContinue(); //Allow player to continue tutorial once a condition is met, or, continue without conditions for continued dialogue like this stage
            }
            else if (tutorialIndex == 1)
            {
                dialogueText.text = "Press left arrow to continue";
                toggleDialogue(); // show dialogue

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 2)
            {
                dialogueText.text = "Press right arrow to continue";
                toggleDialogue(); // show dialogue

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    toggleContinue();
                }
            }
        }
    }
}
