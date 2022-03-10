using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public bool HavePlayer;
    public GameObject Player;
    public float thrust;
    private SpriteRenderer Child1;
    public Color TargetColor;
    private void Start()
    {
        Child1 = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.GetComponent<PlayerController>() != null)
            {
            HavePlayer = true;
            Player = collision.gameObject;
            StartCoroutine(StartJump());
            }
        Invoke("PushPlayer", 3f);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.GetComponent<PlayerController>() != null)
            {
                HavePlayer = false;
            }
    }


    public void PushPlayer()
    {
        if (HavePlayer)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }

    public IEnumerator StartJump()
    {
        float time = 0, duration = 3f;
        Color StartColor = Child1.color;
        while (time < duration)
        {
            if (HavePlayer)
            {
                Child1.color = Color.Lerp(StartColor, TargetColor, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            else
            {
                Child1.color = StartColor;
                StopAllCoroutines();
                yield return null;
            }
        }
        Child1.color = StartColor;
    }
}
