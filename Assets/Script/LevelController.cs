using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    private LevelController LvlCtl;

    private void Awake()
    {
        LvlCtl = this;
    }

    private void Start()
    {
        buttons.AddRange(GetComponentsInChildren<Button>());
        buttons.ForEach(button => button.onClick.AddListener(() => ButtonClicked(button)));
    }
    
    void ButtonClicked(Button button)
    {
        if (button.name == "Level1")
        {
            SoundManager.Instance.PlaySound(0);
            SceneManager.LoadScene("MainGame");
            DataManager.currentLevel = 1;
        }
        if (button.name == "Level2")
        {
            SoundManager.Instance.PlaySound(0);
            SceneManager.LoadScene("MainGame");
            DataManager.currentLevel = 2;
        }
    }
}
