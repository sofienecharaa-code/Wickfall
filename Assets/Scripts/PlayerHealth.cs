using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Paramètres de Cire (Vie)")]
    public float maxWax = 100f;
    public float currentWax;

    [Header("Paramètres d'Éclairage (URP 2D)")]
    public Light2D playerLight;
    public float minLightRadius = 1f;
    public float maxLightRadius = 6f;

    [Header("Interface Utilisateur (UI)")]
    public Slider waxSlider;

    private Rigidbody2D rb;

    void Start()
    {
        currentWax = maxWax;
        rb = GetComponent<Rigidbody2D>();

        // Recherche automatique de la lumière si non assignée
        if (playerLight == null)
        {
            playerLight = GetComponentInChildren<Light2D>();
        }

        // Initialisation de la barre de cire
        if (waxSlider != null)
        {
            waxSlider.maxValue = maxWax;
            waxSlider.value = currentWax;
        }

        UpdateLightAndUI();
    }

    /// <summary>
    /// Applique les dégâts, le recul et met à jour la cire.
    /// </summary>
    public void TakeDamage(float damage, Vector2 enemyPosition)
    {
        currentWax -= damage;
        currentWax = Mathf.Clamp(currentWax, 0, maxWax);

        // Effet de recul (Knockback)
        if (rb != null)
        {
            Vector2 knockbackDirection = (transform.position - (Vector3)enemyPosition).normalized;
            rb.AddForce(knockbackDirection * 4f, ForceMode2D.Impulse);
        }

        UpdateLightAndUI();

        if (currentWax <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Restaure la cire (ex: via un Brasero ou un Pickup).
    /// </summary>
    public void RestoreWax(float amount)
    {
        currentWax += amount;
        currentWax = Mathf.Clamp(currentWax, 0, maxWax);

        UpdateLightAndUI();
    }

    /// <summary>
    /// Ajuste le rayon de lumière et la barre UI selon le niveau de cire.
    /// </summary>
    private void UpdateLightAndUI()
    {
        // 1. Mise à jour de la lumière URP 2D
        if (playerLight != null)
        {
            float waxPercent = currentWax / maxWax;

            // Ajuste le rayon extérieur de la lumière Spot 2D
            playerLight.pointLightOuterRadius = Mathf.Lerp(minLightRadius, maxLightRadius, waxPercent);
            
            // Ajuste l'intensité lumineuse
            playerLight.intensity = Mathf.Lerp(0.3f, 1f, waxPercent);
        }

        // 2. Mise à jour de la barre UI (Slider)
        if (waxSlider != null)
        {
            waxSlider.value = currentWax;
        }
    }

    private void Die()
    {
        Debug.Log("Le Candle Golem a totalement fondu !");
        // Logique de Game Over (ex: recharger la scène ou afficher un écran de défaite)
    }
}