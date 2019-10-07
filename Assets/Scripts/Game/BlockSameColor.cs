using UnityEngine;

public class BlockSameColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
        }
    }
}
