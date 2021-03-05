using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float watingTime;
    public float wallWare = 0.2f;
    public LayerMask groundLayer;

    private Weapon _weapon;
    private Rigidbody2D _rigyBody;

    private bool _facingRight;
    private bool _attacking = false;

    private float _amingTime = 0.2f;
    private float _shootingTime = 0.5f;

    public Animator _animator;
    private GameObject _target;

    private void Awake()
    {
        Debug.Log("im awake");
        _weapon = GetComponentInChildren<Weapon>();
        _animator = GetComponent<Animator>();
        _rigyBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //updateTarget();
        //StartCoroutine("PatrolTarget");

        //Hacia donde esta mirando el enemigo
        if (transform.localScale.x < 0f)
            _facingRight = false;
        else if (transform.localScale.y > 0f)
            _facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _animator.SetTrigger("shoot");
        //    //_weapon.shoot();
        //}

        //Vector2 direction = Vector2.right;
        //if (!_facingRight && transform.localScale.x > 0f)
        //{
        //    direction = Vector2.left;
        //    flip();
        //}
        //if (!_attacking)
        //{
        //    Physics2D.Raycast(transform.position, direction, wallWare, groundLayer);
        //    flip();
        //}

        //if (transform.localScale.x > 0f && !_facingRight)
        //    flip();
        //else if (transform.localScale.x < 0f && _facingRight)
        //    flip();

        Vector2 direction = Vector2.right;
        if (!_facingRight)
            direction = Vector2.left;

        if (!_attacking)
        {
           if(Physics2D.Raycast(transform.position, direction, wallWare, groundLayer))
           // Debug.Log("I see wall");
            flip();
        }

        if (transform.localScale.x > 0f && !_facingRight)
            flip();
        else if (transform.localScale.x < 0f && _facingRight)
            flip();

    }

    private void FixedUpdate()
    {
        //float horizontallVelocity = speed;
        //if (!_facingRight)
        //    horizontallVelocity = horizontallVelocity * -1f;

        //_rigyBody.velocity = new Vector2(horizontallVelocity, _rigyBody.velocity.y);
        float horizontalVelocity = speed;

        if (!_facingRight)
            horizontalVelocity = horizontalVelocity * -1f;

        _rigyBody.velocity = new Vector2(horizontalVelocity, _rigyBody.velocity.y);
    }

    private void LateUpdate()
    {
        if (!_attacking)
            _animator.SetBool("walk", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_attacking && collision.CompareTag("Player"))
            StartCoroutine(aimAndShoot());
    }

    IEnumerator aimAndShoot()
    {
        float tempSpeed = speed;
        speed = 0f;
        _attacking = true;
        yield return new WaitForSeconds(_amingTime);

        _animator.SetTrigger("shoot");

        yield return new WaitForSeconds(_shootingTime);

        _attacking = false;
        speed = tempSpeed;
    }

    //void updateTarget()
    //{
    //    if (_target == null)
    //    {
    //        _target = new GameObject("Target");
    //        _target.transform.position = new Vector2(minX, transform.position.y);
    //        transform.localScale = new Vector3(-1, 1, 1);
    //        return;
    //    }

    //    if (_target.transform.position.x == minX)
    //    {
    //        _target.transform.position = new Vector2(maxX, transform.position.y);
    //        transform.localScale = new Vector3(1, 1, 1);
    //    }
    //    else
    //    {
    //        _target.transform.position = new Vector2(minX, transform.position.y);
    //        transform.localScale = new Vector3(-1, 1, 1);
    //    }
    //}

    //IEnumerator PatrolTarget()
    //{
    //    while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
    //    {
    //        Vector2 direction = _target.transform.position - transform.position;
    //        float xDirection = direction.x;

    //        transform.Translate(direction.normalized * speed * Time.deltaTime);

    //        _animator.SetBool("walk", true);
    //        yield return null;
    //    }

    //    Debug.Log("target reached");
    //    transform.position = new Vector2(_target.transform.position.x, _target.transform.position.y);
    //    _animator.SetBool("walk", false);
    //    updateTarget();

    //    Debug.Log("Wating for " + watingTime + "Seconds");
    //    _animator.SetTrigger("shoot");
    //    yield return new WaitForSeconds(watingTime);

    //    Debug.Log("Lets move again");
    //    StartCoroutine("PatrolTarget");

    //}
    void CanShoot()
    {
        if (_weapon != null)
        {
            _weapon.shoot();
        }
    }

    void flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void OnEnable()
    {
        speed = 1;
        _animator.SetBool("walk", true);
        _attacking = false;
    }

}
