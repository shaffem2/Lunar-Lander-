using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private int fullscreenSwitch = 1;

    void Start()
    {   
        resolutions = Screen.resolutions; // Obtains list of all available resolutions for user's computer
        resolutionDropdown.ClearOptions(); // Clears any resolutions in dropdown menu

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz"; // Takes array of resolutions and converts them to list of strings
            options.Add(option);

            // Determines your computer's current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // AddOptions only takes strings
        resolutionDropdown.value = currentResolutionIndex; // Sets current resolution on the dropdown bar to your computer's resolution
        resolutionDropdown.RefreshShownValue();

        // Get last positions/values of UI
        musicSlider.value = PlayerPrefs.GetFloat("volume");
        qualityDropdown.value = PlayerPrefs.GetInt("quality");
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution");
        fullscreenSwitch = PlayerPrefs.GetInt("fullscreen");
        if (fullscreenSwitch == 1)
        {
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
    }

    // Sets volume in the master audio mixer
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("volume", value);
    }

    // Sets game quality (Low/Medium/High)
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    // Toggles fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            fullscreenSwitch = 1;
        }
        else
        {
            fullscreenSwitch = 0;
        }
        PlayerPrefs.SetInt("fullscreen", fullscreenSwitch);
    }

    // Sets screen resolution for game
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
    }
    
    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
