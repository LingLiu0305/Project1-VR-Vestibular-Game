using UnityEngine;

public class Training2UIController : MonoBehaviour
{
    public GameObject introUI;
    public GameObject completeUI;
    public GameObject gunObject;

    public TrainingTimer trainingTimer;

    private bool shownCompleteUI = false;

    public GameObject rayInteractorObject;
    public GameObject pistolObject;

    void Start()
    {
        if (rayInteractorObject != null)
            rayInteractorObject.SetActive(true);

        if (pistolObject != null)
            pistolObject.SetActive(false);

        if (introUI != null)
            introUI.SetActive(true);

        if (completeUI != null)
            completeUI.SetActive(false);
    }

    public void OnIntroContinue()
    {
        if (introUI != null)
            introUI.SetActive(false);

        if (pistolObject != null)
            pistolObject.SetActive(true);

        if (rayInteractorObject != null)
            rayInteractorObject.SetActive(false);

        if (trainingTimer != null)
            trainingTimer.StartTraining();
    }

    void Update()
    {
        if (trainingTimer != null && trainingTimer.IsTrainingComplete() && !shownCompleteUI)
        {
            shownCompleteUI = true;

            if (completeUI != null)
                completeUI.SetActive(true);
        }
    }
}
