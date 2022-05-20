 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    // text to store the name

    public Text NameText;

    public GameObject GameOverText;

    private bool m_Started = false;

    // storing the rescent points
    private int m_Points;

    private bool m_GameOver = false;

    // new string 
    public string newString;

    // storing the new points
    public static int newPoints;

    // Start is called before the first frame update
    void Start()
    {
        BrickSetup();
    }

    private void Update()
    {
        BallForce();

        // Test new comparing scores 
        CompareScores();
    }

    void AddPoint(int point)
    {
        m_Points += point;
        // assigning new points to 
        newPoints = m_Points;
        //printing the score to equal the points
        //ScoreText.text = $"Score : {m_Points}";

        ScoreText.text = $"Score : {newPoints}";
       
        // running the bestscore function
        BestScoreName();

    }

    // new function to store text 
    public void BestScoreName()
    {

        // print best score 
         NameText.text = " BestScore : " + Singleton.Instance.text + "  :" + Singleton.Instance.bestScore;

        // printing the new new name for reference 
        newString = MenuUI.theName;

        Debug.Log("newer name " + newString);

    }

    public void BrickSetup()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

    }
    public void BallForce()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                // resets the scene run best score name
                BestScoreName();

            }
        }

    }
    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        // saving the text when the game is over 
        Singleton.Instance.SaveText();

    }

    public void CompareScores()
    {
       
        // if  bestscore kept  less than new points 
        if (Singleton.Instance.bestScore < newPoints)
        {
            // reassign the friggin  data variable

            Debug.Log(" old score is less than new one. ");

           // reassign the  text
            Singleton.Instance.text = newString;

            // print to console the result 
            Debug.Log("New name " + Singleton.Instance.text);

            // reassign the points
            Singleton.Instance.bestScore = newPoints;

            Debug.Log("New name " + Singleton.Instance.bestScore);

        }
        else
        {
            NameText.text = " BestScore : " + Singleton.Instance.text + " :"  + Singleton.Instance.bestScore;


        }
    }
}

