using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreLabel;

    private void Update()
    {
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score++;
    }

}
