using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CubeJump : MonoBehaviour
{
    public static bool jump, nextPlatform;
    public static int countBlocks;
    public GameObject mainCube, loseButtons, buttons;
    private bool _readyToJump, _lose;
    private float _defaultLocalScaleY;
    private float _collapseSpeed = 0.5f;
    private float _startTime, _yPosCube;

    private void Start()
    {
        _defaultLocalScaleY = mainCube.transform.localScale.y;
        StartCoroutine(canJump());
    }

    private void OnMouseDown()
    {
        if (!nextPlatform || !mainCube.GetComponent<Rigidbody>()) return;
        _readyToJump = true;
        _startTime = Time.time;
        // чет хуйня
        _yPosCube = Mathf.Round(mainCube.transform.localPosition.y);
    }

    private void OnMouseUp()
    {
        if (!_readyToJump || !nextPlatform || !mainCube.GetComponent<Rigidbody>()) return;
        nextPlatform = _readyToJump = false;

        jump = true;
        float force, diff;
        diff = Time.time - _startTime;

        if (diff < 3f) force = 190 * diff;
        else force = 300f;
        if (force < 60f) force = 60f;

        mainCube.GetComponent<Rigidbody>().AddForce(mainCube.transform.up * force);
        mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);
        StartCoroutine(checkCubePos());
    }

    private void FixedUpdate()
    {
        if (!mainCube || !mainCube.GetComponent<Rigidbody>()) return;
        if (_readyToJump)
        {
            collapseCube();
            return;
        }

        expandCube();

        if (!_lose && mainCube.transform.position.y < -7f)
        {
            Destroy(mainCube, 1f);
            print("player lose");
            _lose = true;
        }

        if (_lose) playerLose();
    }

    private void playerLose()
    {
        https: //www.youtube.com/watch?v=qBNQj-Fi6mM&list=PL0lO_mIqDDFVuqf113xXF-0JaglMUMXCV&index=13&t=0s
        // 12 минута (проверка)
        buttons.GetComponent<ScrollObjects>().speed = 5f;
        buttons.GetComponent<ScrollObjects>().checkPos = 0;
        loseButtons.GetComponent<ScrollObjects>().speed = -10f;
        loseButtons.GetComponent<ScrollObjects>().checkPos = 0;
    }

    private void collapseCube()
    {
        if (mainCube.transform.localScale.y < 1f) return;
        mainCube.transform.localPosition -= new Vector3(0f, _collapseSpeed * Time.deltaTime, 0f);
        mainCube.transform.localScale -= new Vector3(0f, _collapseSpeed * Time.deltaTime, 0f);
    }

    private void expandCube()
    {
        if (mainCube.transform.localScale.y > _defaultLocalScaleY) return;
        mainCube.transform.localPosition += new Vector3(0f, _collapseSpeed * 10f * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, _collapseSpeed * 10f * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(1f);
        //  проверка

        if (_yPosCube == Mathf.Round(mainCube.transform.localPosition.y))
        {
            print("player lose");
            _lose = true;
        }

        if (_lose) playerLose();
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (!mainCube) break;
            }

            if (!_lose)
            {
                countBlocks++;
                nextPlatform = true;
                print("next platform");
            }

            if (mainCube)
            {
                var pos = mainCube.transform.localPosition;
                mainCube.transform.localPosition = new Vector3(3.3f, pos.y, pos.z);
                var euler = mainCube.transform.eulerAngles;
                mainCube.transform.eulerAngles = new Vector3(0f, euler.y, 0f);
            }
        }
    }

    IEnumerator canJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);

        yield return new WaitForSeconds(1f);
        nextPlatform = true;
    }
}
