using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float followspeed;
    public Vector3 offset;
    public Sprite StartSprite;

    private void Start()
    {
        PlayerController.CheckSprite = StartSprite;
        PlayerController.CheckScale = new Vector3(1, 1, 1);
        PlayerController.ColorStage = 0;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = Player.transform.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followspeed*Time.deltaTime);
        transform.position = SmoothedPosition;
    }
}
