using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveController
{
    public static void SaveData(bool trueorfalse)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerData.DTZ";
        FileStream stream = new FileStream(path, FileMode.Create);

        //data is where you have all the data you want stored, wether its a class of data or whatnot
        saveData data = new saveData(trueorfalse);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved data " + data);
    }


    public static saveData LoadData()
    {
        string path = Application.persistentDataPath + "/PlayerData.DTZ";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveData data = formatter.Deserialize(stream) as saveData;
            stream.Close();
            Debug.Log("Loaded data " + data.myBool);
            return data;
        }
        else
        {
            Debug.Log("File not found at: " + path);
            return null;
        }
    }
    
}

[System.Serializable]
public class saveData
{
    // The data you want stored
    public bool myBool;
    public int myInt;
    public string myString;

    //REAL DATA VARIABLES
    public int tutorialStage; // 0,1,2,3,4,5 | x = tutorial is finished

    //-------------------


    // the constructor that parses the data we feed it to store data properly
    public saveData(bool trueorfalse)
    {
        myBool = trueorfalse;
    }


}
