using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {


    }
    
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        


    }

    public void QuitGame()
    {

        SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);



    }
}
