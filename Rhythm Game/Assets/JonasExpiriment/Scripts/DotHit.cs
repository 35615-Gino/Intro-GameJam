using UnityEngine;

public class DotHit : MonoBehaviour
{
    public float hitRadius = 0.5f;
    public int maxScore = 1000;

    private bool canHit = false;
    private int currentScore = 0;

    public CameraPulse cameraPulse;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canHit)
        {
            CalculateScore();
            cameraPulse.TriggerPulse();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canHit == false)
        {
            Debug.Log("bad hit");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dot"))
        {
            canHit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("dot"))
        {
            canHit = false;
        }
    }

    void CalculateScore()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, hitRadius);
        float closestDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("dot"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }
        }

        float accuracy = Mathf.Clamp01(1 - (closestDistance / hitRadius));
        int score = Mathf.RoundToInt(accuracy * maxScore);

        Debug.Log("Accuracy: " + accuracy);
        Debug.Log("Score: " + score);

        currentScore += score;

        canHit = false;
    }
}
