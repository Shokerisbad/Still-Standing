using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBarScript : MonoBehaviour
{
    public WaveManagerScript waveManagerScript;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int waveDoneAmmount = (int)(((float)waveManagerScript.nrEnemiesKilled / (float)waveManagerScript.wave) * 100);
        image.rectTransform.sizeDelta = new Vector2(8 * waveDoneAmmount, image.rectTransform.sizeDelta.y);
    }
}
