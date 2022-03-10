using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public GameObject Colormeter;
    public Color LevelTargetColor;
    private void Start()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                PlayerController.ColorStage++;
                Debug.Log(PlayerController.ColorStage);
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, LevelTargetColor, (PlayerController.ColorStage) / 5);
                if (collision.gameObject.GetComponent<PlayerController>().Mybrother != null)
                {
                    collision.gameObject.GetComponent<PlayerController>().Mybrother.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
                }
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
                Colormeter.GetComponent<ColorMeter>().ColorCheck();
            }
        }
    }
}
