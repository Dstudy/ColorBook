using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtl : MonoBehaviour
{
    public List<GameObject> prefabs;

    private void Start()
    {
        Instantiate(prefabs[DataManager.currentLevel - 1], Vector3.zero, Quaternion.identity);
    }
}
