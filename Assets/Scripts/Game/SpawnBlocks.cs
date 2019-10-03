using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject platform, allCubes, diamond;
    private GameObject platformInst;
    public float speed = 5f;
    private Vector3 blockPos;
    private bool _onPlace;

    private void Start()
    {
        spawnBlock();
    }

    private void Update()
    {
        if (platformInst.transform.position != blockPos && !_onPlace)
        {
            platformInst.transform.position = Vector3.MoveTowards(platformInst.transform.position, blockPos,
                Time.deltaTime * speed);
        }
        else if (platformInst.transform.position == blockPos)
        {
            _onPlace = true;
        }

        if (CubeJump.jump && CubeJump.nextPlatform)
        {
            spawnBlock();
            _onPlace = false;
        }
    }

    private void spawnBlock()
    {
        blockPos = new Vector3(Random.Range(0.7f, 1.7f), -Random.Range(0.6f, 3.2f), 2f);
        platformInst = Instantiate(platform, new Vector3(5f, -6f, 0f), Quaternion.identity) as GameObject;
        platformInst.transform.localScale = new Vector3(randomScale(), platformInst.transform.localScale.y,
            platformInst.transform.localScale.z);
        platformInst.transform.parent = allCubes.transform;

        if (CubeJump.countBlocks % 2 == 0)
        {
            // https://www.youtube.com/watch?v=BgPiKw8Q6Xk&list=PL0lO_mIqDDFVuqf113xXF-0JaglMUMXCV&index=14&t=108s
            // 10 минута
            // Делаем алмазик дочерним элементом платформы, чтобы они вместе катались)
            GameObject diamondInst = Instantiate(diamond,
                new Vector3(platformInst.transform.position.x, platformInst.transform.position.y + 0.5f,
                    platformInst.transform.position.y), Quaternion.identity);
            diamondInst.transform.parent = platformInst.transform;
        }

        // за камерой крутить
        // Quaternion.Euler(Camera.main.transform.eulerAngles)
    }

    private float randomScale()
    {
        return Random.Range(0, 100) > 80 ? Random.Range(1.2f, 2f) : Random.Range(1.2f, 1.5f);
    }
}
