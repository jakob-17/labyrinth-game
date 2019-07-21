using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer rend;

    public float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void FixedUpdate()
    {
        //// player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //RaycastHit hit;
        //if (!Physics.Raycast(transform.position, movement, 1.0f, 0) && movement.x > 0)
        //{
        //    transform.position = transform.position + new Vector3(1.0f, 0f, 0f);
        //}

        rb2d.AddForce(movement * speed);
        
        ////
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
