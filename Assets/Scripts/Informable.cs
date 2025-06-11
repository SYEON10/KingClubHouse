using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Informable : MonoBehaviour, IPointerClickHandler
{
    private static Popup _popup;
    public Sprite image;

    void Awake()
    {
        if (_popup is null)
        {
            _popup = FindObjectOfType<Popup>();
            _popup.gameObject.SetActive(false);
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _popup.SetInformation(image);
        _popup.gameObject.SetActive(true);
    }
}
