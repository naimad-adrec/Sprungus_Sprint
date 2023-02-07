using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bee_Power_Up : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public Sprout_Movement sprout;
    private AudioSource audio;


    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tile greenGrass;

    private Vector2 beeMovement;
    private Vector3Int beePosition;

    private bool beeCollected = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        beePosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        if(beeCollected == true)
        {
            Root();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprout"))
        {
            beeMovement = new Vector2(Random.Range(5, 10), Random.Range(5, 10));
            rb.velocity = beeMovement;
            beeCollected = true;
            audio.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Root()
    {
        groundTilemap.SetTile(beePosition, greenGrass);
    }
}
