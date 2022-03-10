using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneMove : MonoBehaviour
{
    public float _rollSpeed = 5;
    public bool Ismoving;
    public int LevelIndex;
    private bool StartFall = false;
    public GameObject MainCamera, MainCanvas;
    void Start()
    {
        LevelIndex = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFall == false)
        {
            if (Input.GetKeyDown(KeyCode.D) && LevelIndex < 4)
            {
                StartCoroutine(CubeRoll(Vector3.right));
                LevelIndex++;
            }
            if (Input.GetKeyDown(KeyCode.A) && LevelIndex > 1)
            {
                StartCoroutine(CubeRoll(Vector3.left));
                LevelIndex--;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
               
                StartFall = true;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                MainCamera.AddComponent<CameraFollow>();
                MainCamera.GetComponent<CameraFollow>().Player = this.gameObject;
                MainCamera.GetComponent<CameraFollow>().followspeed = 10;
                MainCamera.GetComponent<CameraFollow>().offset = new Vector3(0,0,-10);
                StartCoroutine(EnsmallAnimation2());
                MainCanvas.SetActive(false);
            }
        }
    }

    public IEnumerator CubeRoll(Vector3 Direction)
    {
        Ismoving = true;
        var anchor = transform.position + (Vector3.down + Direction) * this.transform.localScale.x / 2;
        var axis = Vector3.Cross(Vector3.up, Direction);
        for (var i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.01f);
        Ismoving = false;
    }

    public IEnumerator EnsmallAnimation2()
    {
        float time = 0, duration = 2f;
        float scaleModifier = 1, endValue = 0.5f;
        float startValue = scaleModifier, startcolor = this.GetComponent<SpriteRenderer>().color.a;
        float ColorPercentage;
        Vector3 startScale = new Vector3(2f, 2f, 2f);
        while (time < duration)
        {
            ColorPercentage = Mathf.Lerp(startcolor, 1, time / duration);
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, ColorPercentage);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * endValue;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Invoke("LoadLevel", 1f);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelIndex);
    }

}

    
