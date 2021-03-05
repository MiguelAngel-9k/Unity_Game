using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
