using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �������� �������� ���������
    public float moveSpeed;
    // ���� ��� ������
    public float jumpForce;
    // ����, �����������, ��������� �� �������� �� ����, ���� ������, �� �� ������ ��������
    // ���� ���, �� ���
    public bool isGrounded;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        //���������� ��������� �������
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        // �������� �� y 
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // ������ �� Space
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
