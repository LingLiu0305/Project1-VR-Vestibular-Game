using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float explosionForce = 50f;
    public float explosionRadius = 3f;
    public float partLifetime = 3f;

    public void Break()
    {
        // 遍历所有子碎片
        foreach (Transform part in transform)
        {
            // 解绑出来：不再是陨石的子物体
            part.parent = null;

            // 给每个碎片添加 Rigidbody
            Rigidbody rb = part.gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.2f;

            // 加一个爆炸力
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            // 一段时间后销毁碎片
            Destroy(part.gameObject, partLifetime);
        }

        // 最后销毁父物体
        Destroy(gameObject);
    }
}


