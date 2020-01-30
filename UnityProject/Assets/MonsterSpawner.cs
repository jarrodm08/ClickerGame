using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterA_Prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMonster()
    {
        Instantiate(MonsterA_Prefab,transform.position, transform.rotation,transform);
    }
}
