using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button continueButton;
    public Button settingButton;
    public Button menuButton;
    public Button pauseButton;
    public GameObject pauseMenu;
    public GameObject settingPanel;
    // public List<GameObject> activeObjects;
    
    public Button exitSettingButton;

    private void Awake()
    {   
        pauseButton.onClick.AddListener(PauseButtonClick);
        continueButton.onClick.AddListener(ContinueButtonClick);
        menuButton.onClick.AddListener(MenuButtonClick);
        settingButton.onClick.AddListener(SettingButtonClick);
        exitSettingButton.onClick.AddListener(ExitSettingButton);
        
    }
    
    void PauseButtonClick()
    {
        SoundManager.Instance.PlaySound(0);
        // activeObjects.ForEach(obj => obj.SetActive(false));
        PanZoomCtl.enabled = false;
        pauseMenu.gameObject.SetActive(true);
        Debug.Log("Setting Button Clicked");
        Coloring.enabled = false;
    }
    
    void ContinueButtonClick()
    {
        SoundManager.Instance.PlaySound(0);
        // activeObjects.ForEach(obj => obj.SetActive(true));
        PanZoomCtl.enabled = true;
        pauseMenu.gameObject.SetActive(false);
        Debug.Log("Exit Menu Button Clicked");
        Coloring.enabled = true;
    }
    
    void ExitSettingButton()
    {
        SoundManager.Instance.PlaySound(0);
        // activeObjects.ForEach(obj => obj.SetActive(true));
        PanZoomCtl.enabled = true;
        settingPanel.gameObject.SetActive(false);
        Coloring.enabled = true;
    }
    
    void MenuButtonClick()
    {
        SoundManager.Instance.PlaySound(0);
        SceneManager.LoadScene("MainMenu");
        PanZoomCtl.enabled = true;
        Coloring.enabled = false;
    }
    
    void SettingButtonClick()
    {
        SoundManager.Instance.PlaySound(0);
        pauseMenu.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(true);
        Coloring.enabled = false;
    }
}
