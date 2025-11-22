using UnityEngine;
using System.Collections.Generic;

public class RandomRevealer : MonoBehaviour
{
    public GameObject[] objectsToShow;
    private List<int> hiddenIndices = new List<int>();
    private float timer = 0f;
    public float interval = 2f;

    public TrainingTimer trainingTimer; // 👉 拖入 TrainingController


    void Start()
    {
        for (int i = 0; i < objectsToShow.Length; i++)
        {
            objectsToShow[i].SetActive(false);
            hiddenIndices.Add(i);
        }
    }

    void Update()
    {
        // ✅ 如果没绑定或训练还没开始，就什么都不做
        if (trainingTimer == null || !trainingTimer.IsTrainingStarted()) return;

        if (hiddenIndices.Count == 0) return;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;

            int randomIndex = Random.Range(0, hiddenIndices.Count);
            int objIndex = hiddenIndices[randomIndex];

            objectsToShow[objIndex].SetActive(true);
            hiddenIndices.RemoveAt(randomIndex);
        }
    }
}

