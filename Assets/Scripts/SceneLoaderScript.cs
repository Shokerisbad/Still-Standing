using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoaderScript : MonoBehaviour
{
    public GameObject fundal;
    public Canvas canvas;

    public void IncarcaScenaUrm()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            fundal.SetActive(false);
            canvas.GetComponent<Canvas>().gameObject.SetActive(false);
        }

        int indexScenaCurenta = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScenaCurenta + 1);
    }

    public void IncarcaScenaStart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncarcaMeniu()
    {
        SceneManager.LoadScene(0);
    }

}