using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int totalScore = 0;
    public bool isGameActive = false;
    public int pinballsActive = 0;
    [SerializeField] GameObject pinBallSpawnPosition;
    [SerializeField] GameObject pinBallPrefab;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _livesText;

    void Start()
    {
        isGameActive = true;
        UpdateScore(0);
        UpdateLives(0);
    }

    void Update()
    {
        pinballsActive = FindObjectsOfType<Pinball>().Length;
        if(pinballsActive == 0 && lives > 0 && isGameActive)
        {
            Instantiate(pinBallPrefab, pinBallSpawnPosition.transform.position, pinBallPrefab.transform.rotation);
        }

        if(lives == 0)
        {
            isGameActive = false;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        _scoreText.SetText("Score: " + totalScore);
    }

    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd;
        _livesText.SetText("Lives: " + lives);
    }
}
