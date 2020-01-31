using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameLoader : MonoBehaviour
{
    public bool gameLoading = false;
    public GameObject playerSpawnPoint;
    //Tutorial Stuff//
    public GameObject eDialogue;
    public GameObject tutorialManagerPrefab;
    public GameObject continueDialogueBtn;
    public TextMeshProUGUI advisorNameText;
    public TextMeshProUGUI dialogueText;
    //--------------//






    //PREFABS-----//

    public GameObject playerPrefab;
    //------------//


    void Start()
    {
        
    }

    void Update()
    {
        
        if (this.GetComponent<SessionData>().dataLoaded == true)
        {
            if (gameLoading == false)
            {
                loadGame();
            }
        }
    }

    public void loadGame()
    {
        gameLoading = true;
        //Spawn Player
        GameObject player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation, playerSpawnPoint.transform);

        //Load Normal Game |OR| Load Tutorial
        if (this.GetComponent<SessionData>().isTutorialFinished == true)
        { //Normal Game
            
        }
        else if (this.GetComponent<SessionData>().isTutorialFinished == false)
        { //Tutorial
            
            GameObject tutorialManager = Instantiate(tutorialManagerPrefab,transform.parent.Find("Canvas"));
            tutorialManager.GetComponent<TutorialManager>().tutorialReady = true;
        }
    }
}
