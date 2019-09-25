using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject platform, allCubes;
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
        // 9 минута
        // https://www.youtube.com/watch?v=_DIhTZ35gOk&list=PL0lO_mIqDDFVuqf113xXF-0JaglMUMXCV&index=10 
        blockPos = new Vector3(Random.Range(0.7f, 1.7f), -Random.Range(0.6f, 3.2f), 2f);
        platformInst = Instantiate(platform, new Vector3(5f, -6f, 0f), Quaternion.identity) as GameObject;
        platformInst.transform.localScale = new Vector3(randomScale(), platformInst.transform.localScale.y,
            platformInst.transform.localScale.z);
        platformInst.transform.parent = allCubes.transform;
    }

    private float randomScale()
    {
        return Random.Range(0, 100) > 80 ? Random.Range(1.2f, 2f) : Random.Range(1.2f, 1.5f);
    }
}
