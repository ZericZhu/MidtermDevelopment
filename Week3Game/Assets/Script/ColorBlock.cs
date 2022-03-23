using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlock : MonoBehaviour
{
    public int MyColorstage;
    public Color textColStart, textColEnd;
    private bool isfading;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
        {
            if (PlayerController.ColorStage == MyColorstage)
            {
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

}
