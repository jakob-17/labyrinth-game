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

    private float interval = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= interval)
        {
            interval++;

            UpdateEverySecond();
        }

/*        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, currentDir);
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
        }*/
    }

    // name seems self explanatory
    void UpdateEverySecond()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, currentDir);

        if (hit.collider != null && hit.distance < 0.1f)
        {
            int index;
            RaycastHit2D diffDir;
            if (dirs[0] == currentDir) // moving up
            {
                do
                {
                    index = UnityEngine.Random.Range(1, 4);
                    diffDir = Physics2D.Raycast(this.transform.position, dirs[index]);
                } while (diffDir.distance < 0.5f);

                currentDir = dirs[index];
                rb2d.velocity = currentDir * speed;
            }
            else if (dirs[1] == currentDir) // moving down
            {
                do
                {
                    index = UnityEngine.Random.Range(0, 4);
                    diffDir = (index != 1) ? Physics2D.Raycast(this.transform.position, dirs[index]) : Physics2D.Raycast(this.transform.position, dirs[0]);
                } while (diffDir.distance < 0.5f);

                currentDir = dirs[index];
                rb2d.velocity = currentDir * speed;
            }
            else if (dirs[2] == currentDir) // moving right
            {
                do
                {
                    index = UnityEngine.Random.Range(0, 4);
                    diffDir = (index != 2) ? Physics2D.Raycast(this.transform.position, dirs[index]) : Physics2D.Raycast(this.transform.position, dirs[3]);
                } while (diffDir.distance < 0.5f);

                currentDir = dirs[index];
                rb2d.velocity = currentDir * speed;
            }
            else if (dirs[3] == currentDir) // moving left
            {
                do
                {
                    index = UnityEngine.Random.Range(0, 3);
                    diffDir = Physics2D.Raycast(this.transform.position, dirs[index]);
                } while (diffDir.distance < 0.5f);

                currentDir = dirs[index];
                rb2d.velocity = currentDir * speed;
            }
        }
    }
}
