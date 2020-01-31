using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public bool gameLoading = false;
    public GameObject playerSpawnPoint;

    //PREFABS-----//
    public GameObject tutorialManagerPrefab;
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
            tutorialManager.GetComponent<TutorialManager>().startTutorial();
            
        }


    }
}
