using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackWaxCost = 10f; // Coût en cire pour attaquer
    public float attackRadius = 2.5f; // Rayon de l'attaque
    public LayerMask enemyLayer;     // Layer des ennemis

    private PlayerWax playerWax;

    void Start()
    {
        playerWax = GetComponent<PlayerWax>();
    }

    void Update()
    {
        // Touche ESPACE pour attaquer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformLightBurst();
        }
    }

    void PerformLightBurst()
    {
        // Vérifie si le joueur a assez de cire pour attaquer
        if (playerWax != null && playerWax.currentWax > attackWaxCost)
        {
            // Consomme la cire
            playerWax.TakeDamage(attackWaxCost);

            // Détecte les ennemis aux alentours
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                // Détruit ou blesse l'ennemi
                Destroy(enemy.gameObject);
                Debug.Log("Ennemi d'Ombre détruit par la lumière !");
            }
        }
    }

    // Visualiser la portée de l'attaque dans l'éditeur
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}