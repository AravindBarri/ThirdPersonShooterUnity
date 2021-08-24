using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int health = 0;
    public Text ScoreText;
    public Text HealthText;
    public void CoinScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }
    public void BottleScore()
    {
        health = health + 5;
        HealthText.text = "Health: " + health;
    }
}