using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button settingButton;
    public Button exitSettingButton;
    public Button exitButton;
    public GameObject settingPanel;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        settingButton.onClick.AddListener(SettingButton);
        exitSettingButton.onClick.AddListener(ExitSettingButton);
        exitButton.onClick.AddListener(ExitButton);
    }
    
    void PlayButton()
    {
        SoundManager.Instance.PlaySound(0);
        SceneManager.LoadScene("MainLevel");
        PanZoomCtl.enabled = true;
    }
    
    void SettingButton()    
    {
        SoundManager.Instance.PlaySound(0);
        settingPanel.gameObject.SetActive(true);
        Debug.Log("Setting Button Clicked");
    }
    
    void ExitSettingButton()
    {
        SoundManager.Instance.PlaySound(0);
        settingPanel.gameObject.SetActive(false);
        Debug.Log("Exit Menu Button Clicked");
    }
    
    void ExitButton()
    {
        SoundManager.Instance.PlaySound(0);
        Application.Quit();
    }
}
