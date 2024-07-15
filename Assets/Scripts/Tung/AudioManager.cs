using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("----------Audio Clip----------")]
    public AudioClip musicbackground;
    public AudioClip pistol_reload;
    public AudioClip pistol_shoot;
    public AudioClip smg_reload;
    public AudioClip smg_shoot;
    public AudioClip smg_spray;
    public AudioClip ar_reload;
    public AudioClip ar_shoot;
    public AudioClip ar_spray;
    public AudioClip rifle_reload;
    public AudioClip rifle_shoot;
    public AudioClip items_pickup;
    public AudioClip items_appear;

    public void Start()
    {
        musicSource.clip = musicbackground;
        musicSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
