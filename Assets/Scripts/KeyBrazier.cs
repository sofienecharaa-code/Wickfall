using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBrazier : MonoBehaviour
{
    [Header("Door to Unlock")]
    public Door doorToOpen;

    private bool isLit = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLit && other.CompareTag("Player"))
        {
            isLit = true;
            Debug.Log("Master Brazier Lit! Opening Door...");

            if (doorToOpen != null)
            {
                doorToOpen.OpenDoor();
            }
        }
    }
}