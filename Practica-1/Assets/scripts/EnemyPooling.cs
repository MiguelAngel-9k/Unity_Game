using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{

    public GameObject prefab;
    public int amount = 10;
    public int instanciateGap = 5;

    // Start is called before the first frame update
    void Start()
    {
        iniciazatePool();
        InvokeRepeating("getEnemy", 1f, instanciateGap);
    }

    private void iniciazatePool()
    {
        for (int i = 0; i < amount; i++)
            addEnemy();
    }

    private void addEnemy()
    {
        GameObject enemy = Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
        enemy.SetActive(false);
    }

    private GameObject getEnemy()
    {
        GameObject enemy = null;
        for(int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                enemy = transform.GetChild(i).gameObject;
                break;
            }
        }

        if (!enemy)
        {
            addEnemy();
            enemy = transform.GetChild(transform.childCount-1).gameObject;
        }

        enemy.transform.position = this.transform.position;
        enemy.SetActive(true);
        return enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
