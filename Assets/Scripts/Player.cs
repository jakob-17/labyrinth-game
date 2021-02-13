using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer rend;

    public Rigidbody2D rb2d;

    public float speed;

    public GenerateLevel currentLevel;

    private List<Vector3> Floor;

    public GameObject Node;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void FixedUpdate()
    {
        //// player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.velocity = movement * speed;
        ////
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
