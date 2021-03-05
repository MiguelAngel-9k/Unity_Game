using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet = null;
    public GameObject shooter = null;
    private Transform firePoint;

    void Awake()
    {        
        firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        shoot();        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void shoot()
    {
        if (firePoint != null && bullet != null && shooter != null)
        {
            GameObject tmpBullet = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = tmpBullet.GetComponent<Bullet>();

            if (shooter.transform.localScale.x < 0f)
            {
                bulletComponent.direction = Vector2.left;
            }
            else if (shooter.transform.localScale.x > 1f)
            {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
