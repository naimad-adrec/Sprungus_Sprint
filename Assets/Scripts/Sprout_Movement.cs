using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Sprout_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sp;

    private Vector2 playerInput;
    private Vector2 movement;
    private Vector3Int sproutPosition;

    [SerializeField] private float moveSpeed = 5f;
    private float dirX = 0f;
    private float dirY = 0f;

    [SerializeField] private Tile greenGrass;
    [SerializeField] private Tilemap groundTilemap;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal P1");
        dirY = Input.GetAxisRaw("Vertical P1");
    }

    private void FixedUpdate()
    {
        if (dirX < 0)
        {
            anim.SetInteger("State", 1);
            sp.flipX = false;
        }
        else if (dirX > 0)
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
        movement = new Vector2Int(Mathf.RoundToInt(dirX * moveSpeed * Time.fixedDeltaTime) , Mathf.RoundToInt(dirY * moveSpeed * Time.fixedDeltaTime));
        rb.velocity = movement;
        sproutPosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        Root();
    }

    private void Root()
    {
        groundTilemap.SetTile(sproutPosition, greenGrass);
    }
}
