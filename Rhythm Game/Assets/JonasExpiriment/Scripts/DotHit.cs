using TMPro;
using UnityEngine;
using System;

public class DotHit : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI misText;

    public bool canHit = false;
    public float hitRadius = 0.5f;
    public int maxScore = 1000;
    private int misses = 0;
    public int maxMisses = 0;

    private int hits = 0;
    private int successfulHits = 0;
    public int totalDots = 0;
    public int currentScore = 0;
    public CameraPulse cameraPulse;
    public Action OnCanHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canHit)
        {
            CalculateScore();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dot"))
        {
            canHit = true;
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

        currentScore += score;
        accuracyText.text = "Accuracy: " + accuracy.ToString();
        scoreText.text = "Score: " + currentScore.ToString();
        
        if (score > 0)
        {
            successfulHits++;
            cameraPulse.TriggerPulse();
            OnCanHit?.Invoke();
        }
        if (score == 0)
        {
            misses++;
            if(misses == maxMisses)
            {
                Debug.Log("U suck lol");
            }
        }

        hitText.text = successfulHits.ToString() + " / " + totalDots.ToString();
        misText.text = misses.ToString() + " / " + maxMisses.ToString();
        canHit = false;
    }
}
