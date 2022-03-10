using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Came : MonoBehaviour
{
    public GameObject cube;
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.TrueMe != null)
        {
            if (PlayerController.TrueMe.GetComponent<PlayerController>().Mybrother != null)
            {
                Transform Bro = PlayerController.TrueMe.GetComponent<PlayerController>().Mybrother.transform;
                this.transform.position = Vector3.Lerp(PlayerController.TrueMe.transform.position, Bro.position, 0.5f);
            }
            else
            {
                this.transform.position = PlayerController.TrueMe.transform.position;
            }
        }
        else
        {
            this.transform.position = cube.transform.position;
        }
    }
}
