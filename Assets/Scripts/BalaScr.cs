using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScr : MonoBehaviour
{
    float tiempoBala = 0.15f;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 60;

        tiempoBala -= Time.deltaTime;

        if (tiempoBala < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fly"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
