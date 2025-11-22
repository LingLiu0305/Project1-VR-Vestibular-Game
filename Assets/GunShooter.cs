using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunShooter : MonoBehaviour
{
    [Header("发射设置")]
    public Transform shootSource;               // 射线起点（枪口）
    public float shootDistance = 100f;
    public LayerMask layerMask;                 // 陨石所在 Layer

    [Header("视觉特效")]
    public ParticleSystem muzzleFlash;          // 枪口粒子特效（可选）
    public AudioSource shootSound;              // 枪声（可选）

    void Update()
    {
        // Quest 右手扳机键
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 播放粒子特效
        if (muzzleFlash != null)
            muzzleFlash.Play();

        // 播放声音
        if (shootSound != null)
            shootSound.Play();

        // 发射射线
        Ray ray = new Ray(shootSource.position, shootSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, shootDistance, layerMask))
        {
            Meteor meteor = hit.collider.GetComponent<Meteor>();
            if (meteor != null)
            {
                meteor.DestroyMeteor();
                Debug.Log("命中陨石！");
            }
        }
    }
}
