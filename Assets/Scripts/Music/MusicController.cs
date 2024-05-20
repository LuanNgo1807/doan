using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioSource audioFx;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(this);
    }
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
        }
    }
    public void OnPlayAudio(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Audio/Musics/{soundType.ToString()}");
        audioFx.clip = audio;
        audioFx.Play();
        // audioFx.PlayOneShot(audio);
    }

    public void OfMusic()
    {
        audioFx.volume = 0f;
    }
    public void OnMusic()
    {
        audioFx.volume = 1f;
    }
}
