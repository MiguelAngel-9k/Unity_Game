using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtItem : MonoBehaviour
{
    public int amount = 1;
    public PlayerHealth player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player._health < 3)
        {
            Debug.Log("Extra life");
            collision.SendMessageUpwards("addHealth", amount);
            this.gameObject.SetActive(false);            
        }
    }    
}
