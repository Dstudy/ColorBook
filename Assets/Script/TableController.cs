using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject table;
    public void HitButtonFillBucket()
    {
        Coloring.enabled = table.activeInHierarchy ? true : false;
        table.SetActive(table.activeInHierarchy ? false : true);
    }
}
