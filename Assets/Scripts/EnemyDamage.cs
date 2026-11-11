using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damageAmount = 20f; // Cire perdue au contact
    public float knockbackForce = 5f; // Force de repoussement

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerWax playerWax = collision.gameObject.GetComponent<PlayerWax>();

            if (playerWax != null)
            {
                // Applique les dégâts de cire
                playerWax.TakeDamage(damageAmount);

                // Applique le recul au joueur
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}