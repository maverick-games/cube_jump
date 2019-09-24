using UnityEngine;

public class FallCube : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        transform.position -= new Vector3(0, 0.1f, 0);
    }
}
