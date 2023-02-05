using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("Level0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
