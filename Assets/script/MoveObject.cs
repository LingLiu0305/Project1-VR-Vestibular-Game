using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;

    private Vector3 startPosition;
    private bool isMoving = false;

    void Start()
    {
        startPosition = transform.position;

        // 可选：如果你不想自动开始移动，就注释掉下面这行
        // Invoke("StartMoving", 8f);
    }

    void Update()
    {
        if (!isMoving) return;

        float newPositionX = Mathf.PingPong(Time.time * speed, range * 2) - range;
        transform.position = new Vector3(startPosition.x + newPositionX, transform.position.y, transform.position.z);
    }

    public void StartMoving()
    {
        isMoving = true;
        startPosition = transform.position;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
