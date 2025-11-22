using UnityEngine;

public class ModeSelectionController : MonoBehaviour
{
    public GameObject modeSelectUI;
    public Transform trainingRoot;
    public Transform trainingTargetPosition;
    public float moveSpeed = 2f;
    public GameObject spaceship;

    private bool isMoving = false;
    private bool shipStarted = false;

    void Update()
    {
        if (isMoving)
        {
            trainingRoot.position = Vector3.MoveTowards(
                trainingRoot.position,
                trainingTargetPosition.position,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(trainingRoot.position, trainingTargetPosition.position) < 0.05f)
            {
                isMoving = false;

                if (!shipStarted && spaceship != null)
                {
                    spaceship.GetComponent<MoveObject>().StartMoving();
                    shipStarted = true;
                }
            }
        }
    }

    public void OnEasyModeSelected()
    {
        modeSelectUI.SetActive(false);
        isMoving = true;
    }
}

