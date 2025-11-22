using System.Collections;
using UnityEngine;


public class TrainingTimer : MonoBehaviour
{
    [Header("训练控制")]
    public bool autoStart = false;              
    public float trainingDuration = 60f;        

    [Header("UI 和场景逻辑")]
    public GameObject trainingCompleteUI;       
    public SceneFadeManager sceneFadeManager;   

    [Header("可选控制器")]
    public AutoStartTraining trainingController; 

    public GameObject pistolObject;        
    public GameObject rayInteractorObject;  

    private float timer = 0f;
    private bool isTraining = false;
    private bool isComplete = false;

    void Start()
    {
        if (trainingCompleteUI != null)
            trainingCompleteUI.SetActive(false);  

        if (autoStart)
        {
            Debug.Log("autoStart 启用，自动开始训练");
            StartTraining();
        }
    }

    void Update()
    {
        if (!isTraining || isComplete) return;

        timer += Time.deltaTime;

        if (timer >= trainingDuration)
        {
            isComplete = true;
            StartCoroutine(HandleTrainingComplete());
        }
    }

    
    public void StartTraining()
    {
        if (isTraining) return;

        isTraining = true;
        isComplete = false;
        timer = 0f;

        if (trainingCompleteUI != null)
            trainingCompleteUI.SetActive(false);

        Debug.Log("Training Started");
    }

    
    IEnumerator HandleTrainingComplete()
    {
        Debug.Log("Training Complete");

       
        if (trainingController != null)
        {
            trainingController.StopSpaceship();
            Debug.Log("飞船已停止");
        }

      
        if (pistolObject != null) pistolObject.SetActive(false);
        if (rayInteractorObject != null) rayInteractorObject.SetActive(true);

 
        if (trainingCompleteUI != null)
            trainingCompleteUI.SetActive(true);

        yield return null;
    }

    
    public void LoadNextLevelManually()
    {
        if (sceneFadeManager != null)
        {
            sceneFadeManager.LoadNextScene();
            Debug.Log("NextScene");
        }
        else
        {
            Debug.LogWarning("❗SceneFadeManager 未绑定！");
        }
    }

    
    public bool IsTrainingStarted()
    {
        return isTraining;
    }

   
    public bool IsTrainingComplete()
    {
        return isComplete;
    }
}
