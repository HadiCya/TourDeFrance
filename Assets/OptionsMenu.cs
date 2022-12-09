using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    AudioSource backgroundMusic;
    [SerializeField]
    Slider masterVolumeBar;

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeBar.minValue = 0;
        masterVolumeBar.maxValue = 1;
    }

    public void UpdateVolumeBarFillToMusicVolume()
    {
        masterVolumeBar.value = backgroundMusic.volume;
    }

    public void UpdateMasterVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
