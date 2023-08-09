using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource musicAudio;

    public void ChangeVolume()
    {
        musicAudio.volume = UI.ui.GetSliderValue();
    }
}
