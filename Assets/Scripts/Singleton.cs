using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// namespace for the  UI text
using UnityEngine.UI;
// namespace for Json writing files.
using System.IO;

public class Singleton : MonoBehaviour
{
    //accessable on any script with the instance

    public static Singleton Instance;

    //getting ref to the text
    public string text;


    private void Awake()
    {
        // if this  already exists
        if (Instance != null)
        {
            Destroy(gameObject);
            // return to game
            return;
        }
        else
        {
            // use this instance
            Instance = this;
            // dont destroy this
            DontDestroyOnLoad(gameObject);


        }
    }

    class SaveData
    {
        // variable to store the text
        // sending this data to mainmanager
        public string text;
    }
    /// saving the json data


    // saving the color to the json format .
    public void SaveText()
    {
        // making an instance of the class SaveData and assigning a new variable called data
        SaveData data = new SaveData();

        // assigning the text this new data variable 
        data.text = text;

        // making a json string to hold  this new variable called  data 
        string json = JsonUtility.ToJson(data);

        //saving this data to json format string 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    // loading the saved color reversal of the save color
    public void LoadText()
    {
        // getting reference to previously savefile.json
        string path = Application.persistentDataPath + "/savefile.json";

        // checking if file exists if not nothing happens
        if (File.Exists(path))
        {
            // read file 
            string json = File.ReadAllText(path);

            // transforming from json to unity variable
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // setting the team color to the new saved  color
            text = data.text;
        }




    }
}
