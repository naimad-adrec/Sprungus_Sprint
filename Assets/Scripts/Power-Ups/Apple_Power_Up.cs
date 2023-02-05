using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Power_Up : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shroom"))
        {
            IsCollected();
        }
    }

    private void IsCollected()
    {
        StartCoroutine(AppleCollectSequence());
    }

    private IEnumerator AppleCollectSequence()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
