using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnterFall : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
        {
                    collision.gameObject.AddComponent<StartFall>();
        }
    }
}



public class StartFall : MonoBehaviour
{
    private void Update()
    {
        this.transform.position += new Vector3(0, -1.5f*Time.deltaTime, 0);
    }
}
