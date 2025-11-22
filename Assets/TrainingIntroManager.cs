using UnityEngine;

public class TrainingIntroManager : MonoBehaviour
{
    public GameObject introUI;                  // 第三关的提示面板
    public TrainingTimer trainingTimer;         // 拖入 TrainingTimer 组件

    void Start()
    {
        if (introUI != null)
        {
            introUI.SetActive(true); // 进入场景立即显示提示面板
        }

        if (trainingTimer != null)
        {
            trainingTimer.autoStart = false; // 禁止自动启动
        }
    }

    // 供 UI 按钮调用的函数
    public void OnStartButtonClicked()
    {
        if (introUI != null)
        {
            introUI.SetActive(false); // 隐藏提示面板
        }

        if (trainingTimer != null)
        {
            trainingTimer.StartTraining(); // 手动启动训练
        }

        Debug.Log("🎮 Start 按钮被点击，开始训练");
    }
}
