using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pifall_Powerup : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int pitfallPowerUpTime = 5;

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
        StartCoroutine(PitfallCollectSequence());
    }

    private IEnumerator PitfallCollectSequence()
    {
        
        yield return new WaitForSeconds(pitfallPowerUpTime);
        Destroy(gameObject);
    }
}
