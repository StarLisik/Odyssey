using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    AudioSource Elektrotronomia;
    private static MusicScript puk;
    
    public void Awake()
    {
        if (!puk)
        {
            puk = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
