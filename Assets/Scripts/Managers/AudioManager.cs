using System;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [SerializeField]
    private Sound[] sounds;

    private bool _isSoundEnabled;

    void Awake()
    {
        base.Awake();
        _isSoundEnabled = true;
        if(sounds != null)
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        
        }
    }

    public void Play(string soundName)
    {
        if (_isSoundEnabled)
        {
            if(sounds == null)
            {
                Debug.LogWarning("Audio aray not found!");
                return;
            }
            Sound s = Array.Find(sounds, sound => sound.name == soundName);
            if(s== null)
            {
                Debug.LogWarning("Sound " + soundName + " not found!");
                return;
            }
            s.Play();
        }
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + soundName + " not found!");
            return;
        }
        s.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void setSoundEnabled(bool value)
    {
        _isSoundEnabled = value;
        if (value == false)
            StopAll();
    }

    public bool isSoundEnabled()
    {
        return _isSoundEnabled;
    }
}
