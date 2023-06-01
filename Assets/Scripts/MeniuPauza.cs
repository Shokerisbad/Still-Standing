using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuPauza : MonoBehaviour
{
    public bool isPaused = false;
    private bool isOptionsActive = false;
    [SerializeField] 
    private GameObject pauseMenu;
    [SerializeField] 
    private GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isOptionsActive)
            isPaused = !isPaused;
        else if (Input.GetKeyUp(KeyCode.Escape) && isOptionsActive)
            isOptionsActive = false;

        POMeniu();
        POOptiuni();
    }

    private void POMeniu()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
    }

    private void POOptiuni()
    {
        if (isOptionsActive)
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
            optionsMenu.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        isOptionsActive = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
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
