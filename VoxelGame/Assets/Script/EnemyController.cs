using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        instance = this;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(death());
        }
    }

    private IEnumerator death()
    {
        LevelController.instance.movereq = false;
        TimeController.instance.onOff = false;

        AudioPlayerManager.instance.soundaudio.clip = AudioPlayerManager.instance.sounds[0];
        AudioPlayerManager.instance.soundaudio.Play();

        PlayerPrefs.SetFloat("SoundVolume", AudioPlayerManager.instance.SoundVolume.value);

        LevelController.instance.message.text = "Вы умерли!";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelController.instance.movereq = true;
    }
}
