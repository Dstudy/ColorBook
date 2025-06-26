using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    private void Awake()
    {
       var bounds = GetComponent<SpriteRenderer>().bounds;
       Globals.WorldBounds = bounds;
    }
    
    
}