using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    //public RectTransform canvasScreenRect;


    // Start is called before the first frame update
    void Start()
    {


        //canvasScreenRect.sizeDelta = new Vector2(Screen.width, Screen.height);
        //canvasScreenRect.anchoredPosition = new Vector2(0f, 0f);
        
        /*
        if (canvasScreenRect == null)
        {
            //do nothing
        }

        */
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
