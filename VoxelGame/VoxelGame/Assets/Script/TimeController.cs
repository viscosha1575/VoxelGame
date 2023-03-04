using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public Text levelTime;
    public Text bestTime;
    double time = 0, best = 0;
    public bool onOff = false;
    public string temptime;
    public bool check = false;
    public static TimeController instance;
    // Start is called before the first frame update
    void Start()
    {
        string key = "BestTime" + SceneManager.GetActiveScene().buildIndex.ToString();

        if (PlayerPrefs.HasKey(key))
        {
            this.temptime = PlayerPrefs.GetString(key);
            bestTime.text = temptime;
        }
        else
        {
            bestTime.text = "";
            best = 0;
        }


    }

    private void Awake()
    {
        instance = this;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(temptime != "")
        best = Convert.ToDouble(temptime);
        if(LevelController.instance.movereq == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) onOff = true;
        }
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (onOff)
        {
            time += Time.deltaTime;
            levelTime.text = Math.Round(time,2).ToString();
        }
        if (check)
        {
            StartCoroutine(restarttime());

        }
    }

    public IEnumerator restarttime()
    {
        onOff = false;
        double temp = time;
        LevelController.instance.movereq = false;
        if ((best == 0 || time < best) && time > 0)
        {
            best = time;
            bestTime.text = Math.Round(best, 2).ToString();
            SaveTime();
            StartCoroutine(LevelController.instance.FinishLevel());
        }
        

        if (time > best)
        {
            
            LevelController.instance.message.text = "Вы не побили свой рекорд!";
            
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        levelTime.text = "0.00";
        time = 0;

        

        LevelController.instance.movereq = true;

    }
    public void SaveTime()
    {
        string key = "BestTime" + SceneManager.GetActiveScene().buildIndex.ToString();
        if(best != 0)
        {
            temptime = Math.Round(best, 2).ToString();
            PlayerPrefs.SetString(key, this.temptime);
            PlayerPrefs.Save();
        }
        
    }

    
}
