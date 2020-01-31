using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public bool gameLoading = false;
    // Start is called before the first frame update
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

        if (this.GetComponent<SessionData>().isTutorialFinished == true)
        {
            // Load NORMAL game
        }
        else if (this.GetComponent<SessionData>().isTutorialFinished == false)
        {
            // Load tutorial
            Debug.Log("Start tutrial now");
        }
    }
}
