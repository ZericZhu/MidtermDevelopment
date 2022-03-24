using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copytext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = this.transform.parent.GetChild(1).gameObject.GetComponent<Text>().text;
        this.GetComponent<Text>().fontSize = this.transform.parent.GetChild(1).gameObject.GetComponent<Text>().fontSize;
    }

}
