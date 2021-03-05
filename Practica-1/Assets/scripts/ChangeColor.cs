using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private void awake()
    {
        Debug.Log("I'm atached at the scene!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("You start the game");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("NOW I´M RED");
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            Debug.Log("NOW I'AM BLUE");
        }
    }
}
