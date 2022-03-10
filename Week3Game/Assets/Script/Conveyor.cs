using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float ConveyorSpeed;
    public Rigidbody2D Rb;
    void Start()
    {
        Rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Rb.position;
        Rb.position += Vector2.right * ConveyorSpeed * Time.fixedDeltaTime;
        Rb.MovePosition(pos);
    }
}
