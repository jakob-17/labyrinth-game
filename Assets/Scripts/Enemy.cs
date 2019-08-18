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

    }

    // Update is called once per frame
    void Update()
    {
       if (rb2d.velocity == Vector2.zero)
        {
            int index = UnityEngine.Random.Range(0, 3);
            currentDir = dirs[index];
            rb2d.velocity = dirs[index] * speed;
        }
    }
}
