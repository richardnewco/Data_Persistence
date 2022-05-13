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

    // creating the bestScore int

    public int bestScore ;


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

        public int bestScore;
    }
    /// saving the json data


    // saving the text to the json format .
    public void SaveText()
    {
        // making an instance of the class SaveData and assigning a new variable called data
        SaveData data = new SaveData();


        // assigning the text this new data variable 
        data.text = text;
        //assigning the bestsore to data
        data.bestScore = bestScore;

       
        // print to console text when saved in the main manager exit game
        Debug.Log("print " + data.text);

        //saving the bestscore too
        Debug.Log("print " + data.bestScore);



        // making a json string to hold  this new variable called  data 
        string json = JsonUtility.ToJson(data);

        // testing the string
        Debug.Log(json);

        //saving this data to json format string 
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }


    // loading the saved color reversal of the save color
    public void LoadText()
    {
        // getting reference to previously savefile.json
        string path = Application.dataPath + "/saveFile.json";

        // checking if file exists if not nothing happens
        if (File.Exists(path))
        {
            // read file 
            string json = File.ReadAllText(path);

            // transforming from json to unity variable
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // setting the text to the new saved  text
            text = data.text;

            //setting the best score 
           
            bestScore = data.bestScore;

            // text 
            Singleton.Instance.text = text;

            //score
            Singleton.Instance.bestScore = bestScore;

            // testing to see if text works

             Debug.Log( Singleton.Instance.text);

            //testing to see if the score works
            Debug.Log(Singleton.Instance.bestScore);

        }




    }
}
