using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Paramètres de Déplacement")]
    public float moveSpeed = 3f;
    public float detectionRange = 8f;
    public float stopDistance = 0.5f;

    [Header("Délai de Démarrage")]
    public float startDelay = 3f; // Temps d'attente en secondes avant de démarrer
    private float delayTimer = 0f;

    [Header("Composants")]
    private Transform playerTransform;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (rb != null)
        {
            rb.freezeRotation = true;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }

        // Initialise le délai
        delayTimer = startDelay;
    }

    void Update()
    {
        // Réduit le chrono du délai s'il n'est pas encore écoulé
        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
            return; // Bloque l'orientation et la poursuite tant que le chrono tourne
        }

        if (playerTransform == null) return;

        // Orienter le Sprite vers le joueur
        if (playerTransform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerTransform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // Si le délai de démarrage n'est pas terminé, l'ennemi reste immobile
        if (delayTimer > 0f || playerTransform == null)
        {
            rb.velocity = Vector2.zero;
            if (animator != null)
            {
                animator.SetBool("IsWalking", false);
            }
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        // Déplacement après la fin du délai
        if (distanceToPlayer <= detectionRange && distanceToPlayer > stopDistance)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (animator != null)
            {
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

            if (animator != null)
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}