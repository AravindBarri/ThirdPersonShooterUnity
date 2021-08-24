using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int health = 0;
    public Text ScoreUI;
    public Text HealthUI;
    public static ScoreManager Scoreinstance;
    private void Start()
    {
        Scoreinstance = this;
    }
    public void CoinScore()
    {
        score++;
        ScoreUI.text = "Score: " + score;
    }
    public void BottleScore()
    {
        health = health + 5;
        HealthUI.text = "Health: " + health;
    }
    public void EnemyKillScore()
    {
        score+=5;
        ScoreUI.text = "Score: " + score;
    }
}