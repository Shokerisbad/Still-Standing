using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuPauzaa : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField]GameObject canvasMeniu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
            
        }

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



}
