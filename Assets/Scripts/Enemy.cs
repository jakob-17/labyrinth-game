using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer rend;

    public Rigidbody2D rb2d;

    public float speed;

    Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

    private Vector2 currentDir;

    // Start is called before the first frame update
    void Start()
    {
        currentDir = dirs[UnityEngine.Random.Range(0, 4)];
        rb2d.velocity = currentDir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, currentDir);
        if (hit.collider != null && hit.distance < 0.001f)
        {
            rb2d.velocity = Vector2.zero;
        }
        if (rb2d.velocity == Vector2.zero)
        {
            int index;
            do { index = UnityEngine.Random.Range(0, 4); } while (dirs[index] == currentDir);
            currentDir = dirs[index];
            rb2d.velocity = currentDir * speed;
        }
    }
}
