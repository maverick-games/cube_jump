using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool _moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(3.056f, -2.98f, -0.723f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CubeJump.nextPlatform)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            }
            else if (transform.position != target && !_moved)
            {
                // 6 минута https://www.youtube.com/watch?v=_DIhTZ35gOk&list=PL0lO_mIqDDFVuqf113xXF-0JaglMUMXCV&index=10
//                target = new Vector3();
//                _moved = true;
            }
        }
    }
}
