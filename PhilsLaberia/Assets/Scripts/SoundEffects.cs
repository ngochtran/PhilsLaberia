using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource sfxSrc;
    public AudioClip bell, pop, water, ice, clock, menu, clap;

    public static SoundEffects instance;

    private void Awake()
    {
        instance = this;
        sfxSrc.volume = 1f;
    }

    public void playClap()
    {
        sfxSrc.clip = clap;
        sfxSrc.Play();
        sfxSrc.volume = 0.1f;
    }

    public void playBell()
    {
        sfxSrc.clip = bell;
        sfxSrc.Play();
    }

    public void playPop()
    {
        sfxSrc.clip = pop;
        sfxSrc.Play();
    }
    public void playWater()
    {
        sfxSrc.clip = water;
        sfxSrc.Play();
    }

    public void playIce()
    {
        sfxSrc.clip = ice;
        sfxSrc.Play();
    }

    public void playClock()
    {
        sfxSrc.clip = clock;
        sfxSrc.Play();
    }

    public void playMenu()
    {
        sfxSrc.clip = menu;
        sfxSrc.Play();
    }

}
