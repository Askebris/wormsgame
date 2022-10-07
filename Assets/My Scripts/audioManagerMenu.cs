using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
public class audioManagerMenu : MonoBehaviour
{
    public Sound[] sounds2;
    void Awake()
    {
        foreach (Sound s in sounds2)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("themeGreat");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds2, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

}
