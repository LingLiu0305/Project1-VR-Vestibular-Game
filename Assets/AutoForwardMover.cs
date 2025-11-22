using System.Collections;
using UnityEngine;

public class AutoForwardMover : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public float moveDuration = 8f; // 移动多久（秒）

    [Header("结束UI")]
    public GameObject finalUI; // 拖入“结束提示”UI面板

    private float timer = 0f;
    private bool isMoving = false; // 初始为 false，等待 Start 按钮触发

    void Update()
    {
        if (!isMoving) return;

        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (timer >= moveDuration)
        {
            isMoving = false;

            if (finalUI != null)
                finalUI.SetActive(true);

            Debug.Log("✅ 结束移动，显示 Final UI");
        }
    }

    // 👉 点击 Start 按钮时调用这个方法
    public void StartMoving()
    {
        isMoving = true;
        timer = 0f;

        Debug.Log("▶️ 开始移动");
    }
}
