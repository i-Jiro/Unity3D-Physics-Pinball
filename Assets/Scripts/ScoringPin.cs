using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPin : MonoBehaviour
{
    public int points = 100;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            _gameManager.UpdateScore(points);
        }
    }
}
