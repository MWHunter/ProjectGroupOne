

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ComputerScience()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetString("QuizType", "Computer Science");
    }

    public void Math()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetString("QuizType", "Math");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
