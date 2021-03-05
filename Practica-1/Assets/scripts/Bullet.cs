using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.2f;
    public Vector2 direction;
    public float livingTime = 0.5f;
    public int damage = 1;

    private Color _initialColor = Color.white;
    private Color _finalColor = Color.red;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigibody;
    private float _initialTime;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigibody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, livingTime);
        _initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movment = direction * speed;
        _rigibody.velocity = movment;

        float _timeScinceStarded = Time.time - _initialTime;
        float _porcentageCompleted = _timeScinceStarded / livingTime;

        _renderer.color = Color.Lerp(_initialColor, _finalColor, _porcentageCompleted);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("addDamage", damage);
            Destroy(this.gameObject);
        }
    }
}
