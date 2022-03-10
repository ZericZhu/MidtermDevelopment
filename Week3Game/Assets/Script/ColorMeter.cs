using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMeter : MonoBehaviour
{
    public Vector3 OriginalPosition;
    public float meter, percentage;
    public float TargetRGB;
    public GameObject Player;
    public Color TargetColor;
    public SpriteRenderer MyspriteRenderer;
    private void Awake()
    {
        OriginalPosition = this.GetComponent<RectTransform>().anchoredPosition;
        TargetRGB = (1 - TargetColor.r) + (1 - TargetColor.g) + (1 - TargetColor.b);
        MyspriteRenderer = Player.GetComponent<SpriteRenderer>();
        PlayerController.TrueMe = Player;
        ColorCheck();
    }
    public void ColorCheck()
    {
        MyspriteRenderer = PlayerController.TrueMe.GetComponent<SpriteRenderer>();
        percentage = ((1 - MyspriteRenderer.color.b) + (1 - MyspriteRenderer.color.r) +(1 - MyspriteRenderer.color.g) )/ TargetRGB;
        meter = Mathf.Lerp(0, 275.5f, percentage);
        this.GetComponent<RectTransform>().anchoredPosition = OriginalPosition + new Vector3(meter,0);
    }
}
