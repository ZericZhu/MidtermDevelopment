using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dettection : MonoBehaviour
{
    public GameObject targetCube;
    private GameObject targetCube2;
    public int numer;
    // Update is called once per frame
    void Update()
    {
        if(targetCube.GetComponent<IAMCUBE>() != null)
        {
            targetCube.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
