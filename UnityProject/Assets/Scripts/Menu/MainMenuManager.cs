using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    
    void Start()
    {
        //Spawn Clouds Continuously
        InvokeRepeating("spawnCloud",0,cloudSpeed);
    }

    void Update()
    {
        //Handle Movement of clouds
        moveCloud();
    }

    public void playButton()
    {
        //change scene to the scene indexed after this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        Debug.Log("QUITTING");
        Application.Quit();
    }





    public float cloudSpeed = 10f;
    public GameObject[] cloudSpawns;
    public Sprite[] cloudSprites;
    public GameObject cloudPrefab;
    public GameObject cloudCollider;
    private Dictionary<GameObject, Transform> cloudDic = new Dictionary<GameObject, Transform>();
    private int cloudNum = 0;
    public void spawnCloud()
    {
        if (cloudNum == 0)
        {
            GameObject newCloud = Instantiate(cloudPrefab,cloudSpawns[1].transform);
            newCloud.GetComponent<Image>().sprite = cloudSprites[0];
            cloudDic.Add(newCloud,cloudSpawns[1].transform);
            cloudNum += 1;
        }
        else if (cloudNum == 1)
        {
            GameObject newCloud = Instantiate(cloudPrefab, cloudSpawns[0].transform);
            newCloud.GetComponent<Image>().sprite = cloudSprites[1];
            cloudDic.Add(newCloud, cloudSpawns[0].transform);
            cloudNum += 1;
        }
        else if (cloudNum == 2)
        {
            GameObject newCloud = Instantiate(cloudPrefab, cloudSpawns[1].transform);
            newCloud.GetComponent<Image>().sprite = cloudSprites[3];
            cloudDic.Add(newCloud, cloudSpawns[1].transform);
            cloudNum += 1;
        }
        else if (cloudNum == 3)
        {
            GameObject newCloud = Instantiate(cloudPrefab, cloudSpawns[0].transform);
            newCloud.GetComponent<Image>().sprite = cloudSprites[2];
            cloudDic.Add(newCloud, cloudSpawns[0].transform);
            cloudNum = 0;
        }
    }

    public void moveCloud()
    {
        foreach (KeyValuePair<GameObject,Transform> p in cloudDic)
        {
            Vector3 movement = new Vector3(p.Value.position.x,0f,0f);
            p.Key.transform.position -= movement * Time.deltaTime / cloudSpeed;
        }

        if (cloudCollider.GetComponent<CloudCollider>().collidedCloud != null)
        {
            cloudDic.Remove(cloudCollider.GetComponent<CloudCollider>().collidedCloud);
            Destroy(cloudCollider.GetComponent<CloudCollider>().collidedCloud);
        }
    }
}
