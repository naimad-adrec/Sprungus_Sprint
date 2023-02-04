using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Movement : MonoBehaviour
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
        dirX = Input.GetAxisRaw("Horizontal P2");
        dirY = Input.GetAxisRaw("Vertical P2");
    }

    private void FixedUpdate()
    {
        playerInput = new Vector2(playerInput.x, playerInput.y).normalized;
        movement = new Vector2(dirX * moveSpeed * Time.fixedDeltaTime, dirY * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement;
    }
}
