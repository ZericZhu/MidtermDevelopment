using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorCube : MonoBehaviour
{
    private GameObject UICounter;
    public AudioClip myaudio;
    private void Start()
    {
        UICounter = GameObject.FindWithTag("UICounter");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
                PlayerController.ColorStage++;
                Debug.Log(PlayerController.ColorStage);
                collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = collision.GetComponent<PlayerController>().PatternArray[PlayerController.ColorStage];
                if (collision.gameObject.GetComponent<PlayerController>().Mybrother != null)
                {
                    collision.gameObject.GetComponent<PlayerController>().Mybrother.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = collision.GetComponent<PlayerController>().PatternArray[(int)PlayerController.ColorStage];
                }
            playAudio(myaudio);
            this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
                UICounter.GetComponent<Text>().text = PlayerController.ColorStage + "/5";
                //Colormeter.GetComponent<ColorMeter>().ColorCheck();
        }
    }

    private void playAudio(AudioClip tempclip)
    {
        GameObject temp_gameobject = new GameObject();
        AudioSource temp_audio = temp_gameobject.AddComponent<AudioSource>();
        temp_audio.clip = tempclip;
        temp_audio.Play();
        Destroy(temp_gameobject, 2f);
    }
}
