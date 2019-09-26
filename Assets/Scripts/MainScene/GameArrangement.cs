using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    public GameObject buttons, scene, mainCube, cubes;
    public GameObject[] cubesForRemove;
    public Text gameName, playText;
    private bool _gameStart;

    private void Start()
    {
        // Запустим анимацию главного кубика
        mainCube.GetComponent<Animation>().Play("Main Cube");
    }

    private void OnMouseDown()
    {
        if (_gameStart) return;
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
