using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private TMP_Text livesText;
    private float score;
    private bool isScoring = true;
    void Update()
    {
        if (!isScoring) {return;}
        score += Time.deltaTime * scoreMultiplier;
        
        scoreText.text = Mathf.FloorToInt(score).ToString();
        livesText.text = $"Lives: {Asteroid.lives.ToString()}";
    }

    public int PauseScore(){
        isScoring = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }

    public void DisplayLivesZero(){
        livesText.text = "0";
    }
}
