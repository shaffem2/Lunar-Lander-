using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    private Resolution[] resolutions; // Array of available resolutions
    
    void Start()
    {
        resolutions = Screen.resolutions; // Obtains list of all available resolutions for user's computer
        resolutionDropdown.ClearOptions(); // Clears any resolutions in dropdown menu

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; // Takes array of resolutions and converts them to list of strings
            options.Add(option);

            // Determines your computer's current resolution
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // AddOptions only takes strings
        resolutionDropdown.value = currentResolutionIndex; // Sets current resolution on the dropdown bar to your computer's resolution
        resolutionDropdown.RefreshShownValue();
    }
    
    //Sets volume in the master audio mixer
    public void SetVolume (float sliderValue)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
    }
    
    //Sets game quality (Low/Medium/High)
    public void SetQuality (int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Toggles fullscreen
    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // Sets screen resolution for game
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
