using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    public KeyCode holdKey = KeyCode.Space;
    public float maxHoldDuration = 3.0f;
    public int pointsPerSecond = 100;

    private bool isHolding = false;
    private float startTime;

    void Update()
    {
        if (Input.GetKeyDown(holdKey))
        {
            isHolding = true;
            startTime = Time.time;
        }

        if (Input.GetKeyUp(holdKey))
        {
            if (isHolding)
            {
                float holdDuration = Time.time - startTime;
                int score = Mathf.RoundToInt(holdDuration * pointsPerSecond);
            }
        }
    }
}