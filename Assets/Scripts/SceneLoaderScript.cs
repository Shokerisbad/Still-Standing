using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoaderScript : MonoBehaviour
{
    [SerializeField]
    private GameObject fundal;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject optionsMenu;
    private bool isOptionsActive = false;

    void Start()
    {
        optionsMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isOptionsActive)
            isOptionsActive = false;

        optionsMenu.SetActive(isOptionsActive);
    }

    public void IncarcaScenaUrm()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            fundal.SetActive(false);
            canvas.SetActive(false);
        }

        int indexScenaCurenta = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScenaCurenta + 1);
    }

    public void IncarcaScenaStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncarcaMeniu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadOptionsMenu()
    {
        isOptionsActive = true;
    }

    public void UnloadOptionsMenu()
    {
        isOptionsActive = false;
    }
}