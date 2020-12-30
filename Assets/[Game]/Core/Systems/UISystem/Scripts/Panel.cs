using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    //Use this to access the canvas group.
    public CanvasGroup CanvasGroup
    {
        get
        {
            //Check if canvas group is null
            if(canvasGroup == null)
            {
                //Get if canvas group added to the game object.
                canvasGroup = GetComponent<CanvasGroup>();

                //Check if we successfully get the canvas group
                if (canvasGroup == null)
                    //Means that we don't have canvas group at the gameobject, so add it.
                    canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            return canvasGroup;
        }
    }


    [Button]
    public void ShowPanel()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    [Button]
    public void HidePanel()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    public void ShowPanelAndTurnOffInteraction()
    {
        ShowPanel();
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    public void TurnOnInteraction()
    {
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }
}
