using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Shroom_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sp;
    [SerializeField] private Slider waterSlider;

    private Vector2 playerInput;
    private Vector2 movement;
    private Vector3Int shroomPosition;

    private float currentMoveSpeed;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float noWaterMoveSpeed = 2.5f;
    private float dirX = 0f;
    private float dirY = 0f;
    private float waterLevel = 1f;

    [SerializeField] private Tile purpleGrass;
    [SerializeField] private Tilemap groundTilemap;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal P2");
        dirY = Input.GetAxisRaw("Vertical P2");
    }

    private void FixedUpdate()
    {
        if (dirX < 0)
        {
            anim.SetInteger("State", 1);
            sp.flipX = false;
        }
        else if(dirX > 0)
        {
            anim.SetInteger("State", 1);
            sp.flipX = true;
        }
        else if (dirY < 0)
        {
            anim.SetInteger("State", 3);
        }
        else if (dirY > 0)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 0);
        }

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized;
        movement = new Vector2Int(Mathf.RoundToInt(dirX * currentMoveSpeed * Time.fixedDeltaTime), Mathf.RoundToInt(dirY * currentMoveSpeed * Time.fixedDeltaTime));
        rb.velocity = movement;

        if ((rb.velocity.x != 0) || (rb.velocity.y != 0))
        {
            waterSlider.value -= .075f / 30f;
        }
        if (waterSlider.value == 0f)
        {
            currentMoveSpeed = noWaterMoveSpeed;
        }
        if (waterSlider.value > 0f)
        {
            currentMoveSpeed = moveSpeed;
        }
        shroomPosition = new Vector3Int (Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        Root();
    }

    private void Root()
    {
        groundTilemap.SetTile(shroomPosition, purpleGrass);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Running");
        if (collision.gameObject.CompareTag("Shroom_Water"))
        {
            waterSlider.value = 1f;
            Debug.Log("Touvhin");
        }
    }
}
