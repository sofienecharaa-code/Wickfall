using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Door opened!");
        gameObject.SetActive(false); // Disables the collider so the player can walk through!
    }
}