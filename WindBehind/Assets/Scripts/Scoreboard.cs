using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
