using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotate : MonoBehaviour
{
    public Vector3[] targetRotation;
    public int rotateStage;
    void Start()
    {
        StartCoroutine(LerpFunction(Quaternion.Euler(targetRotation[rotateStage]), 4));
    }
    IEnumerator LerpFunction(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
        if(rotateStage < 3)
        {
            rotateStage++;
        }
        else
        {
            rotateStage = 0;
        }
        StartCoroutine(LerpFunction(Quaternion.Euler(targetRotation[rotateStage]), 4));
    }
}
