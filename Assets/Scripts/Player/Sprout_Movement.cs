using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Sprout_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sp;
    private AudioSource audio;
    public Shroom_Movement shroom;

    //UI variables
    [SerializeField] private Slider waterSlider;

    //vector variables
    private Vector2 playerInput;
    public Vector2 movement;
    private Vector3Int sproutPosition;
    [SerializeField] private Vector3 originalSpawnPosition = new Vector3(-9.5f, 0, 0);

    //move speed variables
    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private float noWaterMoveSpeed = 150f;
    [SerializeField] private float waterDrainRate = 0.075f;
    private float currentMoveSpeed;
    private float dirX = 0f;
    private float dirY = 0f;

    //tilemap variables
    [SerializeField] private Tile greenGrass;
    [SerializeField] private Tilemap groundTilemap;

    //power up variables
    [SerializeField] private int fertPowerUpTime = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        currentMoveSpeed = moveSpeed;
    }

    //Recieve Player Input
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal P1");
        dirY = Input.GetAxisRaw("Vertical P1");
    }

    private void FixedUpdate()
    {
        //Change Animation State depending on direction
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

        //Update Velocity and movement

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized;
        movement = new Vector2Int(Mathf.RoundToInt(dirX * currentMoveSpeed * Time.fixedDeltaTime) , Mathf.RoundToInt(dirY * currentMoveSpeed * Time.fixedDeltaTime));
        rb.velocity = movement;

        //Drain water rate and half speed if water meter is empty

        if ((rb.velocity.x != 0) || (rb.velocity.y != 0))
        {
            waterSlider.value -= waterDrainRate/30f;
        }
        if (waterSlider.value <= 0f)
        {
            currentMoveSpeed = noWaterMoveSpeed ;
        }
        if (waterSlider.value > 0f)
        {
            currentMoveSpeed = moveSpeed;
        }

        //Draw plant tile over current tile
        sproutPosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        Root();
    }

    private void Root()
    {
        groundTilemap.SetTile(sproutPosition, greenGrass);       
    }

    //player collides with water source
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sprout_Water"))
        {
            waterSlider.value = 1f;
        }
        if (collision.gameObject.CompareTag("Shroom") && shroom.big == true)
        {
            Debug.Log("Spawn");
            transform.position = originalSpawnPosition;
            shroom.big = false;
        }
    }

    //when player collides with powerups
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
        if (collision.gameObject.CompareTag("Bee"))
        {
            audio.Play();
        }
    }

    //Set drain rate to zero for certain amount of time
    private IEnumerator FertPowerUp()
    {
        waterDrainRate = 0f;
        yield return new WaitForSeconds(fertPowerUpTime);
        waterDrainRate = 0.075f;
    }
}
