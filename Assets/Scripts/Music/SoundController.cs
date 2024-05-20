using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    mainmenu = 0,
    Akfire=1,
    Awm=2,
    ButtonClip=3,
    ButtonSelect=4,
    ButtonTap=5,
}
public class SoundController : MonoBehaviour
{
    public static SoundController _instance;
    public AudioSource audioFx;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            _instance = this;
        }
         DontDestroyOnLoad(this);
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
        var audio = Resources.Load<AudioClip>($"Audio/Sounds/{soundType.ToString()}");
        audioFx.clip = audio;
        // audioFx.Play();
        audioFx.PlayOneShot(audio);

    }


    public void OfSound()
    {
        audioFx.volume = 0f;
    }
    public void OnSound()
    {
        audioFx.volume = 1f;
    }
}