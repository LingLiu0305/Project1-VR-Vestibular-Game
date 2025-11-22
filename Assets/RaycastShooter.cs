using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShooter : MonoBehaviour
{
    public ParticleSystem fireEffect;
    public InputActionProperty triggerAction;
    public float maxDistance = 100f;
    public LayerMask hitLayers; // 选中层才能被打到

    void Update()
    {
        if (triggerAction.action.ReadValue<float>() > 0.1f)
        {
            if (!fireEffect.isPlaying)
                fireEffect.Play();

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance, hitLayers))
            {
                if (hit.collider.CompareTag("Meteor"))  // 替换为你的陨石 Tag
                {
                    // 调用碎裂逻辑
                    hit.collider.GetComponent<Breakable>()?.Break();
                }
            }
        }
        else
        {
            if (fireEffect.isPlaying)
                fireEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
