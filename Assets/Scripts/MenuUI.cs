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

    //save this so we can pass it into another session
    public string theName;

    public GameObject bestie;

   


    // Start is called before the first frame update
    void Start()
    {
        
        if (inputField != null)
        {
           
            Debug.Log("input exists");
        }
        // wanna load the name if it exists
        Singleton.Instance.LoadText();
        
        // assinging the name if it exists 
        theName = Singleton.Instance.text;

        // input is inputField ,we assign it to theNameString
        //works
        input.GetComponent<InputField>().text = theName;

        // assigning bestScore

        // bestie = "Name : " + Singleton.Instance.text + "  Best" + Singleton.Instance.bestScore;

        bestie.GetComponent<Text>().text = "Name : " + Singleton.Instance.text + "  BestScore : " + Singleton.Instance.bestScore;
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


        // storing the name in the singleton variable.

        Singleton.Instance.text = theName;

       
       // Debug.Log("singleton field " + Singleton.Instance.text);

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
       // MainManager.Instance.SaveColor();
        // if compliled inside the application it will quit when button hit
        // else if the application is built it will exit application if button hit
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
