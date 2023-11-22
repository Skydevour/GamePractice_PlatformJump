using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public static AudioSource AudioSource;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;
    }
}
