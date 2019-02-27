using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoveringOverObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoveringObject;
    bool hovering = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if(hoveringObject != null)
        {
            hoveringObject.SetActive(true);
            hovering = true;
        }
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoveringObject != null)
        {
            hoveringObject.SetActive(false);
            hovering = false;
        }

    }

    private void Update()
    {
        if (hovering)
        {
            //hoveringObject.transform.position = Input.mousePosition;
        }
    }
}

