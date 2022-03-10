using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActive : MonoBehaviour
{
    public GameObject UICanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UICanvas.SetActive(true);
    }
}
