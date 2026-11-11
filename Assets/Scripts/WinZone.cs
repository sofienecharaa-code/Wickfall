using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject winCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("VICTORY! You saved the Candle Golem!");

            if (winCanvas != null)
            {
                winCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Invoke("RestartGame", 2f);
            }
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}