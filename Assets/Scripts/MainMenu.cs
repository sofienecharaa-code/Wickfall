using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Navigation")]
    [Tooltip("Name of the scene loaded when pressing Play")]
    public string gameSceneName = "GameScene";

    [Header("UI Panels")]
    [Tooltip("Reference to the SettingsPanel GameObject inside Canvas")]
    public GameObject settingsPanel;

    [Header("Audio Settings")]
    [Tooltip("Reference to the Volume Slider inside SettingsPanel")]
    public Slider volumeSlider;

    private void Start()
    {
        // Load saved volume preference on start (defaults to 1.0 if never saved)
        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            volumeSlider.value = savedVolume;
            
            // Apply exponential volume response for natural sound scaling
            AudioListener.volume = savedVolume * savedVolume;

            // Wire slider event dynamically as a backup
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        // Ensure settings panel starts hidden
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    // Called by the Main Menu "Play" button
    public void PlayGame()
    {
        Time.timeScale = 1f; // Ensure time scale is active when loading into gameplay
        SceneManager.LoadScene(gameSceneName);
    }

    // Called by the Main Menu "Settings" button
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    // Called by the Settings Panel "Close" button
    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    // Called dynamically by the Volume Slider OnValueChanged event
    public void SetVolume(float volume)
    {
        // Using an exponential curve (volume^2) makes the slider drag feel smooth and natural
        AudioListener.volume = volume * volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Called by the Main Menu "Quit" button
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}