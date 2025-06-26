using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform viewportTransform;
    public RectTransform contentPanelTransform;
    public HorizontalLayoutGroup HLG;

    public RectTransform[] ItemList;


    private Vector2 OldVelocity;
    private bool isUpdated;
    private void Start()
    {
        isUpdated = false;
        OldVelocity = Vector2.zero;
        int ItemstoAdd = Mathf.CeilToInt(viewportTransform.rect.width / (ItemList[0].rect.width + HLG.spacing));
        Debug.Log(ItemstoAdd);

        for (int i = 0; i < ItemstoAdd; i++)
        {
            RectTransform RT = Instantiate(ItemList[i%ItemList.Length], contentPanelTransform);
            RT.SetAsLastSibling();
        }
        
        for (int i = 0; i < ItemstoAdd; i++)
        {
            int num = ItemList.Length - i - 1;
            while (num < 0)
            {
                num += ItemList.Length;
            }
            RectTransform RT = Instantiate(ItemList[num], contentPanelTransform);
            RT.SetAsFirstSibling();
        }
        
        contentPanelTransform.localPosition = new Vector3(0 - (ItemList[0].rect.width + HLG.spacing) * ItemstoAdd, 
            contentPanelTransform.localPosition.y, contentPanelTransform.localPosition.z);
    }

    private void Update()
    {
        if (isUpdated)
        {
            scrollRect.velocity = OldVelocity;
            isUpdated = false;
        }
        
        if(contentPanelTransform.localPosition.x > -100)
        {
            Canvas.ForceUpdateCanvases();
            OldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition -= new Vector3(ItemList.Length * (ItemList[0].rect.width + HLG.spacing), 0,0);
            isUpdated = true;
        }
        if(contentPanelTransform.localPosition.x < (0 - (ItemList.Length * (ItemList[0].rect.width + HLG.spacing))))
        {
            Debug.Log(0 - (ItemList.Length * (ItemList[0].rect.width + HLG.spacing)));
            Canvas.ForceUpdateCanvases();
            OldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition += new Vector3(ItemList.Length * (ItemList[0].rect.width + HLG.spacing), 0,0);
            isUpdated = true;
        } 
    }
}
