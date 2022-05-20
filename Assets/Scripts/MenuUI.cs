using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using scenemangement for changing scenes
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//new namespace for accessing the build or the unity version of the application

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
   
    // gettng ref to the inputField
    public GameObject inputField;

    // getting the inputfield variable 
     public InputField input;

    //save this name  so we can pass it into another session
    public  static string theName;

   //  gameobject to use for text field for the name and best score
    public GameObject bestie;
   
    // the best score 
    public int score;

   
    // Start is called before the first frame update
    void Start()
    {   
        if (inputField != null)
        {
           
            Debug.Log("input exists");
        }
        // loading name and text 
        Singleton.Instance.LoadText();
        
        // assinging the name if it exists 
        theName = Singleton.Instance.text;

        // input is inputField ,we assign it to theNameString
        //works
        input.GetComponent<InputField>().text = theName;

        // assigning bestScore

        bestie.GetComponent<Text>().text = "  BestScore :  " + Singleton.Instance.text + ": " + Singleton.Instance.bestScore;
    }
    

    // Update is called once per frame
    void Update()
    {

    }
    // text Input function called on the text input field
    public void ReadInput()
    {
        
        // having the name = input text 
        theName = inputField.GetComponent<Text>().text;

        //STORING THE OLD POINTS 
        MainManager.newPoints = Singleton.Instance.bestScore;

        Debug.Log("number" + MainManager.newPoints);

        //THE OLD NAME
       
        Debug.Log("old name " + Singleton.Instance.text);

        // THE NEW NAME
        Debug.Log("new name  " + theName);

    }

    public void StartGame()
    {
        // when start button pressed load scene one
        
        SceneManager.LoadScene(1);
        
    }

    public void QuitGame()
    {
        // quit the game if the unity  is running or the app.

        SceneManager.LoadScene(0);
        // if application run

    }
    public void Exit()
    {
        // saving the color on exit
       // MainManager.Instance.SaveText();
        // if compliled inside the application it will quit when button hit
        // else if the application is built it will exit application if button hit
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
