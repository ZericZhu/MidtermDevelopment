using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    private bool isTouched = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTouched == false)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                collision.gameObject.GetComponent<PlayerController>().CheckPoint = this.transform.position;
                PlayerController.CheckColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
                PlayerController.CheckScale = collision.transform.localScale;
                PlayerController.CheckColorStage = (int)PlayerController.ColorStage;
                PlayerController.CheckRect = collision.gameObject.GetComponent<PlayerController>().IsRect;
                PlayerController.TrueMe = collision.gameObject;
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
            isTouched = true;
        }
    }
}
