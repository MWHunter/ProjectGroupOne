using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    private void Start()
    {
    
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = clickSound;
    
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
