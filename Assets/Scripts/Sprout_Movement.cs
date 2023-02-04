using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Sprout_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private Slider waterSlider;

    private Vector2 playerInput;
    private Vector2 movement;
    private Vector3Int sproutPosition;

    [SerializeField] private float currentMoveSpeed = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float noWaterMoveSpeed = 2.5f;
    private float dirX = 0f;
    private float dirY = 0f;
    private float waterLevel = 1f;

    [SerializeField] private Tile greenGrass;
    [SerializeField] private Tilemap groundTilemap;

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
        playerInput = new Vector2(playerInput.x, playerInput.y).normalized;
        movement = new Vector2Int(Mathf.RoundToInt(dirX * currentMoveSpeed * Time.fixedDeltaTime) , Mathf.RoundToInt(dirY * currentMoveSpeed * Time.fixedDeltaTime));
        rb.velocity = movement;
        if ((rb.velocity.x != 0) || (rb.velocity.y != 0))
        {
            waterSlider.value -= .075f/30f;
        }
        if (waterSlider.value <= 0f)
        {
            currentMoveSpeed = noWaterMoveSpeed ;
        }
        if (waterSlider.value > 0f)
        {
            currentMoveSpeed = moveSpeed;
        }

        sproutPosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        Root();

        //if (Input.GetKeyDown("k"))
        //{
        //    waterSlider.value = 0f;
        //}
    }

    private void Root()
    {
        groundTilemap.SetTile(sproutPosition, greenGrass);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Running");
        if (collision.gameObject.CompareTag("Sprout_Water"))
        {
            waterSlider.value = 1f;
            Debug.Log("Touvhin");
        }
    }
}
