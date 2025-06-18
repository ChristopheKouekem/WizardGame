using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Gegner : MonoBehaviour
{
    public GameObject Player;
    public int weight = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 3 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feuerball"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<Player>().stats.currentHealth -= 10;
            Destroy(gameObject);
        }

    }
}
