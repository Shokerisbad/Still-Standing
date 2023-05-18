using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBarScript : MonoBehaviour
{
    public WaveManagerScript waveManagerScript;
    private Image image;
    private float target = 0, value = 0;
    private int lastWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waveManagerScript.wave != lastWave)
            target = 1;
        else if(target != 1)
            target = (float)waveManagerScript.nrEnemiesKilled / (float)waveManagerScript.wave;

        if (value >= 0.99f)
        {
            value = 0;
            target = 0;
        }

        if(value < target)
            value += (target - value) / 7;

        image.fillAmount = value;

        lastWave = waveManagerScript.wave;
    }
}
