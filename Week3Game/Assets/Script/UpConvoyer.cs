using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpConvoyer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20);
        }
    }
}
