using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Drag your Player object here

    [Header("Follow Settings")]
    public float smoothSpeed = 5f; // Higher values = faster camera response
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keeps camera backed up on Z axis

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current position and target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply position
        transform.position = smoothedPosition;
    }
}