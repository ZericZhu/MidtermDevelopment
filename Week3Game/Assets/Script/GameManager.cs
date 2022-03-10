using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int GameState;
    void Start()
    {
        GameState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case 0://gamestart, ready to launch
                break;

            case 1:
                break;

            case 2:
                break;
        }
    }
}
