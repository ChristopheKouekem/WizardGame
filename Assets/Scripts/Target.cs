using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feuerball"))
        {
            Destroy(collision.gameObject);
            NeuesTarget();
        }
    }

    void NeuesTarget()
    {
        float newX, newY;

        do
        {
            newX = Random.Range(-12, 12);
            newY = Random.Range(-6, 6);
        } while (transform.position.x == newX || transform.position.y == newY);
        transform.position = new Vector3(newX, newY, 0);
        UI.score += 100;
    }

}

