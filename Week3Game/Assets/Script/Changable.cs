using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Changable : MonoBehaviour
{
    public Vector3 ChangeFactor;
    public bool IsBig, IsSmall;

    private void OnEnable()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (IsBig)
        {
            StartCoroutine(EnlargeAnimation());
        }

        if (IsSmall)
        {
            StartCoroutine(EnsmallAnimation());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                if (collision.gameObject.GetComponent<PlayerController>().IsRect == false)
                {
                    collision.gameObject.transform.localScale += ChangeFactor;
                    if (collision.gameObject.GetComponent<PlayerController>().Mybrother != null)
                    {
                        collision.gameObject.GetComponent<PlayerController>().Mybrother.transform.localScale += ChangeFactor;
                    }
                }
                else
                {
                    collision.gameObject.transform.localScale += new Vector3(ChangeFactor.x *2, ChangeFactor.y,ChangeFactor.z);
                }
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

    public IEnumerator EnlargeAnimation()
    {
        float time = 0, duration = 2f;
        float scaleModifier = 1, endValue = 1.5f;
        float startValue = 1;
        Vector3 startScale = new Vector3(0.2f, 0.2f, 0.2f);
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * endValue;
        StartCoroutine(EnlargeAnimation());
    }

    public IEnumerator EnsmallAnimation()
    {
        float time = 0, duration = 2f;
        float scaleModifier = 1.5f, endValue = 1;
        float startValue = scaleModifier;
        Vector3 startScale = new Vector3(0.4f, 0.4f, 0.4f);
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * endValue;
        StartCoroutine(EnsmallAnimation());
    }

}
