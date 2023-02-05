using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fert_Power_Up : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprout") || collision.gameObject.CompareTag("Shroom"))
        {
            IsCollected();
        }
    }

    private void IsCollected()
    {
        StartCoroutine(FertCollectSequence());
    }

    private IEnumerator FertCollectSequence()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
