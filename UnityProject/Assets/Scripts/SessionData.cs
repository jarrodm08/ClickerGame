using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public bool dataLoaded = false;
    //Set as default values
    public bool isTutorialFinished = false;
    public int tutorialIndex = 0; // Stage of the tutorial we are at

    void Start()
    {
        PlayerData data = SaveManager.loadPlayer();
        if (data != null)
        {
            isTutorialFinished = data.isTutorialFinished;
            tutorialIndex = data.tutorialIndex;

            dataLoaded = true;
        }
        else
        {
            // Create new player data with the default values
            SaveManager.savePlayerData(this);

            dataLoaded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
