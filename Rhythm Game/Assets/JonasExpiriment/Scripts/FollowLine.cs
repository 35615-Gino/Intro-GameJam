using UnityEngine;

public class FollowLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 2.0f;

    private int currentPointIndex = 0;
    private float distanceAlongLine = 0.0f;
    private bool isMoving = true;

    void Start()
    {
        currentPointIndex = 0;
    }

    void Update()
    {
        if (!isMoving)
            return;

        MoveTowardsNextPoint();
    }

    void MoveTowardsNextPoint()
    {
        Vector3[] linePoints = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(linePoints);

        if (currentPointIndex < linePoints.Length - 1)
        {
            float distanceToNextPoint = Vector3.Distance(linePoints[currentPointIndex], linePoints[currentPointIndex + 1]);
            float distanceToMove = speed * Time.deltaTime;

            while (distanceAlongLine + distanceToMove >= distanceToNextPoint)
            {
                distanceToMove -= (distanceToNextPoint - distanceAlongLine);
                distanceAlongLine = 0.0f;

                currentPointIndex++;

                distanceToNextPoint = Vector3.Distance(linePoints[currentPointIndex], linePoints[currentPointIndex + 1]);
            }

            distanceAlongLine += distanceToMove;
            transform.position = Vector3.Lerp(linePoints[currentPointIndex], linePoints[currentPointIndex + 1], distanceAlongLine / distanceToNextPoint);
        }
    }
}
