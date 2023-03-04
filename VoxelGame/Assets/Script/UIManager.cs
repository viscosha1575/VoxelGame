using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject MusPanel;
 
    public void NewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void HowGame(){
        GamePanel.SetActive(true);
    }

    public void ExitGame(){
        Application.Quit();
    }
    public void BackMenu(){
        GamePanel.SetActive(false);
    }

    public void GameToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameMusicMenu()
    {
        MusPanel.SetActive(true);
    }

    public void CloseGameMusicMenu()
    {
        MusPanel.SetActive(false);
    }
    

}
