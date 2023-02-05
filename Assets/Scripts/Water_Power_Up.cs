using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Power_Up : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprout") || collision.gameObject.CompareTag("Shroom"))
        {
            Destroy(gameObject);
        }
    }
}
