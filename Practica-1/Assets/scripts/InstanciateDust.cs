using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateDust : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public float livingTime;

    public void Instanciate()
    {
        GameObject instanciatedObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;

        if (livingTime > 0f)
            Destroy(instanciatedObject, livingTime);

    }
}
