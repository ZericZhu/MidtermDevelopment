using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangeColor : MonoBehaviour
{
    private SpriteRenderer MyMom, Mychild, Mychild2;
    public Color OldColor, NewColor;
    private void Start()
    {
        MyMom = this.transform.parent.GetComponent<SpriteRenderer>();
        Mychild = this.transform.parent.GetChild(1).GetComponent<SpriteRenderer>();
        Mychild2 = this.transform.parent.GetChild(2).GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MyMom.color = NewColor;
        Mychild.color = NewColor;
        Mychild2.color = NewColor;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        MyMom.color = OldColor;
        Mychild.color = OldColor;
        Mychild2.color = OldColor;
    }
}
