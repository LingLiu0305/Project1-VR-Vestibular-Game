using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed = 2f;     // 控制移动速度
    public float destroyX = 10f;     // 超出边界时销毁

    private bool canMove = false;    // 是否启用移动

    void Update()
    {
        if (!canMove) return;

        // 沿世界坐标 X 正方向移动
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);

        // 到达边界就销毁
        if (transform.position.x > destroyX)
        {
            Destroy(gameObject);
        }
    }

    // ✅ 外部控制启用移动
    public void EnableMovement()
    {
        canMove = true;
    }
}
