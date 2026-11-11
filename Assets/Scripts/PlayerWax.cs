using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerWax : MonoBehaviour
{
    [Header("Wax Settings")]
    public float maxWax = 100f;
    public float currentWax = 100f;
    public float baseMeltRate = 5f;
    public float darknessMeltMultiplier = 2.5f;

    private bool isInSafeZone = false;

    [Header("Invincibility Settings")]
    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    [Header("UI & Light Settings")]
    public Slider waxSlider;
    public Light2D playerLight;
    public float maxLightRadius = 6f;
    public float minLightRadius = 0.5f;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    void Start()
    {
        currentWax = maxWax;
        if (waxSlider != null)
        {
            waxSlider.maxValue = maxWax;
            waxSlider.value = currentWax;
        }
        if (playerLight == null) playerLight = GetComponent<Light2D>();
        UpdateLightAndUI();
    }

    void Update()
    {
        Melt();
    }

    void Melt()
    {
        if (currentWax > 0)
        {
            float currentMeltRate = isInSafeZone ? baseMeltRate : (baseMeltRate * darknessMeltMultiplier);
            
            currentWax -= currentMeltRate * Time.deltaTime;
            currentWax = Mathf.Clamp(currentWax, 0, maxWax);

            UpdateLightAndUI();
        }
        else
        {
            Die();
        }
    }

    public void SetInSafeZone(bool safe)
    {
        isInSafeZone = safe;
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible) return;

        currentWax -= damage;
        currentWax = Mathf.Clamp(currentWax, 0, maxWax);

        UpdateLightAndUI();

        if (currentWax <= 0) Die();
        else StartCoroutine(InvincibilityRoutine());
    }

    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    public void RefillWax(float amount)
    {
        currentWax = Mathf.Min(currentWax + amount, maxWax);
        UpdateLightAndUI();
    }

    private void UpdateLightAndUI()
    {
        if (waxSlider != null) waxSlider.value = currentWax;

        if (playerLight != null)
        {
            float waxPercent = currentWax / maxWax;
            playerLight.pointLightOuterRadius = Mathf.Lerp(minLightRadius, maxLightRadius, waxPercent);
        }
    }

    void Die()
    {
        Debug.Log("Le Golem a complètement fondu !");
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}