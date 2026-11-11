using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        // Force le temps du jeu à tourner normalement dès le chargement de la scène
        Time.timeScale = 1f;
    }

    /// <summary>
    /// À appeler depuis l'événement OnClick() du bouton RestartButton
    /// </summary>
    public void RestartGame()
    {
        // S'assure que le jeu n'est pas en pause au rechargement
        Time.timeScale = 1f;

        // Recharge la scène actuelle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// À appeler quand le joueur meurt
    /// </summary>
    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Met le jeu en pause lors de la défaite
        Time.timeScale = 0f;
    }
}