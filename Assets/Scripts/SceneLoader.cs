using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
   public void IncarcaScenaUrm()
    {
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
}
