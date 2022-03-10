using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
        {
            Color TempPlayerColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Color TempMyColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            if (Mathf.Abs(TempMyColor.r - TempPlayerColor.r) + Mathf.Abs(TempMyColor.g - TempPlayerColor.g) + Mathf.Abs(TempMyColor.b - TempPlayerColor.b) <= 0.02)
            {
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }


}
