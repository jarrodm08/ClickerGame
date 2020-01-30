using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        print("IM AWAKE");
        DontDestroyOnLoad(transform.gameObject);
        return;
    }
}
