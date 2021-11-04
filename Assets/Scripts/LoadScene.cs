using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    
    //load first level function
    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
     
    }

    //load start scene function
    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);

    }
    
    //load second level function
    public void LoadSecondLevel()
    
    {
        SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Single);

    }

    //quit game function for the exit button
    public void ExitApplication()
    {

        Application.Quit();


    }
}
