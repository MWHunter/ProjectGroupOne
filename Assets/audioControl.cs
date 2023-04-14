using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        float newVolume = volumeSlider.value; // read the current value of the slider
        audioSource.volume = newVolume; // set the volume of the audio source
    }
}