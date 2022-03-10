using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Split : MonoBehaviour
{
    public Vector3 ChangeFactor;
    public bool IsBig, IsSmall;
    public GameObject CameraPoss;
    public Vector3 MyPos;

    private void OnEnable()
    {
        MyPos = this.transform.position;
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine(SplitAnimaiton());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                if (collision.gameObject.GetComponent<PlayerController>().IsRect == false)
                {
                    Splitcube(collision.gameObject);
                }
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

    public IEnumerator SplitAnimaiton()
    {
        float time = 0, duration = 1.5f;
        Vector3 startPos = MyPos;
        Vector3 targetPos = startPos + new Vector3(-0.5f,0,0);
        Vector3 targetPos2 = startPos + new Vector3(0.5f, 0, 0);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            this.transform.GetChild(0).position = Vector3.Lerp(startPos, targetPos2, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        this.transform.GetChild(0).position = startPos;
        StartCoroutine(SplitAnimaiton());
    }

    public void Splitcube(GameObject cube)
    {
        Vector3 NowScale = cube.transform.localScale;
        cube.transform.localScale *= 1f;
        GameObject MyBrother = Instantiate(cube);
        cube.GetComponent<PlayerController>().Mybrother = MyBrother;
        MyBrother.GetComponent<PlayerController>().Mybrother = cube;
        cube.transform.localPosition += new Vector3(2, 0, 0);
        MyBrother.transform.localPosition += new Vector3(-2, 0, 0);
    }
}
