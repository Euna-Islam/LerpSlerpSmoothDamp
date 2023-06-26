using UnityEngine;

public class Slerp : MonoBehaviour
{
    [SerializeField]
    private Transform StartPoint, EndPoint;
    private Vector3 StartPos, EndPos;
    [SerializeField]
    private FloatVariable duration;

    private float elapsedTime = 0f;
    private bool movingForward = true;
    private void Start()
    {
        StartPos = StartPoint.position;
        EndPos = EndPoint.position;
    }

    void Update()
    {
        MoveWithSlerp();
    }

    void MoveWithSlerp() {
        Vector3 center = (StartPos + EndPos) * 0.5F;

        center -= new Vector3(0, 1, 0);

        // Calculate the start and end position based on the movement direction
        Vector3 startPosition = movingForward ? StartPos : EndPos;
        Vector3 targetPosition = movingForward ? EndPos : StartPos;

        Vector3 riseRelCenter = startPosition - center;
        Vector3 setRelCenter = targetPosition - center;

        elapsedTime += Time.deltaTime;
        float normalizedProgress = Mathf.Clamp01(elapsedTime / duration.value);
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, normalizedProgress);
        transform.position += center;

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
