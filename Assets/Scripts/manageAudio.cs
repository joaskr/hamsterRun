using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageAudio : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.isLooped;
        }
        PlaySound("mainTheme");
    }

    public void PlaySound(string name)
    {
        foreach (var sound in sounds)
        {
            if(sound.name == name)
            {
                sound.source.Play();
            }
        }
    }
}
