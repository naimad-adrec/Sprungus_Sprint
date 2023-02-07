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

    private Vector2 beeMovement;
    private Vector3Int beePosition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprout"))
        {
            beeMovement = new Vector2(Random.Range(5, 10), Random.Range(5, 10));
            rb.velocity = beeMovement;
            audio.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
