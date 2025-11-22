using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public void DestroyMeteor()
    {
        // 可以加特效/声音
        gameObject.SetActive(false);  // 不销毁，直接隐藏（适配你现在的激活逻辑）
    }
}
