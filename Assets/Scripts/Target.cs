using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feuerball"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if ()
        {

        }
    }
}

