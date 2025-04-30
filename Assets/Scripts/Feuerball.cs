using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float geschw = 10f;
    public Rigidbody2D rb;
    private Vector3 richtung = Vector3.up;

    public void SetDirection(Vector3 neueRichtung)
    {
        richtung = neueRichtung.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = richtung * geschw;
    }

}
