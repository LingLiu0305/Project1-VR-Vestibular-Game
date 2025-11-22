using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 2f;

    [Header("跳转设置")]
    public int nextSceneIndex = -1; // -1 表示自动跳到下一关

    void Start()
    {
        if (fadeCanvasGroup != null)
            fadeCanvasGroup.alpha = 1f;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            if (fadeCanvasGroup != null)
                fadeCanvasGroup.alpha = 1f - (timer / fadeDuration);
            yield return null;
        }

        if (fadeCanvasGroup != null)
            fadeCanvasGroup.alpha = 0f;
    }

    public void LoadNextScene()
    {
        int indexToLoad = nextSceneIndex;

        if (indexToLoad < 0)
        {
            // 自动跳转到当前关卡的下一关
            indexToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

        StartCoroutine(FadeOutAndLoad(indexToLoad));
    }

    IEnumerator FadeOutAndLoad(int sceneIndex)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            if (fadeCanvasGroup != null)
                fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
