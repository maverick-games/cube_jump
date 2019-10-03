using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    public GameObject buttons, scene, mainCube, cubes, diamonds;
    public GameObject[] cubesForRemove;
    public Text gameName, playText, hint, record;
    private bool _gameStart, _hintActive;

    private void Start()
    {
        // Запустим анимацию главного кубика
        mainCube.GetComponent<Animation>().Play("Main Cube");
    }

    private void OnMouseDown()
    {
        if (_hintActive)
        {
            hint.gameObject.SetActive(false);
            _hintActive = false;
        }

        if (_gameStart) return;
        diamonds.gameObject.SetActive(true);
        record.gameObject.SetActive(true);
        _hintActive = true;
        hint.gameObject.SetActive(true);
        _gameStart = true;
        startGame();
    }

    private void playAnimations()
    {
        mainCube.GetComponent<Animation>().Play("StartGameCube");
        cubes.GetComponent<Animation>().Play();
    }

    private void startGame()
    {
        StartCoroutine(deleteCubes());
        playAnimations();
        playText.gameObject.SetActive(false);
        gameName.text = "0";
        buttons.GetComponent<ScrollObjects>().speed = -5;
        buttons.GetComponent<ScrollObjects>().checkPos = -90f;
    }

    IEnumerator deleteCubes()
    {
        for (var i = 0; i < cubesForRemove.Length; i++)
        {
            if (i == cubesForRemove.Length - 1)
            {
                // Полуошибка говорит что слишком дорогой метод вызывается в цикле
                // Нашел статейку почитать когда дойдет дело
                // https://docs.microsoft.com/ru-ru/windows/mixed-reality/performance-recommendations-for-unity
                startGame(cubesForRemove[i]);
                continue;
            }

            yield return new WaitForSeconds(0.3f);
            dropCube(cubesForRemove[i]);
        }

        scene.GetComponent<SpawnBlocks>().enabled = true;
    }


    private void startGame(GameObject cube)
    {
        cube.GetComponent<Animation>().Play("CubeToPlatform");
        mainCube.AddComponent<Rigidbody>();
    }

    private void dropCube(GameObject cube)
    {
        cube.GetComponent<FallCube>().enabled = true;
    }
}
