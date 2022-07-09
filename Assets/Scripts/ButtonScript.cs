using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        int text = GetComponent<Text>().fontSize = 60;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        int text = GetComponent<Text>().fontSize = 50;
        switch (gameObject.name)
        {
            case "Play": SceneManager.LoadSceneAsync("Play");
                break;
            case "Retry": SceneManager.LoadSceneAsync("Play");
                break;
            case "Exit": Application.Quit();
                break;
        }
    }
}
