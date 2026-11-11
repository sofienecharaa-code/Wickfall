using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerWax player = other.GetComponent<PlayerWax>();
            if (player != null) player.SetInSafeZone(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerWax player = other.GetComponent<PlayerWax>();
            if (player != null) player.SetInSafeZone(false);
        }
    }
}
