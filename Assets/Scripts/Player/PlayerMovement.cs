using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 _input;
    private bool _isMoving;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        _isGrounded = false;
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        _input = _input.normalized;

        transform.Translate(_input * (_speed * Time.deltaTime));

        _isMoving = _input.x != 0;

        if (_isMoving)
        {
            _spriteRenderer.flipX = _input.x < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isGrounded = true;
    }
}
