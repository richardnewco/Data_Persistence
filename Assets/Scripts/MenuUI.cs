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
    // text fields
    // gettng ref to the inputField
    public GameObject inputField;
    //save this so we can pass it into another session
    public string theName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    // text Input function
    public void ReadInput()
    {
        // having the name = input text 
        theName = inputField.GetComponent<Text>().text;

        Debug.Log(theName);

        // saving the name sos that we can use in another session


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
