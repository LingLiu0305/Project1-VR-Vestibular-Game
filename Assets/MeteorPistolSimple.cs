using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeteorPistolSimple : MonoBehaviour
{
    [Header("输入控制")]
    public InputActionProperty triggerAction;

    [Header("粒子系统")]
    public ParticleSystem fireEffect;

    [Header("射线参数")]
    public float fireDistance = 100f;
    public LayerMask hitLayers;

    void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();

        if (triggerValue > 0.1f)
        {
            if (!fireEffect.isPlaying)
                fireEffect.Play();

            Shoot();
        }
        else
        {
            if (fireEffect.isPlaying)
                fireEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, fireDistance, hitLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // 获取打中物体的根节点（陨石整体）
            GameObject root = hit.collider.transform.root.gameObject;

            // 销毁整个陨石，而不是只销毁一个碎片
            Destroy(root);
        }
    }
}
