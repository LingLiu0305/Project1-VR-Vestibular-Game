using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    private Vector3 initialRotation;

    void Start()
    {
        // 设置新的初始旋转角度
        initialRotation = transform.rotation.eulerAngles;
    }

    public void ResetToInitialRotation()
    {
        // 将旋转恢复到新的初始角度
        transform.rotation = Quaternion.Euler(initialRotation);
    }
}
