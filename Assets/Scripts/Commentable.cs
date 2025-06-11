using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Commentable : MonoBehaviour, IPointerClickHandler
{
    public string comment;
    public GameObject bubble;
    public TextMeshProUGUI text;
    private static bool isOn = false;

    IEnumerator PopBubble()
    {
        if (isOn) yield break;
        
        bubble.SetActive(true);
        text.text = comment;
        isOn = true;
        
        yield return new WaitForSeconds(2f);
        bubble.SetActive(false);
        isOn = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(PopBubble());
    }
}
