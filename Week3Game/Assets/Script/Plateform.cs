using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour
{
    public int Hight;
    private void Start()
    {
        StartCoroutine(MovePlateform());
    }

    IEnumerator MovePlateform()
    {
        float time = 0, duration = 3;
        Vector3 targetPosition;
        targetPosition = this.transform.position + new Vector3(0, Hight, 0);
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        time = 0;
        duration = 2;
        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;
        duration = 3;
        targetPosition = this.transform.position + new Vector3(0, -Hight, 0);
        startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        time = 0;
        duration = 2;
        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(MovePlateform());
    }
}
