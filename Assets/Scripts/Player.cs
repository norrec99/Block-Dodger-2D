using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector3 touchPos;

    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Touching the left side of the screen
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed * Time.deltaTime);
            }
            // Touching the right side of the screen
            else
            {
                rb.AddForce(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Block"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartGame();
            }
        }
    }
}
