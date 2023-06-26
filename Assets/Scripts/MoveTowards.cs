using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField]
    private Transform StartPoint, EndPoint;
    private Vector3 StartPos, EndPos;
    [SerializeField]
    private FloatVariable Speed;

    private void Start()
    {
        StartPos = StartPoint.position;
        EndPos = EndPoint.position;
        transform.position = StartPos;
    }

    private void Update()
    {
        MoveWithMoveTowards();
    }
    void MoveWithMoveTowards() {
        var step = Speed.value * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, EndPos, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, EndPos) < 0.001f)
        {
            //swap
            Vector3 temp = StartPos;
            StartPos = EndPos;
            EndPos = temp;
        }
    }
}
