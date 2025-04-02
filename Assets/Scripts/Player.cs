using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;

    void Update()
    {
        float geschw = 5f * Time.deltaTime;

        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) input += Vector3.up;
        if (Input.GetKey(KeyCode.S)) input += Vector3.down;
        if (Input.GetKey(KeyCode.A)) input += Vector3.left;
        if (Input.GetKey(KeyCode.D)) input += Vector3.right;

        transform.position += input.normalized * geschw;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Feuerball = Instantiate(prefab, transform.position + Vector3.right * 1.0f, Quaternion.identity);
            Destroy(Feuerball, 3);
        }
    }
}
