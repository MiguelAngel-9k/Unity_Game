using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool _attack;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            Debug.Log("Attacking");
            _attack = true;
        }
        else _attack = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_attack)
            if (collision.CompareTag("Enemy"))
                collision.SendMessageUpwards("addDamage");
    }
}
