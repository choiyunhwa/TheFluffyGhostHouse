using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoObject : MonoBehaviour
{
    public GameObject canvas;

    public void ControlCanvas(bool value)
    {
        canvas.SetActive(value);
    }
}
