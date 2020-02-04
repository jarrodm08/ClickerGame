using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{

    private GameObject monsterSpawnPoint;
    private GameObject monsterPrefab;

    public GameObject activeMonster;
    public GameObject eHealthBar;
    public GameObject eMonsterCounter;
    public GameObject backgroundScene;
    public TextMeshProUGUI displayHP;
    public GameObject healthBarSlider;
    public float monsterCurrentHP = 10;
    public float monsterMaxHP = 10;
    public TextMeshProUGUI displayCoins;
    public float currentCoins = 0;

    public Sprite monsterDeathSprite;

    // Start is called before the first frame update
    void Start()
    {
        monsterSpawnPoint = this.GetComponent<GameLoader>().monsterSpawnPoint;
        monsterPrefab = this.GetComponent<GameLoader>().monsterPrefab;
    }

    private GameObject coinActive;
    // Update is called once per frame
    private bool coinDB = false;
    void Update()
    {
        displayHP.text = "HP: " + monsterCurrentHP;
        displayCoins.text = "" + currentCoins;

        if (monsterCurrentHP == 0)
        {
            activeMonster.GetComponent<Image>().sprite = monsterDeathSprite;
            activeMonster.GetComponent<Image>().CrossFadeAlpha(0f,1f,false); // fade out
            if (coinActive == null && coinDB == false)
            {
                coinDB = true;
                GameObject newCoin = Instantiate(this.gameObject.GetComponent<GameLoader>().coinPrefab, activeMonster.transform.position, activeMonster.transform.rotation, backgroundScene.transform);
                coinActive = newCoin;
                newCoin.gameObject.GetComponent<Button>().onClick.AddListener(pickupCoin);
            }
        }
    }

    private bool spawnDB = false;
    public void spawnMonster()
    {
        if (spawnDB == false)
        {
            spawnDB = true;
            GameObject monster = Instantiate(monsterPrefab, monsterSpawnPoint.transform.position, monsterSpawnPoint.transform.rotation, monsterSpawnPoint.transform);
            activeMonster = monster;
        }
    }

    public void pickupCoin()
    {
        coinActive.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        currentCoins += 1;
        Destroy(coinActive);
        coinActive = null;
    }
}
