using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMCUBE : MonoBehaviour
{
    public static string TestString;
    private void Update()
    {
        TestString = "I am Ronny!";
        Debug.Log(TestString);
    }
}
