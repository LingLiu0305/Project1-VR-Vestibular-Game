using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 用于按钮交互
using UnityEngine.SceneManagement;  // 用于加载场景

public class ButtonController : MonoBehaviour
{
    public Button easyButton;    // Easy mode button
    public Button mediumButton;  // Medium mode button
    public Button hardButton;    // Hard mode button

    void Start()
    {
        // 设置 Easy mode 按钮为可点击
        easyButton.interactable = true;

        // 设置 Medium 和 Hard 按钮为不可点击
        mediumButton.interactable = false;
        hardButton.interactable = false;

        // 绑定按钮点击事件
        easyButton.onClick.AddListener(StartEasyMode);
        mediumButton.onClick.AddListener(DisabledMode);
        hardButton.onClick.AddListener(DisabledMode);
    }

    // Easy mode 按钮的点击事件
    void StartEasyMode()
    {
        SceneManager.LoadScene("EasyTraining");  // 加载 Easy Mode 场景
    }

    // Medium 和 Hard mode 按钮的点击事件
    void DisabledMode()
    {
        Debug.Log("This mode is not available");  // 输出不可用的提示
    }
}