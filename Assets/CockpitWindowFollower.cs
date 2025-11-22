using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitWindowFollower : MonoBehaviour
{
    public Transform mainCamera;  // 拖入你的 XR Rig 中的 Camera

    public float distance = 1.5f; // 距离玩家多远
    public float heightOffset = -0.2f; // 稍微低一点位置看起来像窗口
    public float smoothSpeed = 5f; // 平滑移动速度

    void LateUpdate()
    {
        if (mainCamera == null) return;

        // 只使用相机的前向方向，但不要跟随头部左右看
        Vector3 forward = new Vector3(mainCamera.forward.x, 0, mainCamera.forward.z).normalized;
        Vector3 targetPos = mainCamera.position + forward * distance + Vector3.up * heightOffset;

        // 平滑移动到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);

        // 始终面朝相机的 forward 方向
        Quaternion targetRot = Quaternion.LookRotation(forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothSpeed);
    }
}
