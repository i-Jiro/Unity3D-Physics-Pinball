using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHole : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdateLives(-1);
        }
    }
}
