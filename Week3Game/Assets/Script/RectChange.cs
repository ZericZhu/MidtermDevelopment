using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectChange : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(RectAnimation());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
                collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x * 2, collision.gameObject.transform.localScale.y, 1);
                collision.gameObject.GetComponent<PlayerController>().IsRect = true;
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
        }
    }

    public IEnumerator RectAnimation()
    {
        float time = 0, duration = 2f;
        Vector3 endScale = new Vector3(0.4f, 0.2f, 0.2f);
        Vector3 startScale = new Vector3(0.2f, 0.2f, 0.2f);
        float XModifier, YModifier;
        while (time < duration)
        {
            XModifier = Mathf.Lerp(startScale.x, endScale.x, time / duration);
            YModifier = Mathf.Lerp(startScale.y, endScale.y, time / duration);
            transform.localScale = new Vector3(XModifier, YModifier, 1f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endScale;
        StartCoroutine(RectAnimation());
    }
}
