using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController.IsClimbing = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController.IsClimbing = true;
        }
    }
}
