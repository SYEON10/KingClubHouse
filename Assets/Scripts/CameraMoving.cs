using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public void MoveCamera(int x)
    {
        Camera.main?.transform.DOMove(new Vector3(x, 0f, -10f), 3f);
    }
}
