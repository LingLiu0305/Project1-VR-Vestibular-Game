using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPositionSwitcher : MonoBehaviour
{
    public Transform trainingPosition;  // 凝视训练区域目标位置
    public Transform exteriorPosition;  // 空间站外部目标位置
    public float transitionSpeed = 1f;  // 移动速度

    private Transform xrRigTransform;

    void Start()
    {
        // 获取 XR Rig 的 Transform
        xrRigTransform = Camera.main.transform.parent;  // XR Rig 是摄像机的父物体
    }

    // 切换到空间站外部
    public void SwitchToExterior()
    {
        StartCoroutine(SmoothMove(exteriorPosition));  // 平滑过渡到外部位置
    }

    // 切换到凝视训练区域
    public void SwitchToTraining()
    {
        StartCoroutine(SmoothMove(trainingPosition));  // 平滑过渡到训练位置
    }

    // 平滑过渡摄像机（XR Rig）位置和旋转
    private IEnumerator SmoothMove(Transform targetPosition)
    {
        Vector3 startPosition = xrRigTransform.position;
        Quaternion startRotation = xrRigTransform.rotation;

        float elapsedTime = 0f;

        // 平滑过渡位置和旋转
        while (elapsedTime < 1f)
        {
            xrRigTransform.position = Vector3.Lerp(startPosition, targetPosition.position, elapsedTime);
            xrRigTransform.rotation = Quaternion.Lerp(startRotation, targetPosition.rotation, elapsedTime);
            elapsedTime += Time.deltaTime * transitionSpeed;  // 增加时间流逝
            yield return null;
        }

        // 确保最终位置和旋转是目标位置
        xrRigTransform.position = targetPosition.position;
        xrRigTransform.rotation = targetPosition.rotation;
    }
}
