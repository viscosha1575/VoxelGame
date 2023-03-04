using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    public Text[] bests;
    public void OnClick(Button btnName){
        SceneManager.LoadScene(btnName.name);
    }    
    public void BackMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    private void Start()
    {
        int index = 0;
        for (int level = 2; level < SceneManager.sceneCountInBuildSettings; level++)
        {
            if (PlayerPrefs.HasKey("BestTime" + level.ToString()))
            {
                bests[index].text = PlayerPrefs.GetString("BestTime" + level.ToString()) + " Секунд";
                
            }
            index++;
        }
    }

    
}
