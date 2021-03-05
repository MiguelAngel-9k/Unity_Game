using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Player speed
    public float speed = 2.5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public float jumpForce = 2.5f;

    //Rigybody and animator
    private Rigidbody2D _rigyBody;
    private Animator _animator;

    //idle timer
    public float longIdleTime = 5f;
    private float _longIdleTimer;

    //Player movement
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _isAttacking;

    private bool _faceRight = true;

    private void Awake()
    {
        _rigyBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAttacking == false)
        {
            float axisValue = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(axisValue, 0f);

            if (_movement.x > 0f && _faceRight == false)
                flip();
            else if (_movement.x < 0f && _faceRight == true)
                flip();
        }

        //is grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            Debug.Log("Grounded: " + _isGrounded.ToString());
            _rigyBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(_isAttacking == false && _isGrounded == true && Input.GetButtonDown("Fire1"))
        {
            _movement = Vector2.zero;
            _rigyBody.velocity = Vector2.zero;
            _animator.SetTrigger("attack");
        }
    }

    void FixedUpdate()
    {
       if(_isAttacking == false)
        {
            float _axisVelocity = _movement.normalized.x * speed;
            _rigyBody.velocity = new Vector2(_axisVelocity, _rigyBody.velocity.y);
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("idle", _movement == Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);        
        _animator.SetFloat("verticalVelocity", _rigyBody.velocity.y);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            _isAttacking = true;
        else
            _isAttacking = false;

        if(_animator.GetCurrentAnimatorStateInfo(0).IsTag("idle"))
        {
            _longIdleTimer += Time.deltaTime;

            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("longIdle");

            }
            else
                _longIdleTimer = 0f;
        }

    }
    private void flip()
    {
        _faceRight = !_faceRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX*-1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

}
