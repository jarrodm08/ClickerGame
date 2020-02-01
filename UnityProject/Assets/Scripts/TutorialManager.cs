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
    public GameLoader gameLoader;
    //---------//

    // Private//
    private string advisorName = "Timothy";
    private TextMeshProUGUI advisorNameText;
    private TextMeshProUGUI dialogueText;
    private GameObject continueDialogueBtn;
    //--------//

    void Start()
    {
        gameLoader = GameObject.FindObjectOfType<GameLoader>();
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
                eDialogue.SetActive(false); // hide dialogue
                Debug.Log("Hiding dialogue");
            }
            else
            {
                eDialogue.SetActive(true); // show dialogue             
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
        if (tutorialReady == true && player.GetComponent<Player>().isGrounded == true && tutorialDB != true)
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
            else if (tutorialIndex == 3)
            {
                GameObject.FindObjectOfType<GameLoader>().btnContainer.SetActive(true);
                dialogueText.text = "Here are a list of four panels, though only two of them have been implemented.";
                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 4)
            {
                gameLoader.panelBtnList[0].transform.Find("icon").GetComponent<Image>().sprite = gameLoader.panelBtnSprites[1];
                gameLoader.panelBtnList[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                dialogueText.text = "This panel is where you can find your player upgrades that effect your character directly.";

                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 5)
            {
                gameLoader.panelBtnList[0].GetComponent<Image>().color = new Color32(115, 115, 115, 115); //temporarily revert the 1st buttons color
                gameLoader.panelBtnList[1].transform.Find("icon").GetComponent<Image>().sprite = gameLoader.panelBtnSprites[2];
                gameLoader.panelBtnList[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                dialogueText.text = "This panel is where you can find upgrades relating to your sidekicks";
                
                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 6)
            {
                gameLoader.panelBtnList[1].GetComponent<Image>().color = new Color32(115, 115, 115, 115); //temporarily revert the 1st buttons color
                gameLoader.panelBtnList[2].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                gameLoader.panelBtnList[3].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                dialogueText.text = "These panels have not been implemented yet, but keep an eye out for when they do!";

                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 7)
            {
                gameLoader.panelBtnList[2].GetComponent<Image>().color = new Color32(115, 115, 115, 115);
                gameLoader.panelBtnList[3].GetComponent<Image>().color = new Color32(115, 115, 115, 115);
                gameLoader.panelBtnList[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                gameLoader.panelBtnList[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                dialogueText.text = "Now lets move on";

                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 8)
            {
                gameLoader.dpsContainer.SetActive(true);          
                dialogueText.text = "Here you can find how much damage your player is dealing per second, also known as 'DPS'";

                toggleDialogue();
                toggleContinue();
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

    void testme()
    {
        Debug.Log("WOrked");
    }
}
