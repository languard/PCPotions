using UnityEngine;
using System.Collections;

public class UI_Credits : MonoBehaviour
{

    public void ClickReturnButton()
    {
        int targetLevel = PlayerPrefs.GetInt("TargetLevel");
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetLevel);
    }
}
