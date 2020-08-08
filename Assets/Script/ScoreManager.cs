using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private Text scoreLavel;

    // Start is called before the first frame update
    void Start()
    {
        scoreLavel = GetComponent<Text>();
        scoreLavel.text = "SCORE" + score;

    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreLavel.text = "SCORE"+ score;
    }
}