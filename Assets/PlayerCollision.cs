using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("撞到障碍啦！");
            // 这里可以加UI、震动、音效、减分等
        }
    }
}

