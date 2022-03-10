using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float _rollSpeed = 5;
    public bool Ismoving;
    public Vector3 CheckPoint;
    public GameObject ColorCheck;

    public static List<GameObject> StateArray = new List<GameObject>();
    public static List<GameObject> BroArray = new List<GameObject>();
    public static Color CheckColor;
    public static Vector3 CheckScale;
    public static bool CheckRect;
    public static float ColorStage;
    public static int CheckColorStage;
    public float ZRotation;
    public bool IsRect;
    public GameObject Mybrother;
    public static GameObject TrueMe;
    private void Start()
    {
        Ismoving = false;
        IsRect = false;
    }

    private void Update()
    {
        ZRotation = Mathf.Abs(this.transform.rotation.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Ismoving == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (IsRect == false)
                {
                    StartCoroutine(CubeRoll(Vector3.right));
                }
                else
                {
                    StartCoroutine(RectRoll(Vector3.right));
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (IsRect == false)
                {
                    StartCoroutine(CubeRoll(Vector3.left));
                }
                else
                {
                    StartCoroutine(RectRoll(Vector3.left));
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (TrueMe.GetComponent<PlayerController>().Mybrother != null)
                {
                        Destroy(TrueMe.GetComponent<PlayerController>().Mybrother);           
                }
                this.transform.position = CheckPoint;
                this.transform.localScale = CheckScale;
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
                ColorStage = CheckColorStage;
                IsRect = CheckRect;
                this.GetComponent<SpriteRenderer>().color = CheckColor;
                ColorCheck.GetComponent<ColorMeter>().ColorCheck();
            
                for (int i =0; i < StateArray.Count; i++)
                {
                    StateArray[i].SetActive(true);
                }
            }
        }
    }



    public IEnumerator RectRoll(Vector3 Direction)
    {
        Ismoving = true;
        var anchor = transform.position + (Vector3.down *2 + Direction) * this.transform.localScale.y/2;
        if (Mathf.Abs(ZRotation %180)<45f)
        {
            anchor = transform.position + (Vector3.down + Direction * 2) * this.transform.localScale.y/2;
        }
            
            var axis = Vector3.Cross(Vector3.up, Direction);
            for (var i = 0; i <= 20; i++)
            {
                transform.RotateAround(anchor, axis, _rollSpeed);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.01f);
        Ismoving = false;
    }

    public IEnumerator CubeRoll(Vector3 Direction)
    {
        Ismoving = true;
        var anchor = transform.position + (Vector3.down + Direction) * this.transform.localScale.x / 2;
        var axis = Vector3.Cross(Vector3.up, Direction);
        for (var i = 0; i <= 19; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.01f);
        Ismoving = false;
    }
}
