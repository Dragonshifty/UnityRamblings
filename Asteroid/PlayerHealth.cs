using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    [SerializeField] private ScoreSystem scoreSystem;
    public void Crash(){
        scoreSystem.DisplayLivesZero();
        gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
}
