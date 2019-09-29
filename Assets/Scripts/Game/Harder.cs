using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    private bool hardMode;

    // Update is called once per frame
    void Update()
    {
        if (CubeJump.countBlocks == 0) return;
        if (CubeJump.countBlocks % 2 == 0 && !hardMode)
        {
            // https://www.youtube.com/watch?v=kdI6lSFFB9I&list=PL0lO_mIqDDFVuqf113xXF-0JaglMUMXCV&index=12&t=3s
            // 5 минута
            hardMode = true;
            print("hard mode");
            Camera.main.GetComponent<Animation>().Play("Hard");
        }
        else if (CubeJump.countBlocks % 3 == 0 && hardMode)
        {
            hardMode = false;
            print("easy mode");
            Camera.main.GetComponent<Animation>().Play("Easy");
        }
    }
}
