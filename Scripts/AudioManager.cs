using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音频管理
/// </summary>
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
