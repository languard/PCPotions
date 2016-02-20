using UnityEngine;
using System.Collections;

public class UI_MainMenu : MonoBehaviour {

    public GameObject gameLogic;

    void Start()
    {
        //create the GameLogic prefab
        GameObject temp = GameObject.Instantiate(gameLogic);
        temp.name = "GameLogic";
    }


    public void ClickNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NewGame");
    }

    public void ClickContinue()
    {
        //NOT IMPLEMENTED
    }

    public void ClickCredits()
    {
        PlayerPrefs.SetInt("TargetLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

}
