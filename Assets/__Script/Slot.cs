using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public Icon icon;

    public void OnDrop(PointerEventData eventData)
    {
        if(icon == null)
        {
            icon = eventData.pointerDrag.GetComponent<Icon>();

            icon.slot.icon = null;
            icon.slot = this;
        }
    }
}
