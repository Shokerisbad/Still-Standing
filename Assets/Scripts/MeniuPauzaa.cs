using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuPauzaa : MonoBehaviour
{
    [SerializeField]public bool isPaused = false;
    [SerializeField]GameObject canvasMeniu;
    [SerializeField] GameObject optiuni;
    public bool isOptionsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        optiuni.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isOptionsActive) 
        {
            isPaused = !isPaused;

        }

        POMeniu();

        if (isOptionsActive == true)
        {
            ActiveazaHUDOptiuni();
        }
        InapoiLaMeniu();

    }

    private void ActiveazaHUDOptiuni()
    {
        isPaused = true;
        canvasMeniu.SetActive(false);
        Time.timeScale = 0f;
        optiuni.SetActive(true);
    }

    private void POMeniu()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            canvasMeniu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            canvasMeniu.SetActive(false);

        }
    }

    public void Inapoi()
    {
        Time.timeScale = 1f;
        isPaused = false;
        canvasMeniu.SetActive(false);
    }

    public void IncarcaMeniu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Optiuni()
    {
        isOptionsActive = true;
        
    }

    public void ReturnMainMenu()
    {
        isOptionsActive = false;
        optiuni.SetActive(false);
        canvasMeniu.SetActive(true);
        isPaused = true;
    }

    private void InapoiLaMeniu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOptionsActive == true)
        {
            isOptionsActive = false;
            optiuni.SetActive(false);
            canvasMeniu.SetActive(true);

        }
    }
}
