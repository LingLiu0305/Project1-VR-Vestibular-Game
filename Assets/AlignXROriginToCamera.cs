using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AlignXROriginToCamera : MonoBehaviour
{
    public Transform cameraTransform; // 拖XR Rig下的Main Camera
    public Transform xrOrigin;        // 拖XR Origin对象

    void Start()
    {
        if (cameraTransform != null && xrOrigin != null)
        {
            // 1. 获取 Main Camera 和 XR Origin 的水平旋转角度差
            float angleDifference = cameraTransform.eulerAngles.y - xrOrigin.eulerAngles.y;

            // 2. 旋转 XR Origin，使其与摄像头朝向一致
            xrOrigin.Rotate(0, angleDifference, 0);

            // 3. 把 XR Origin 移动到摄像头当前位置（但保持摄像头在 Rig 内的位置不变）
            Vector3 offset = xrOrigin.position - cameraTransform.position;
            xrOrigin.position -= new Vector3(offset.x, 0, offset.z); // 保留摄像头高度
        }
    }
}
