using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeZone : MonoBehaviour
{
    public Color textColStart, textColEnd;
    private bool isfading;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.parent.gameObject.activeSelf)
        {
            StartCoroutine(fadeout(this.transform.GetChild(0).GetChild(0).gameObject, this.transform.GetChild(0).GetChild(1).gameObject));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null && isfading == false)
        {
            if (transform.parent.gameObject.activeSelf)
            {
                StartCoroutine(fadein(this.transform.GetChild(0).GetChild(0).gameObject, this.transform.GetChild(0).GetChild(1).gameObject));
            }
        }
    }
    IEnumerator fadein(GameObject Temp_pattern, GameObject Temp_num)
    {
        float time = 0;
        Image Temp_Sprite = Temp_pattern.GetComponent<Image>();
        Text Temp_text = Temp_num.GetComponent<Text>();
        Color startValue = new Color(1, 1, 1, 0);
        Color endValue = new Color(1, 1, 1, 1);
        while (time < 0.3f)
        {
            Temp_Sprite.color = Color.Lerp(startValue, endValue, time / 0.3f);
            Temp_text.color = Color.Lerp(textColStart, textColEnd, time / 0.3f);
            time += Time.deltaTime;
            yield return null;
        }
        Temp_Sprite.color = endValue;
        Temp_text.color = textColEnd;
    }

    IEnumerator fadeout(GameObject Temp_pattern, GameObject Temp_num)
    {
        float time = 0;
        Image Temp_Sprite = Temp_pattern.GetComponent<Image>();
        Text Temp_text = Temp_num.GetComponent<Text>();
        Color startValue = new Color(1, 1, 1, 1);
        Color endValue = new Color(1, 1, 1, 0);
        while (time < 0.3f)
        {
            Temp_Sprite.color = Color.Lerp(startValue, endValue, time / 0.3f);
            Temp_text.color = Color.Lerp(textColEnd, textColStart, time / 0.3f);
            time += Time.deltaTime;
            yield return null;
        }
        Temp_Sprite.color = endValue;
        Temp_text.color = textColStart;
    }
}
