using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UIManager))]
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("🧩 默认 UI 设置")]
    public GameObject defaultUI;          // 拖入想自动弹出的 UI 面板
    public bool autoShowOnStart = false;  // 是否自动显示
    public float defaultDistance = 2f;    // 离玩家多远
    public float fadeDuration = 1f;       // 淡入时间（秒）

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (autoShowOnStart && defaultUI != null)
        {
            ShowUIInFront(defaultUI, defaultDistance, true, fadeDuration);
        }
    }

    /// <summary>
    /// 显示 UI 到摄像头前，支持淡入
    /// </summary>
    public void ShowUIInFront(GameObject ui, float distance = 2f, bool fadeIn = true, float fadeTime = 1f)
    {
        if (ui == null) return;

        // 放到摄像头正前
        Transform cam = Camera.main.transform;
        ui.transform.position = cam.position + cam.forward * distance;
        ui.transform.rotation = Quaternion.LookRotation(ui.transform.position - cam.position);
        ui.transform.Rotate(0, 180, 0);

        ui.SetActive(true);

        CanvasGroup cg = ui.GetComponent<CanvasGroup>();
        if (fadeIn && cg != null)
        {
            cg.alpha = 0f;
            StartCoroutine(FadeInCanvasGroup(cg, fadeTime));
        }
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup group, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            group.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }
        group.alpha = 1f;
    }
}
