using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedAni : MonoBehaviour
{
    private Shadow shadow;
    
    private void Start()
    {
        shadow = GetComponent<Shadow>();
    }
    
    public void Selected()
    {
        shadow.effectColor = Coloring.curColor;
    }
}
