using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public bool gameLoading = false;
    public GameObject tutorialManagerPrefab;

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
        Debug.Log("Loading game now");
        // SPAWN PLAYER

        
        
        
        //


        if (this.GetComponent<SessionData>().isTutorialFinished == true)
        {
            // Load NORMAL game
        }
        else if (this.GetComponent<SessionData>().isTutorialFinished == false)
        {
            // Load tutorial
            GameObject tutorialManager = Instantiate(tutorialManagerPrefab,transform.parent.Find("Canvas"));
            tutorialManager.GetComponent<TutorialManager>().startTutorial();
            
        }


    }
}
