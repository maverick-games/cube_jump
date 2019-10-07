using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.UIElements;

public class RandBG : MonoBehaviour
{
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.backgroundColor = colors[Random.Range(0, colors.Length)];
    }
}
