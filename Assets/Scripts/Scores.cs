using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
  
    public int currentScore;

    int filescore;

    string[] paths = { "Assets/HighScore.txt", "Assets/HighScore1.txt", "Assets/HighScore2.txt" };

    public Text Score;

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
       
        GetHighScore();

        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    // compares the saved score agianst the currentscore
    void GetHighScore()
    {
        Read();

        if (currentScore > filescore)
        {
            NewHeighScore();

            filescore = currentScore;            
        }

        DisplayScores();

    }
    // saves the current score into the text file
    void NewHeighScore()
    {      
        StreamWriter sw = new StreamWriter(paths[currentLevel]);
    
        string storeText = currentScore.ToString();

        sw.WriteLine(storeText);

        sw.Close();
    }
    void DisplayScores()
    {
        Debug.Log("Your score is "+ currentScore);

        Debug.Log("The high score is " + filescore);
    }
    void Read()
    {
        String path = paths[currentLevel];
        StreamReader reader = new StreamReader(path);
        string loadScore = reader.ReadLine();
        filescore = int.Parse(loadScore);
        reader.Close();        

    }

}
