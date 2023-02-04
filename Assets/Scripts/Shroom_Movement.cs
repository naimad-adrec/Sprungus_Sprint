using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        if (Input.GetKeyDown("up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        if (Input.GetKeyDown("down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
        if (Input.GetKeyDown("right"))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown("left"))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y , transform.position.z);
        }
    }
}


//if (Input.GetKeyDown("up"))
//{
//    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
//}
//if (Input.GetKeyDown("down"))
//{
//    transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
//}
//if (Input.GetKeyDown("right"))
//{
//    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
//}
//if (Input.GetKeyDown("left"))
//{
//    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
//}
