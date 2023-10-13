using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveScript : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed of the movement.
    public float upDistance = 10.0f; // Adjust the distance the object moves up and down.

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * upDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
