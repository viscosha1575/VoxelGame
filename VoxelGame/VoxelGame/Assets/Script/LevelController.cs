using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public CharacterController mirror;
    public CharacterController player;
    public Text message;
    public bool movereq = true;
    private bool playreq = true;
    TimeController TimeReset;
    private Vector3 moveDirection;
    public bool playerRiched = false, mirrorRiched = false;
    public static LevelController instance;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        message.text = "Нажмите любую клавишу";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove(player);
        PlayerMove(mirror, -1);

        if (playerRiched == true && mirrorRiched == true)
        {
            movereq = false;
            if (playreq)
            {
                message.text = "Новый рекорд!";
                AudioPlayerManager.instance.soundaudio.clip = AudioPlayerManager.instance.sounds[1];
                if (!AudioPlayerManager.instance.soundaudio.isPlaying)
                {
                    AudioPlayerManager.instance.soundaudio.Play();
                    playreq = false;
                }
            }

            TimeController.instance.check = true;
        }
    }
    public void PlayerMove(CharacterController body, int vector = 1)
    {
        if (movereq)
        {
            moveDirection = Vector3.zero;
            moveDirection.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            moveDirection.y = Input.GetAxisRaw("Vertical") * moveSpeed;
            body.Move((moveDirection * vector) * Time.deltaTime);
            moveDirection.Normalize();
        }


    }

    public IEnumerator FinishLevel()
    {
        playerRiched = false;
        mirrorRiched = false;

        yield return new WaitForSeconds(3f);
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

}
