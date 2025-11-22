using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [Header("浮动参数")]
    public float floatSpeed = 0.5f;     // 上下浮动速度
    public float floatHeight = 0.2f;    // 浮动幅度
    public float rotationSpeed = 20f;   // 自转速度

    private Vector3 startPos;
    private bool canFloat = false;      // 是否启用浮动和旋转

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!canFloat) return;

        // 上下浮动
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 自转
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // ✅ 外部调用这个方法即可启用浮动与旋转
    public void EnableFloatAndRotate()
    {
        canFloat = true;
    }
}
