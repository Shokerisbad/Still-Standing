using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject volumeCheckmark = null;
    [SerializeField]
    private Slider volumeSlider = null;
    private bool isVolumeActive = true;
    private float volume = 0.5f;

    [SerializeField]
    private GameObject sfxCheckmark = null;
    [SerializeField]
    private Slider sfxSlider = null;
    private bool isSfxActive = true;
    private float sfx = 0.5f;

    [SerializeField]
    private GameObject fullscreenCheckmark = null;

    void Update()
    {
        if (volumeSlider.value == 0)
        {
            isVolumeActive = false;
            volumeCheckmark.SetActive(false);
        }
        else
        {
            volume = volumeSlider.value;
            isVolumeActive = true;
            volumeCheckmark.SetActive(true);
        }

        if (sfxSlider.value == 0)
        {
            isSfxActive = false;
            sfxCheckmark.SetActive(false);
        }
        else
        {
            sfx = sfxSlider.value;
            isSfxActive = true;
            sfxCheckmark.SetActive(true);
        }
    }

    public void TogleVolume()
    {
        isVolumeActive = !isVolumeActive;
        volumeCheckmark.SetActive(isVolumeActive);

        if (isVolumeActive)
            volumeSlider.value = (volume == 0) ? 0.5f:volume;
        else
            volumeSlider.value = 0;
    }

    public void TogleSFX()
    {
        isSfxActive = !isSfxActive;
        sfxCheckmark.SetActive(isSfxActive);

        if (isSfxActive)
            sfxSlider.value = (sfx == 0) ? 0.5f : sfx;
        else
            sfxSlider.value = 0;
    }

    public void FullscreenTogle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullscreenCheckmark.SetActive(!Screen.fullScreen);
        if(!Screen.fullScreen)
            Screen.SetResolution(1920, 1080, true);
        else
            Screen.SetResolution(1920, 1080, false);
    }
}
