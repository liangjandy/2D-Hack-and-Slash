using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    //Input
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode jumpKey = KeyCode.Space;
    public string xMoveAxis = "Horizontal";

    //Movement
    public float speed = 5f;
    public float jumpForce = 6f;
    public float groundedLeeway = .1f;

    private Rigidbody2D rb2D = null;
    private float moveIntentX = 0;
    private bool attemptJump = false;
    private bool attemptAttack = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();
        HandleAttack();
    }

    void FixedUpdate()
    {
        HandleRun();
    }

    private void GetInput()
    {
        moveIntentX = Input.GetAxis(xMoveAxis);
        attemptAttack = Input.GetKeyDown(attackKey);
        attemptJump = Input.GetKeyDown(jumpKey);

    }

    private void HandleJump()
    {

    }

    private void HandleAttack()
    {


    }

    private void HandleRun()
    {
        if (moveIntentX > 0 && transform.rotation.y == 0)
        {
            transform.Rotate(0, 180, 0);
        }
        else if (moveIntentX < 0 && transform.rotation.y != 0)
        {
            transform.Rotate(0, 0, 0);
        }

        Debug.Log(transform.rotation.ToString());
        rb2D.velocity = new Vector2(moveIntentX * speed, rb2D.velocity.y);

    }
}
