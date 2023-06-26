using UnityEngine;

public class Lerp : MonoBehaviour
{
    [SerializeField]
    private Transform StartPoint, EndPoint;
    private Vector3 StartPos, EndPos;
    public FloatVariable duration;

    private float elapsedTime = 0f;
    private bool movingForward = true;

    private void Start()
    {
        StartPos = StartPoint.position;
        EndPos = EndPoint.position;
    }
    void Update()
    {
        MoveWithLerp();
    }

    void MoveWithLerp() {
        elapsedTime += Time.deltaTime;
        float normalizedProgress = Mathf.Clamp01(elapsedTime / duration.value);

        // Calculate the start and end position based on the movement direction
        Vector3 startPosition = movingForward ? StartPos : EndPos;
        Vector3 targetPosition = movingForward ? EndPos : StartPos;

        Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, normalizedProgress);
        transform.position = newPosition;

        //if loop is complete
        if (normalizedProgress >= 1f)
        {
            // Toggle direction
            movingForward = !movingForward;
            // Reset elapsed time
            elapsedTime = 0f;
        }
    }
}
