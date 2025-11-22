using UnityEngine;

public class LevelFlowManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject introUI;              // 第一步 UI：玩法介绍
    public GameObject modeSelectUI;         // 第二步 UI：选择模式（含Easy/Hard按钮）

    [Header("训练控制器")]
    public AutoStartTraining trainingStarter;  // 控制实际训练流程的脚本引用

    void Start()
    {
        // 场景加载后，只显示 Intro UI
        introUI.SetActive(true);
        modeSelectUI.SetActive(false);
    }

    // 点击 Intro UI 的“继续”按钮时调用
    public void OnIntroContinue()
    {
        introUI.SetActive(false);
        modeSelectUI.SetActive(true);
        Debug.Log("📘 已进入模式选择界面");
    }

    // 点击模式按钮时调用，例如 Easy / Hard
    public void OnSelectMode(string mode)
    {
        Debug.Log("🎮 Selected Mode: " + mode);

        modeSelectUI.SetActive(false); // 隐藏模式选择 UI

        if (mode == "Easy")
        {
            trainingStarter.BeginTraining(); // 启动训练流程
        }

        // 可扩展 Hard 模式逻辑：
        // else if (mode == "Hard") { ... }
    }
}
