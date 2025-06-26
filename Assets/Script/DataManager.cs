using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager Instance;
    public static int currentLevel;

    private void Awake()
    {
        Instance = this;
    }
}
