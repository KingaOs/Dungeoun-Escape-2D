using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    bool _isGrounded = false;
    [SerializeField]
    private float _jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            _isGrounded = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.6f, 1<<8);
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
        if(hit.collider != null)
        {
            _isGrounded = true;
        }


    }
}
