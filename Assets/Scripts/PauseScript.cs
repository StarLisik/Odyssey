using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    int text;
    private bool paused = false;
    public GameObject Pause;
    public GameObject GameOver;
    public void OnPointerDown(PointerEventData pointerIventData)
    {
        text = GetComponent<Text>().fontSize = 50;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        text = GetComponent<Text>().fontSize = 40;
        if (gameObject.name == "Pause" && PlayerSkript.GameOver == false)
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                Pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                Pause.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerSkript.GameOver == false)
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                Pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                Pause.SetActive(false);
            }
        }
    }
}
