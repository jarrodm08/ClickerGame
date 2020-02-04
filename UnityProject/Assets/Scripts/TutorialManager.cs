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

    private bool atkDB = false;
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
                player.GetComponent<Player>().moveDB = false;
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
                dialogueText.text = "Let's spawn our first enemy and show you the rest of the UI'";

                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 10)
            {
                gameLoader.gameObject.GetComponent<BattleManager>().spawnMonster();

                if (gameLoader.gameObject.GetComponent<BattleManager>().activeMonster !=  null)
                {
                    GameObject monster = gameLoader.gameObject.GetComponent<BattleManager>().activeMonster;
                    if (monster.GetComponent<Monster>().isGrounded == true)
                    {
                        if (monster.GetComponent<Monster>().moveDB == false)
                        {
                            monster.GetComponent<Monster>().moveDB = true;
                            monster.GetComponent<Monster>().moveToPointA = true;
                        }

                       
                        if (monster.GetComponent<Monster>().moveToPointA == false)
                        {
                            dialogueText.text = "Here you'll find the monster's health.";
                            toggleDialogue();

                            gameLoader.gameObject.GetComponent<BattleManager>().eHealthBar.SetActive(true);
                            toggleContinue();
                        }
                    }  
                }
            }
            else if (tutorialIndex == 11)
            {
                dialogueText.text = "Here you'll find how much progress you've made on this current stage";
                toggleDialogue();

                gameLoader.gameObject.GetComponent<BattleManager>().eMonsterCounter.SetActive(true);
                toggleContinue();
            }
            else if (tutorialIndex == 12)
            {
                dialogueText.text = "Let's walk up to him and show him whos boss ";
                toggleDialogue();
                toggleContinue();
            }
            else if (tutorialIndex == 13)
            {
                if (player.GetComponent<Player>().moveDB == false)
                {
                    player.GetComponent<Player>().moveDB = true;
                    player.GetComponent<Player>().moveToPointB = true;
                    player.GetComponent<Player>().isRunning = true; // *** Change to isWalking for slower movement/animation ****
                    //player.GetComponent<Player>().isWalking = true;
                }

                if (player.GetComponent<Player>().moveToPointB == false)
                {
                    dialogueText.text = "Lets kick some butt";
                    toggleDialogue();
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 14)
            {
               
                if (atkDB == false)
                {
                    atkDB = true;
                    player.GetComponent<Player>().attack();
                }
               
                if (GameObject.FindObjectOfType<BattleManager>().monsterCurrentHP == 9)
                {
                    dialogueText.text = "Great job! Keep going until his health reaches zero!";
                    toggleDialogue();
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 15)
            {
                if (atkDB == true)
                {
                    if (player.GetComponent<Player>().swingDB == false)
                    {
                        player.GetComponent<Player>().attack();
                    }

                    if (GameObject.FindObjectOfType<BattleManager>().monsterCurrentHP == 0)
                    {
                        dialogueText.text = "Oh look! A coin! Let's click on it to pick it up";
                        toggleDialogue();
                        if (GameObject.FindObjectOfType<BattleManager>().currentCoins >= 1)
                        {
                            dialogueText.text = "Great! Now lets spend it to increase your damage!";
                            toggleContinue();
                        }
                    }
                }
                
            }
            else if (tutorialIndex == 16)
            {
                dialogueText.text = "Click the red tab to open up your player upgrades";
                toggleDialogue();
                bool setDB = false;
                if (setDB == false)
                {
                    setDB = true;
                    GameObject.FindObjectOfType<GameLoader>().panelBtnList[0].GetComponent<Button>().onClick.AddListener(GameObject.FindObjectOfType<GameLoader>().togglePlayerUpgrades);
                }
                if (GameObject.FindObjectOfType<GameLoader>().playerUpgradesTab.activeSelf == true)
                {
                    dialogueText.text = "Now buy the upgrade";
                }
            }
            else if (tutorialIndex == 17)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 18)
            {
                dialogueText.text = "placeholderText";
                toggleDialogue();

                if (1 + 1 == 2)
                {
                    toggleContinue();
                }
            }
            else if (tutorialIndex == 19)
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
