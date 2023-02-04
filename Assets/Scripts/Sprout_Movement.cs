using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private Vector2 playerInput;
    private Vector2 movement;

    [SerializeField] private float moveSpeed = 5f;
    private float dirX = 0f;
    private float dirY = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal P1");
        dirY = Input.GetAxisRaw("Vertical P1");
    }

    private void FixedUpdate()
    {
        playerInput = new Vector2(dirX, dirY).normalized;
        movement = new Vector2(playerInput.x * moveSpeed * Time.fixedDeltaTime, playerInput.y * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement;
    }
}
