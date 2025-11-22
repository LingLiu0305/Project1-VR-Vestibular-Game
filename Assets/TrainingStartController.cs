using System.Collections.Generic;
using UnityEngine;

public class TrainingStartController : MonoBehaviour
{
    [Header("训练前的提示")]
    public GameObject introUI;

    [Header("训练逻辑")]
    public TrainingTimer trainingTimer;

    [Header("要激活的物体（会自动查找脚本）")]
    public List<GameObject> objectsToActivate;

    void Start()
    {
        if (introUI != null)
            introUI.SetActive(true);

        if (trainingTimer != null)
            trainingTimer.autoStart = false; // 禁止自动启动
    }

    // ✅ 这个方法供 Start 按钮点击时调用
    public void OnStartButtonClicked()
    {
        if (introUI != null)
            introUI.SetActive(false);

        if (trainingTimer != null)
            trainingTimer.StartTraining();

        foreach (var obj in objectsToActivate)
        {
            if (obj == null) continue;

            var floatScript = obj.GetComponent<FloatAndRotate>();
            if (floatScript != null) floatScript.EnableFloatAndRotate();

            var moveScript = obj.GetComponent<ObstacleMove>();
            if (moveScript != null) moveScript.EnableMovement();
        }

        Debug.Log("✅ 手动点击 Start 后，训练正式开始");
    }
}
