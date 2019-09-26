using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool _moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(-2.72f, 4.91f, 0.23f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeJump.nextPlatform)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            }
            else if (transform.position == target && !_moved)
            {
                var pos = transform.position;
                target = new Vector3(pos.x - 2.3f, pos.y + 4f, pos.z);
                CubeJump.jump = false;
                _moved = true;
            }

//
            if (CubeJump.jump)
            {
                _moved = false;
            }
        }
    }
}
