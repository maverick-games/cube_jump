using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandColor : MonoBehaviour
{
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
    }
}
