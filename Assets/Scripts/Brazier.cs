using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{
    [Header("Brazier Settings")]
    public float refillAmountPerSecond = 20f; // Cire redonnée par seconde

    private void OnTriggerStay2D(Collider2D other)
    {
        // Vérifie si l'objet qui entre dans le cercle est le joueur
        if (other.CompareTag("Player"))
        {
            PlayerWax playerWax = other.GetComponent<PlayerWax>();
            if (playerWax != null)
            {
                playerWax.RefillWax(refillAmountPerSecond * Time.deltaTime);
            }
        }
    }
}