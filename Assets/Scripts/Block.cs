using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer objectSpriteRenderer;

    private void Start()
    {
        // Get the main camera and the object's renderer
        mainCamera = Camera.main;
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the screen's bottom border
        if (viewportPosition.y < 0f)
        {
            Destroy(gameObject);
        }
    }
}
