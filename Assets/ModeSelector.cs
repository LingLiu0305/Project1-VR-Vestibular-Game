using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    public AutoStartTraining autoStartTraining;

    public void OnSelectMode(string mode)
    {
        Debug.Log("🎮 Selected Mode: " + mode);

        if (mode == "Easy")
        {
            autoStartTraining.BeginTraining(); // ✅ 正确方法名
        }

        // 未来扩展 Hard 模式
        // else if (mode == "Hard") { ... }
    }
}
