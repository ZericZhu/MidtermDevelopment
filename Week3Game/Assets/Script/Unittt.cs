using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unittt : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(UnitAnimaiton());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                if (collision.gameObject.GetComponent<PlayerController>().IsRect == false)
                {
                    if (collision.gameObject.GetComponent<PlayerController>().Mybrother != null)
                    {
                        Destroy(collision.gameObject.GetComponent<PlayerController>().Mybrother);
                        PlayerController.TrueMe = collision.gameObject;
                    }
                }
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

    public IEnumerator UnitAnimaiton()
    {
        float time = 0, duration = 1.5f;
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = startPos + new Vector3(-0.5f, 0, 0);
        Vector3 targetPos2 = startPos + new Vector3(0.5f, 0, 0);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, time / duration);
            this.transform.GetChild(0).position = Vector3.Lerp(targetPos2, startPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        this.transform.GetChild(0).position = startPos;
        StartCoroutine(UnitAnimaiton());
    }
}
