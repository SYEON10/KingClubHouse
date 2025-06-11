using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject before;
    public GameObject after;

    void Start()
    {
        after.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        after.SetActive(true);
        before.SetActive(false);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        before.SetActive(true);
        after.SetActive(false);
    }
}
