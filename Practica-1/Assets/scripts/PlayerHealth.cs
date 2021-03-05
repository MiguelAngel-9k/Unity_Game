using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float heatlhSize = 16f;

    public int totalHelth = 3;
    public int _health;


    public GameObject enemy;

    private SpriteRenderer _rederer;
    private Animator _animator;
    private PlayerController _controller;
    public RectTransform rectTransform;
    public RectTransform gameOver;
    


    private void Awake()
    {
        _rederer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        _health = totalHelth;
    }

    public void addDamage(int amount)
    {
        _health = _health - amount;

        StartCoroutine("VisualFeedback");

        if (_health <= 0)
        {
            _health = 0;
            gameObject.SetActive(false);            
        }

        Debug.Log("Play got damage: " + _health);
        rectTransform.sizeDelta = new Vector2(heatlhSize * _health, heatlhSize);
    }

    public void addHealth(int amount)
    {
        _health = _health + amount;
        if (_health > totalHelth)
            _health = totalHelth;

        Debug.Log("Got some life: " + _health);
        rectTransform.sizeDelta = new Vector2(heatlhSize * _health, heatlhSize);
    }

    private void OnEnable()
    {
        _health = totalHelth;
        _rederer.color = Color.white;

        enemy.SetActive(true);
        rectTransform.sizeDelta = new Vector2(totalHelth * heatlhSize, heatlhSize);
    }

    private void OnDisable()
    {
        gameOver.gameObject.SetActive(true);

        enemy.SetActive(false);
        
        //_animator.enabled = false;
        //_controller.enabled = false;
    }

    IEnumerator VisualFeedback()
    {
        _rederer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _rederer.color = Color.white;
    }
}
