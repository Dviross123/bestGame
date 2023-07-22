using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public AudioSource Src;

    public AudioClip mouseHover;

    public void levelsMenue() 
    {
        SceneManager.LoadScene("levels menu");
    }

    public void tutlvl()
    {
        SceneManager.LoadScene("tut lvl");
    }

    public void mouseHoverPlay()
    {
        Src.clip = mouseHover;
        Src.Play();
    }
}
