using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchEnemy : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
           
    }
}
