using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoombaControl : MonoBehaviour
{


    public bool objectInWay = false;
    public float speed = 1.0f;
    public float raycastDistance = 1.0f , raycastDistance2 = 1.0f;
    Vector2 dir = Vector2.left;

    void MoveRoomba()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, raycastDistance);

        transform.Translate(dir * speed * Time.deltaTime);

        if (hit.collider != null)
        {
            dir = DetectDirection(dir);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, dir * raycastDistance);
    }

    private void Update()
    {
        MoveRoomba();
        Debug.Log(dir);
    }

    private Vector2 DetectDirection(Vector2 currentDir)
    {
        if (currentDir == Vector2.left || currentDir == Vector2.right)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance2);
            if (hit.collider != null)
            {
                return Vector2.up;
            }
            else
            {
                return Vector2.down;
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance2);
            if (hit.collider != null)
            {
                return Vector2.right;
            }
            else
            {
                return Vector2.left;
            }
        }
    }
}