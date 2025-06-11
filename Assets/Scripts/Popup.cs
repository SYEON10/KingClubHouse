using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Image _image;
    public TextMeshProUGUI _text;
    public TextMeshProUGUI _name;

    public void SetInformation(Sprite image)
    {
        _image.sprite = image;
    }
}
