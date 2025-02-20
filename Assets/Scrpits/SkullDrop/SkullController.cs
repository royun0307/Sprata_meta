using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    SkullGenerator SkullGenerator;

    private void Awake()
    {
        SkullGenerator = FindObjectOfType<SkullGenerator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SkullGenerator.GameOver();
        }
        Destroy(this.gameObject);
    }
}
