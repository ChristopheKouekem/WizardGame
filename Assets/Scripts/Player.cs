using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 richtung = Vector3.right;

    public WizardClass stats;

    void Start()
    {
        stats.currentMana = stats.maxMana;
        stats.currentHealth = stats.maxHealth;
    }

    void Update()
    {
        float geschw = stats.movementSpeed * Time.deltaTime;

        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) input += Vector3.up;
        if (Input.GetKey(KeyCode.S)) input += Vector3.down;
        if (Input.GetKey(KeyCode.A)) input += Vector3.left;
        if (Input.GetKey(KeyCode.D)) input += Vector3.right;

        if (input != Vector3.zero) richtung = input.normalized;

        transform.position += input.normalized * geschw;

        if (stats.currentMana >= 10)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
            {
                GameObject Feuerball = Instantiate(prefab, transform.position + richtung * 1.0f, Quaternion.identity);

                if (richtung == Vector3.up) Feuerball.transform.eulerAngles = new Vector3(0, 0, 90);
                else if (richtung == Vector3.down) Feuerball.transform.eulerAngles = new Vector3(0, 0, 270);
                else if (richtung == Vector3.left) Feuerball.transform.eulerAngles = new Vector3(0, 0, 180);
                else if (richtung == Vector3.right) Feuerball.transform.eulerAngles = new Vector3(0, 0, 0);
                else if (richtung == (Vector3.up + Vector3.right).normalized) Feuerball.transform.eulerAngles = new Vector3(0, 0, 45);
                else if (richtung == (Vector3.up + Vector3.left).normalized) Feuerball.transform.eulerAngles = new Vector3(0, 0, 135);
                else if (richtung == (Vector3.down + Vector3.right).normalized) Feuerball.transform.eulerAngles = new Vector3(0, 0, -45);
                else if (richtung == (Vector3.down + Vector3.left).normalized) Feuerball.transform.eulerAngles = new Vector3(0, 0, 225);
                Feuerball.GetComponent<Fireball>().SetDirection(richtung);
                Destroy(Feuerball, 3);
                stats.currentMana -= stats.manaCostPerShot;
            }
        }

        GetComponent<Animator>().SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        stats.manaRegen += Time.deltaTime;
        if (stats.manaRegen >= 0.05f)
        {
            stats.currentMana += 1;
            stats.manaRegen = 0f;
        }

        if (stats.currentMana >= 100)
        {
            stats.currentMana = stats.maxMana;
        }
    }
}

