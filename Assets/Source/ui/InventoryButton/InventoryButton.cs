using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerDownHandler
{
    public Action PointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown.Invoke();
    }
}