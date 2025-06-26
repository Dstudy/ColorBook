using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Coloring : MonoBehaviour
{
    public static bool enabled;
    public Color[] colorlist;
    public static Color curColor;
    public int colorCount = -1;
    public Image fillBucket;
    public float distance = 1f;
    public GameObject particle;
    
    void Update()
    {
        if (colorCount == -1)
            return;
        curColor = colorlist[colorCount];

        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, -Vector2.up,distance);
        
        Debug.DrawRay(ray, -Vector2.up, Color.red, distance);
        
        if (Input.GetMouseButtonDown(0) && enabled)
        {
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Color")
                {
                    SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    Debug.Log(hit.collider.name);
                    sp.color = curColor;
                    Instantiate(particle, hit.collider.transform.position, Quaternion.identity);
                    SoundManager.Instance.PlaySound(1);
                }
                
            }
        }
    }

    public void paint(int colorCode)
    {
        colorCount = colorCode;
        fillBucket.color = colorlist[colorCount];
        SoundManager.Instance.PlaySound(0);
    }
    
}
