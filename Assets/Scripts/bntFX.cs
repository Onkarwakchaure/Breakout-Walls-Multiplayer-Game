using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bntFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip ClickFX;

    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(ClickFX);
    }
}
