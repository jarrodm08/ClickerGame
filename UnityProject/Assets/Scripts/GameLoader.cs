using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameLoader : MonoBehaviour
{
    //Tutorial Stuff//
    public GameObject eDialogue;
    public GameObject tutorialManagerPrefab;
    public GameObject continueDialogueBtn;
    public TextMeshProUGUI advisorNameText;
    public TextMeshProUGUI dialogueText;
    //--------------//

    public bool gameLoading = false;
    public GameObject playerSpawnPoint;

    //Panel Buttons //
    public List<GameObject> panelBtnList;
    public List<Sprite> panelBtnSprites;
    public GameObject btnContainer;
    //--------------//

    public GameObject dpsContainer;
    public TextMeshProUGUI dpsText;

    //PREFABS-----//
    public GameObject playerPrefab;
    //------------//


    void Start()
    {
       // panelBtnList[0].transform.Find("icon").gameObject.GetComponent<Image>().sprite = panelBtnSprites[0];
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
            Debug.Log("Load normal game");
        }
        else if (this.GetComponent<SessionData>().isTutorialFinished == false)
        { //Tutorial
            
            GameObject tutorialManager = Instantiate(tutorialManagerPrefab,transform.parent.Find("Canvas"));
            tutorialManager.GetComponent<TutorialManager>().tutorialReady = true;
            tutorialManager.GetComponent<TutorialManager>().player = player;
            Debug.Log("Load tutorial game");
        }
    }
}
