using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    public GameObject detectCLicks;
    private bool hardMode;


    // Update is called once per frame
    void Update()
    {
        if (CubeJump.countBlocks == 0) return;
        if (CubeJump.countBlocks % 2 == 0 && !hardMode)
        {
            hardMode = true;
            print("hard mode");
            Camera.main.GetComponent<Animation>().Play("Hard");
            detectCLicks.transform.position = new Vector3(24.5f, 17.8f, -13.7f);
            detectCLicks.transform.eulerAngles = new Vector3(34.1f, -65.2f, 2.3f);
        }
        else if (CubeJump.countBlocks % 3 == 0 && hardMode)
        {
            hardMode = false;
            print("easy mode");
            Camera.main.GetComponent<Animation>().Play("Easy");
            detectCLicks.transform.position = new Vector3(2.11f, 10.3f, -20f);
            detectCLicks.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
