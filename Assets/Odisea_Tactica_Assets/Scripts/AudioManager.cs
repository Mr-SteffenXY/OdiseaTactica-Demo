using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip menuClickSound;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Si no hay un AudioSource en el objeto, añádelo
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayMenuClickSound()
    {
        audioSource.PlayOneShot(menuClickSound);
    }
}
