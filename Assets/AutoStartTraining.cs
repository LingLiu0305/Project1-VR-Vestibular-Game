using UnityEngine;

public class AutoStartTraining : MonoBehaviour
{
    [Header("UI 逻辑")]
    public GameObject modeSelectUI;

    [Header("训练逻辑")]
    public Transform trainingRoot;
    public Transform trainingTargetPosition;
    public float moveSpeed = 1f;

    [Header("飞船控制")]
    public GameObject spaceship;
    public float spaceshipStartDelay = 2f;

    [Header("视觉后退模拟")]
    public Transform visualRoot;
    public Vector3 visualMoveOffset = new Vector3(0, 0, -20f);
    public float visualMoveDelay = 1f;

    [Header("引用：计时器")]
    public TrainingTimer trainingTimer;

    private bool isMoving = false;
    private bool shipStarted = false;

    public void BeginTraining()
    {
        Debug.Log("✅ 启动训练流程");

        // 隐藏模式选择 UI
        if (modeSelectUI != null)
            modeSelectUI.SetActive(false);

        // 开始训练移动流程
        isMoving = true;

        // 背景延迟后退
        Invoke(nameof(ForceMoveVisuals), visualMoveDelay);

        // 飞船延迟启动
        Invoke(nameof(StartSpaceship), spaceshipStartDelay);

        // 启动计时器
        if (trainingTimer != null)
            trainingTimer.StartTraining();
    }

    void Update()
    {
        if (isMoving && trainingRoot != null && trainingTargetPosition != null)
        {
            trainingRoot.position = Vector3.Lerp(
                trainingRoot.position,
                trainingTargetPosition.position,
                Time.deltaTime * moveSpeed
            );

            if (Vector3.Distance(trainingRoot.position, trainingTargetPosition.position) < 0.05f)
            {
                isMoving = false;
            }
        }
    }

    public void StartSpaceship()
    {
        if (!shipStarted && spaceship != null)
        {
            var moveScript = spaceship.GetComponent<MoveObject>();
            if (moveScript != null)
            {
                moveScript.StartMoving(); // ✅ 改成调用 StartMoving()
            }

            shipStarted = true;
            Debug.Log("🚀 飞船启动");
        }
    }

    public void StopSpaceship()
    {
        if (spaceship != null)
        {
            var moveScript = spaceship.GetComponent<MoveObject>();
            if (moveScript != null)
            {
                moveScript.StopMoving(); // ✅ 调用 StopMoving()
                Debug.Log("🛑 飞船已停止");
            }
        }
    }


    void ForceMoveVisuals()
    {
        if (visualRoot != null)
        {
            visualRoot.position += visualMoveOffset;
            Debug.Log("📡 视觉后移模拟完成");
        }
    }
}
