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

    //UI variables

    [SerializeField] private Slider waterSlider;

    //Vector variables

    private Vector2 playerInput;
    private Vector2 movement;
    private Vector3Int shroomPosition;

    //Movement variables

    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private float noWaterMoveSpeed = 150f;
    [SerializeField] private float waterDrainRate = 0.075f;
    private float currentMoveSpeed;
    private float dirX = 0f;
    private float dirY = 0f;

    //Tilemap variables

    [SerializeField] private Tile purpleGrass;
    [SerializeField] private Tilemap groundTilemap;

    //Power-up variables

    [SerializeField] private int fertPowerUpTime = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        currentMoveSpeed = moveSpeed;
    }

    //Get user input

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal P2");
        dirY = Input.GetAxisRaw("Vertical P2");
    }

    private void FixedUpdate()
    {
        //Change animation state upon user input

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

        //update movement

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized;
        movement = new Vector2Int(Mathf.RoundToInt(dirX * currentMoveSpeed * Time.fixedDeltaTime), Mathf.RoundToInt(dirY * currentMoveSpeed * Time.fixedDeltaTime));
        rb.velocity = movement;

        //Drain water rate and half speed if water meter is empty

        if ((rb.velocity.x != 0) || (rb.velocity.y != 0))
        {
            waterSlider.value -= waterDrainRate / 30f;
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

    //player collides with water source

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shroom_Water"))
        {
            waterSlider.value = 1f;
        }
    }

    //player collides with power-up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fert"))
        {
            StartCoroutine(FertPowerUp());
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            waterSlider.value = 1f;
        }
    }

    private IEnumerator FertPowerUp()
    {
        waterDrainRate = 0f;
        yield return new WaitForSeconds(fertPowerUpTime);
        waterDrainRate = 0.075f;
    }
}
