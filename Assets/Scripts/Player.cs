using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 richtung = Vector3.right;

    void Update()
    {
        float geschw = 5f * Time.deltaTime;

        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) input += Vector3.up;
        if (Input.GetKey(KeyCode.S)) input += Vector3.down;
        if (Input.GetKey(KeyCode.A)) input += Vector3.left;
        if (Input.GetKey(KeyCode.D)) input += Vector3.right;

        if (input != Vector3.zero) richtung = input.normalized;

        transform.position += input.normalized * geschw;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Feuerball = Instantiate(prefab, transform.position + richtung * 1.0f, Quaternion.identity);
            Feuerball.GetComponent<Fireball>().SetDirection(richtung);
            Destroy(Feuerball, 3);
        }
    }
}

