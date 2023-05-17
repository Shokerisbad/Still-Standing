using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            deathUI.SetActive(true);
       
        else
            deathUI.SetActive(false);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
}
