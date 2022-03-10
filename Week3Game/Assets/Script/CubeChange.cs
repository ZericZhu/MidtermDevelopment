using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChange : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(CubeAnimation());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x * 0.5f, collision.gameObject.transform.localScale.y, 1);
                collision.gameObject.GetComponent<PlayerController>().IsRect = false;
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

    public IEnumerator CubeAnimation()
    {
        float time = 0, duration = 1.5f;
        Vector3 endScale = new Vector3(1, 1f, 1);
        Vector3 startScale = new Vector3(2, 1, 1f);
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
        StartCoroutine(CubeAnimation());
    }
}
