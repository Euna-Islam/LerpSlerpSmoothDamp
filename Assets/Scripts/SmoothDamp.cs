using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    [SerializeField]
    private Transform StartPoint, EndPoint;
    private Vector3 StartPos, EndPos;
    [SerializeField]
    private FloatVariable smoothTime;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        StartPos = StartPoint.position;
        EndPos = EndPoint.position;
        transform.position = StartPos;
    }

    private void Update()
    {
        MoveWithSmoothDamp();
    }

    void MoveWithSmoothDamp() {
        transform.position = Vector3.SmoothDamp(transform.position, EndPos, ref velocity, smoothTime.value);

        if (Vector3.Distance(transform.position, EndPos) <= 0.001) {
            //swap
            Vector3 temp = StartPos;
            StartPos = EndPos;
            EndPos = temp;
        }
    }
}
