using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    //accessable on any script with the instance

    public static Singleton Instance;

    //getting ref to the text
    public Text text;


    private void Awake()
    {
        // if this  already exists
        if(Instance != null)
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
        // variable to store the color
        public Text text;
    }


}
