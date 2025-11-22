using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 用于按钮交互
using UnityEngine.SceneManagement;  // 用于加载场景

public class LevelSelector : MonoBehaviour
{
    public Button easyButton;    // Easy Mode 按钮
    public Button mediumButton;  // Medium Mode 按钮
    public Button hardButton;    // Hard Mode 按钮

    public GameObject trainingUI;   // 显示凝视训练的UI
    public GameObject modeSelectUI; // 显示选择模式的UI

    void Start()
    {
        // 设置 Easy Mode 按钮为可点击，其他按钮为不可点击
        easyButton.interactable = true;
        mediumButton.interactable = false;
        hardButton.interactable = false;

        // 绑定按钮点击事件
        easyButton.onClick.AddListener(StartEasyMode);
        mediumButton.onClick.AddListener(DisabledMode);
        hardButton.onClick.AddListener(DisabledMode);

        // 隐藏凝视训练UI
        trainingUI.SetActive(false);
    }

    // 当点击 Easy Mode 按钮时，开始训练
    void StartEasyMode()
    {
        // 隐藏模式选择 UI
        modeSelectUI.SetActive(false);

        // 显示凝视训练 UI
        trainingUI.SetActive(true);

        // 启动 Easy Mode 任务，可以在此启动凝视训练的任务
        Debug.Log("开始 Easy Mode 训练！");
        // 这里你可以加载具体的训练任务或者执行其他逻辑
    }

    // 禁用 Medium 和 Hard Mode 按钮
    void DisabledMode()
    {
        Debug.Log("该模式不可用！");
    }
}