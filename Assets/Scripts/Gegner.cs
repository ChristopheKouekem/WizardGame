using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Gegner : MonoBehaviour
{
    public GameObject Player;
    public GameObject Feuerball;
    public float Cooldown = 3f;
    private float Timer = 0f;

    private Vector3 richtung = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 3 * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer >= Cooldown)
        {
            Schiessen();
            Timer = 0f;
        }
    }



    void Schiessen()
    {
        GameObject feuerball = Instantiate(Feuerball, transform.position + richtung * 2f, Quaternion.identity);

        if (richtung == Vector3.up) feuerball.transform.eulerAngles = new Vector3(0, 0, 90);
        else if (richtung == Vector3.down) feuerball.transform.eulerAngles = new Vector3(0, 0, 270);
        else if (richtung == Vector3.left) feuerball.transform.eulerAngles = new Vector3(0, 0, 180);
        else if (richtung == Vector3.right) feuerball.transform.eulerAngles = new Vector3(0, 0, 0);
        else if (richtung == (Vector3.up + Vector3.right).normalized) feuerball.transform.eulerAngles = new Vector3(0, 0, 45);
        else if (richtung == (Vector3.up + Vector3.left).normalized) feuerball.transform.eulerAngles = new Vector3(0, 0, 135);
        else if (richtung == (Vector3.down + Vector3.right).normalized) feuerball.transform.eulerAngles = new Vector3(0, 0, -45);
        else if (richtung == (Vector3.down + Vector3.left).normalized) feuerball.transform.eulerAngles = new Vector3(0, 0, 225);
        feuerball.GetComponent<Fireball>().SetDirection(richtung);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feuerball"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            UI.score += 100;
        }
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<Player>().stats.currentHealth -= 10;
            Destroy(gameObject);
            UI.score -= 100;
        }
    }
}
