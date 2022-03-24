using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class End : MonoBehaviour
{
    public GameObject Score;
    public GameObject backMusic;
    private void Start()
    {
        Score = GameObject.FindGameObjectWithTag("score");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        backMusic.GetComponent<AudioSource>().Stop();
        this.transform.GetChild(0).gameObject.SetActive(true);
        Score.GetComponent<ScoreKeeper>().levelfinished[SceneManager.GetActiveScene().buildIndex] = true;
        Invoke("LoadLevel2", 3.5f);
        this.gameObject.GetComponent<AudioSource>().Play();
        Debug.Log("sa");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(0);
    }
}
