using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CountingScoreScript : MonoBehaviour
{
    public UnityEngine.UI.Text ScoreText;
    public UnityEngine.UI.Text HighScoreText;

    int Score = 0;
    public int HighScore;

    public static CountingScoreScript instance;

    public int IncrementScore(int addition)
    {
        Score += addition;
        ScoreText.text = "Score: " + Score;
        return Score;
    }

    private void Update()
    {
        StreamReader read = new StreamReader(SaveHighScoreScript.playerDataPath);
        HighScore = int.Parse(read.ReadToEnd());
        read.Close();
        HighScoreText.text = "High score: " + HighScore;
    }

    
    // Start is called before the first frame update
    void Start()
    {
       instance = (this);
    }
}