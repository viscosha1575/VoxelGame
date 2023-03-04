using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayerManager : MonoBehaviour
{
    public static AudioPlayerManager instance;
    private AudioSource audio;
    public AudioSource soundaudio;
    public Slider MusicVolume;
    public Slider SoundVolume;
    public GameObject MusicAudio;
    public GameObject SoundAudio;
    public static float musicvol;
    public static float soundvol;
    private GameObject[] objs;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        audio = MusicAudio.GetComponent<AudioSource>();
        soundaudio = SoundAudio.GetComponent<AudioSource>();
        //audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = musicvol;
        soundaudio.volume = soundvol;
    }

     public void Awake()
    {
        instance = this;

        DontDestroyOnLoad(MusicAudio);
        DontDestroyOnLoad(SoundAudio);
      
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            musicvol = 0.1f;
            PlayerPrefs.SetFloat("MusicVolume", 0.1f);
        }
        else
        {
            musicvol = PlayerPrefs.GetFloat("MusicVolume");
            if(MusicVolume != null)
            {
                MusicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            soundvol = 0.1f;
            PlayerPrefs.SetFloat("SoundVolume", 0.1f);
        }
        else
        {
            soundvol = PlayerPrefs.GetFloat("SoundVolume");
            if(SoundVolume != null)
            {
                SoundVolume.value = PlayerPrefs.GetFloat("SoundVolume");
            }
        }

    }

    public void SetVolume()
    {
        musicvol = MusicVolume.value;
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume.value);
    }

    public void SetSoundVolume()
    {
        soundvol = SoundVolume.value;
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume.value);
    }
}
