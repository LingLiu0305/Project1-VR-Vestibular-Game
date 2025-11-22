using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightHandTriggerParticle : MonoBehaviour
{
    [Header("粒子系统")]
    public ParticleSystem particles;

    [Header("右手 Trigger 输入动作")]
    public InputActionProperty triggerAction;  // 输入来自 XR Controller 的 Trigger

    void Start()
    {
        // 确保一开始不播放
        if (particles != null)
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    void Update()
    {
        if (triggerAction == null || triggerAction.action == null) return;

        float triggerValue = triggerAction.action.ReadValue<float>();

        if (triggerValue > 0.1f)
        {
            if (!particles.isPlaying)
                particles.Play();
        }
        else
        {
            if (particles.isPlaying)
                particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}

