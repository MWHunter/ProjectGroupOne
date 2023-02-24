using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void ComputerScience(){
           SceneManager.LoadScene(1);
    }
    public void Finance(){
           SceneManager.LoadScene(1);
    }
    public void Math(){
           SceneManager.LoadScene(1);
    }
    public void Quit(){

        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
