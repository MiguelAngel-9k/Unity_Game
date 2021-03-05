using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public GameObject player;

    public void addDamage()
    {
        Debug.Log("Enemy got hit");
        gameObject.SetActive(false);

        player.SetActive(false);
    }
}
