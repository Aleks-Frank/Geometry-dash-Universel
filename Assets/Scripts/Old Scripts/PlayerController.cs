using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // скорость движени€ персонажа
    public float moveSpeed;
    // сила его прыжка
    public float jumpForce;
    // флаг, провер€ющий, находитс€ ли персонаж на полу, если истина, то он сможет прыгнуть
    // если лож, то нет
    public bool isGrounded;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        //считывание состо€ни€ объекта
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        // движение по y 
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // прыжок на Space
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
