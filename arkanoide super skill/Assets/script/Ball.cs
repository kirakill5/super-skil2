using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }
    //-1  -0.5  0  0.5  1 <- x value 
    //=================== <- racket
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
          float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position,
                               collision.transform.position,
                               collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}