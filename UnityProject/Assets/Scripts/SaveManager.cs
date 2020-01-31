using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void savePlayerData(SessionData sessionData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.anyExtension";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(sessionData);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.anyExtension";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Doesnt exist");
            return null;
        }
    }

    //player = current player normal stuff and data
    // playerData = convert which values we want to save by doing
    // public PlayerData(Player player)
    // set the PLayerData variables by player.[variablename]

    //To save we need to savePlayerData(Player player) to give the current stuff we want to save
    //Do a playerData data = new playerdata(player) in order to get a return of the parsed save data

    //public static playerdata loadplayer()
    //call this method to try and load data, if it doesnt exist throw an error
}

[System.Serializable]
public class PlayerData
{
    public bool isTutorialFinished;
    public int tutorialIndex;
    public float playerDPS;

    //How we save/parse the games data
    public PlayerData(SessionData saveData)
    {
        isTutorialFinished = saveData.isTutorialFinished;
        tutorialIndex = saveData.tutorialIndex;
        playerDPS = saveData.playerDPS;
    }
}