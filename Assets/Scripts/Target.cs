using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector2 respawnRangeMin = new Vector2(-1, -1);
    public Vector2 respawnRangeMax = new Vector2(1, 1);

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
        float newX = Random.Range(respawnRangeMin.x, respawnRangeMax.x);
        float newY = Random.Range(respawnRangeMin.y, respawnRangeMax.y);
        transform.position = new Vector2(newX, newY);
    }


}

