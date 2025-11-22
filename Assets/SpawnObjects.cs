using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs;  // 存放物体的Prefab
    public int totalObjects = 20;       // 总共需要生成的物体数量
    public float spawnInterval = 2f;    // 每个物体生成的时间间隔（固定2秒）
    public float destroyDelay = 5f;     // 物体生成后多久销毁

    public Vector3 spawnAreaMin;  // 物体生成区域的最小值
    public Vector3 spawnAreaMax;  // 物体生成区域的最大值

    private GameObject[] spawnedObjects;  // 存放生成的物体

    void Start()
    {
        // 初始化物体数组，并将所有物体的启用状态设置为不可见（不激活）
        spawnedObjects = new GameObject[totalObjects];

        // 为每个物体创建一个实例，并将其初始状态设置为不可见
        for (int i = 0; i < totalObjects; i++)
        {
            // 在长方形区域内随机生成位置
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x), // 随机X位置
                Random.Range(spawnAreaMin.y, spawnAreaMax.y), // 随机Y位置
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)  // 随机Z位置
            );

            // 实例化物体并设置随机位置
            spawnedObjects[i] = Instantiate(objectPrefabs[i % objectPrefabs.Length], randomPosition, Quaternion.identity);
            spawnedObjects[i].SetActive(false); // 设置初始为不可见
        }

        // 调用协程来生成物体
        StartCoroutine(SpawnObjectsCoroutine());
    }

    // 协程，控制物体的生成
    IEnumerator SpawnObjectsCoroutine()
    {
        for (int i = 0; i < totalObjects; i++)
        {
            // 激活物体
            spawnedObjects[i].SetActive(true); // 使物体可见

            // 等待指定时间间隔（2秒）
            yield return new WaitForSeconds(spawnInterval);

            // 销毁物体，延迟destroyDelay秒
            Destroy(spawnedObjects[i], destroyDelay); // 在一定时间后销毁物体
        }
    }
}