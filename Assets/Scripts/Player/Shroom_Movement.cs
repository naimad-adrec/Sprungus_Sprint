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
    private AudioSource audio;

    //UI variables

    [SerializeField] private Slider waterSlider;

    //Vector variables

    private Vector2 playerInput;
    private Vector2 movement;
    private Vector3Int shroomPosition;
    [SerializeField] private Vector3 originalSpawnPosition = new Vector3(9.5f, 0, 0);

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
    [SerializeField] private int applePowerUpTime = 5;
    public bool big;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        currentMoveSpeed = moveSpeed;
        big = false;
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
        if (big == false)
        {
            groundTilemap.SetTile(new Vector3Int(shroomPosition.x, shroomPosition.y, shroomPosition.z), purpleGrass);
        }

        if (big == true)
        {
            groundTilemap.SetTile(new Vector3Int(shroomPosition.x, shroomPosition.y - 1, shroomPosition.z), purpleGrass);
            groundTilemap.SetTile(new Vector3Int(shroomPosition.x -1 , shroomPosition.y - 1, shroomPosition.z), purpleGrass);
            groundTilemap.SetTile(new Vector3Int(shroomPosition.x - 1, shroomPosition.y, shroomPosition.z), purpleGrass);
            groundTilemap.SetTile(new Vector3Int(shroomPosition.x, shroomPosition.y, shroomPosition.z), purpleGrass);
        }
    }

    //player collides with water source

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shroom_Water"))
        {
            waterSlider.value = 1f;
        }
        if (collision.gameObject.CompareTag("Sprout"))
        {
            transform.localScale = new Vector3(1, 1, transform.localScale.z);
        }
    }

    //player collides with power-up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fert"))
        {
            audio.Play();
            StartCoroutine(FertPowerUp());
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            audio.Play();
            waterSlider.value = 1f;
        }
        if (collision.gameObject.CompareTag("Apple"))
        {
            audio.Play();
            transform.localScale = new Vector3(2, 2, transform.localScale.z);
            big = true;
            StartCoroutine(ApplePowerUp());
        }
        if (collision.gameObject.CompareTag("Bee"))
        {
            transform.position = originalSpawnPosition;
            big = false;
        }
    }

    private IEnumerator FertPowerUp()
    {
        waterDrainRate = 0f;
        yield return new WaitForSeconds(fertPowerUpTime);
        waterDrainRate = 0.075f;
    }

    private IEnumerator ApplePowerUp()
    {
        yield return new WaitForSeconds(applePowerUpTime);
        transform.localScale = new Vector3(1, 1, transform.localScale.z);
        big = false;
    }
}